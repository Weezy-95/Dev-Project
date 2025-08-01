import * as native from 'natives';
export function drawText3D(x, y, z, text) {
    var scale = arguments.length > 4 && arguments[4] !== void 0 ? arguments[4] : 0.35;
    native.setDrawOrigin(x, y, z, false);
    native.beginTextCommandDisplayText('STRING');
    native.addTextComponentSubstringPlayerName(text);
    native.setTextFont(0);
    native.setTextScale(scale, scale);
    native.setTextColour(255, 255, 255, 255);
    native.setTextCentre(true);
    native.endTextCommandDisplayText(0, 0, 0);
    native.clearDrawOrigin();
}
