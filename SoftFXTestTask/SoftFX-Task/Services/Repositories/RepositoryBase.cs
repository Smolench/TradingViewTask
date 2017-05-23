using SoftFXTestTask.EntityFramework;
using SoftFXTestTask.EntityFramework.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace SoftFXTestTask.Services
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class, IEntity
    {
        public readonly DataBaseContext _db = new DataBaseContext();
        public virtual void Add(T model)
        {
            try
            {
                _db.Set<T>().Add(model);
            }
            catch
            {
                // ignored
            }
        }
        public virtual void AddList(ICollection<T> models)
        {
            try
            {
                _db.Set<T>().AddRange(models);
            }
            catch
            {
                // ignored
            }
        }
        public virtual void Delete(ICollection<T> models)
        {
            try
            {
                _db.Set<T>().RemoveRange(models);
            }
            catch
            {
                // ignored
            }
        }
        public virtual void Delete(T model)
        {
            try
            {
                _db.Set<T>().Remove(model);
            }
            catch
            {
                // ignored
            }
        }
        public virtual void Delete(int id)
        {
            try
            {
                _db.Set<T>().Remove((_db.Set<T>().FirstOrDefault(x => x.Id == id)));
            }
            catch
            {
                // ignored
            }
        }
        public virtual void Delete(ICollection<int> ids)
        {
            try
            {
                foreach(var model in _db.Set<T>().Where(x => ids.Contains(x.Id)))
                {
                    _db.Entry(model).State = EntityState.Deleted;
                }
            }
            catch
            {
                // ignored
            }
        }
        public virtual T Get(Func<T, bool> where)
        {
            try
            {
                return _db.Set<T>().Where(where).First();
            }
            catch
            {
                return null;
            }
        }
        public virtual T Get(int id)
        {
            return Get(x => x.Id == id);
        }
        public virtual ICollection<T> GetList()
        {
            try
            {
                return _db.Set<T>().ToList();
            }
            catch
            {
                return new List<T>();
            }
        }
        public virtual ICollection<T> GetList(Func<T, bool> where)
        {
            try
            {
                return _db.Set<T>().Where(where).ToList();
            }
            catch
            {
                return new List<T>();
            }
        }
        public virtual void Update(ICollection<T> models)
        {
            try
            {
                foreach (var model in models)
                {
                    _db.Entry(model).State = EntityState.Modified;
                }
            }
            catch
            {
                // ignored
            }
        }
        public virtual void Update(T model)
        {
            try
            {
                _db.Entry(model).State = EntityState.Modified;
            }
            catch
            {
                // ignored
            }
        }
        public virtual void Save()
        {
            _db.SaveChanges();
        }
    }
}