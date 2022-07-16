
function PostDeviceTypes() {
    fetch('https://localhost:7207/DeviceType', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json'},
    }
    )


}