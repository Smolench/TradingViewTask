using SoftFXTestTask.EntityFramework.EntityModels;
using System;
using System.Collections.Generic;

namespace SoftFXTestTask.EntityFramework
{
    public static class CustomDatas
    {
        private static readonly Random random = new Random();

        public static DateTime dateTime = new DateTime(2017, 3, 15, 0, 0, 0);
        static readonly QuoteHelperValues ValuesUsdeur = new QuoteHelperValues(0.45, 0.23, 0.04, 1000, true);
        private static readonly Symbol USDEUR = new Symbol { Name = "USDEUR" };
        static readonly QuoteHelperValues ValuesRUBUSD = new QuoteHelperValues(2.23, 0.65, 0.01, 1500, true);
        static readonly Symbol RUBUSD = new Symbol { Name = "RUBUSD" };
        static readonly QuoteHelperValues ValuesGOLD = new QuoteHelperValues(120, 200, 40, 2500, false);
        static readonly Symbol GOLD = new Symbol { Name = "GOLD" };

        public static ICollection<string> GetIntegerSymbolsName()
        {
            return new List<string>() { "GOLD" };
        }

        public static ICollection<Symbol> GetSymbols()
        {
            return new List<Symbol> { USDEUR, RUBUSD, GOLD };
        } 

        public static void AddQuotesData(DataBaseContext db)
        {
            db.Symbols.Attach(USDEUR);
            db.Symbols.Attach(RUBUSD);
            db.Symbols.Attach(GOLD);
            db.Quotes.Add(InitializeQuotes(new Quote(USDEUR, dateTime), ValuesUsdeur));
            db.Quotes.Add(InitializeQuotes(new Quote(RUBUSD, dateTime), ValuesRUBUSD));
            db.Quotes.Add(InitializeQuotes(new Quote(GOLD, dateTime), ValuesGOLD));
        }
        public static void IncreaseDate()
        {
            dateTime = dateTime.AddHours(1);
        }
        static double RandomDouable(double minValue = 0, double maxValue = 0)
        {
            var rndmNumb = random.NextDouble();
            var temp = minValue + (rndmNumb * (maxValue - minValue));
            return Convert.ToDouble(temp.ToString("N2"));   
        }
        static double RandomInt(double minValue = 0, double maxValue = 0)
        {
            return random.Next((int)minValue, (int)maxValue);
        }
        static Quote InitializeQuotes(Quote quotes, QuoteHelperValues helper)
        {
            quotes.Open = helper.FirstOpen;
            double temp = helper.FirstOpen - helper.Delta;
            quotes.Low = helper.IsDouble ? RandomDouable(temp < 0 ? 0 : temp, quotes.Open)
                : RandomInt(temp < 0 ? 0 : temp, quotes.Open);
            quotes.High = helper.IsDouble ? RandomDouable(quotes.Open, quotes.Open + helper.Delta)
                : RandomInt(quotes.Open, quotes.Open + helper.Delta);
            quotes.Close = helper.IsDouble ? RandomDouable(quotes.Low, quotes.High)
                : RandomInt(quotes.Low, quotes.High);
            quotes.Volume = random.Next(0, helper.VolumeMax);
            temp = quotes.Close - helper.NextQuoteDeltaStep;
            helper.FirstOpen = helper.IsDouble ? RandomDouable(temp < 0 ? 0 : temp, quotes.Close + helper.NextQuoteDeltaStep)
                : RandomInt(temp < 0 ? 0 : temp, quotes.Close + helper.NextQuoteDeltaStep);
            return quotes;
        }
    }
    public class QuoteHelperValues
    {
        public bool IsDouble { get; private set; }
        public double NextQuoteDeltaStep { get; }
        public double FirstOpen { get; set; }
        public double Delta { get; }
        public int VolumeMax { get; }
        public QuoteHelperValues(double openValue, double delta, double nextStep, int volume, bool isDouble)
        {
            IsDouble = isDouble;
            NextQuoteDeltaStep = nextStep;
            FirstOpen = openValue;
            Delta = delta;
            VolumeMax = volume;
        }
        public QuoteHelperValues(double openValue, double delta, double nextStep, bool isDouble) : this(openValue, delta, nextStep, int.MaxValue, isDouble)
        { }
    }
}