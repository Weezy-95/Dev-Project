/// <reference types="@altv/types-client" />
import * as alt from 'alt-client';
var canRent = true;
alt.on('keydown', function(key) {
    if (key === 69 && canRent) {
        alt.log('[Client] Taste E gedrückt, sende Event an Server...');
        alt.emitServer('tryRentVehicle');
    }
});
alt.onServer('rental:started', function(vehicleId, seconds) {
    alt.setTimeout(function() {
        alt.emitServer('rental:expire', vehicleId);
    }, seconds * 1000);
});
