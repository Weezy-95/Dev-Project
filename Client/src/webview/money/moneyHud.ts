import * as alt from 'alt-client';

let view: alt.WebView | null = null;
let viewReady = false;
let lastAmount: number | null = null;

function ensureView() {
    if (!view) {
        view = new alt.WebView('http://resources/client/client/webview/money/index.html');

        view.on('ui:ready:money', () => {
            viewReady = true;
            if (lastAmount !== null) view!.emit('money:set', lastAmount);
            alt.emitServer('ui:ready:money');
        });
    }
    return view;
}

alt.onServer('money:update', (amount: number) => {
    const v = ensureView();
    lastAmount = Math.max(0, Math.floor(amount));
    if (viewReady) v.emit('money:set', lastAmount);
});


