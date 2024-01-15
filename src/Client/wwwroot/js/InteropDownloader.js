async function getLocation() {
    if (!navigator.geolocation)
        return "Geolocation is not supported;on your browser.";
    return new Promise((resolve) =>
        navigator.geolocation.getCurrentPosition(position => 
            resolve(`${position.coords.latitude};${position.coords.longitude}`)
        )
    )
}