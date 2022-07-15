import {useEffect, useState } from 'react'; 
import axios from 'axios';

function GetDevices() {

    const [devices, setDevices] = useState([]);
    useEffect(() => {
        axios.get('https://localhost:7207/DeviceType')
        .then(res => {
            console.log(res);
            setDevices(res.data);
        })
        .catch( err => {
            console.log(err)
        });


    }, []);

    return (
    <div>
        <ul>
            {(devices.items)?.map(device => (
                     <li key={device.id}>{device.name}, {device.description}</li>
            ))}
        </ul>
    </div>)
}

export default GetDevices;