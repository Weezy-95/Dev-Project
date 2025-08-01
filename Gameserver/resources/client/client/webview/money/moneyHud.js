import * as alt from 'alt-client';
var view = null;
var viewReady = false;
var lastAmount = null;
function ensureView() {
    if (!view) {
        view = new alt.WebView('http://resources/client/client/webview/money/index.html');
        view.on('ui:ready:money', function() {
            viewReady = true;
            if (lastAmount !== null) view.emit('money:set', lastAmount);
            alt.emitServer('ui:ready:money');
        });
    }
    return view;
}
alt.onServer('money:update', function(amount) {
    var v = ensureView();
    lastAmount = Math.max(0, Math.floor(amount));
    if (viewReady) v.emit('money:set', lastAmount);
});
