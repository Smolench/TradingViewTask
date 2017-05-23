Datafeeds.UDFCompatibleDatafeed.prototype.getQuotes = function (symbols, onDataCallback, onErrorCallback) {
    this._send(this._datafeedURL + '/quotes', { symbols: symbols })
		.done(function (response) {
		    var data = JSON.parse(response);
		    if (data.s === 'ok') {
		        if (onDataCallback) {
		            onDataCallback(data.d);
		        }
		    } else {
		        if (onErrorCallback) {
		            onErrorCallback(data.errmsg);
		        }
		    }
		})
		.fail(function (arg) {
		    if (onErrorCallback) {
		        onErrorCallback('network error: ' + arg);
		    }
		});
};




