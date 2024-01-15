function getLocation() {
    let response = "Geolocation is not supported;on your browser.";
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            if (!position)
                return;
            const latitude = position.coords.latitude;
            const longitude = position.coords.longitude;
            response = `${latitude};${longitude}`;
        });
    }
    return response
}