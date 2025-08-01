/// <reference types="@altv/types-client" />

import * as alt from 'alt-client';

let canRent = true;

alt.on('keydown', (key: number) => {
    if (key === 69 && canRent) {
        alt.log('[Client] Taste E gedrückt, sende Event an Server...');
        alt.emitServer('tryRentVehicle');
    }
});

alt.onServer('rental:started', (vehicleId: number, seconds: number) => {
    alt.setTimeout(() => {
        alt.emitServer('rental:expire', vehicleId);
    }, seconds * 1000);
});