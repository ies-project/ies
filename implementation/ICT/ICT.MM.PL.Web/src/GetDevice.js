import { useState } from 'react';

function Devices() {

    const [Devices, setDevices] = useState([]);

    function GetDevices() {

        fetch("https://localhost:7207/Device")
            .then((res) => res.json())
            .then((data) => {
                setDevices(data)
                console.log(data)
            });
    }

    return (
        <div>
            <table className="table table-striped">
                <tbody>
                    <tr>
                        <th>Id</th>
                        <th>DeviceType</th>
                        <th>Name</th>
                        <th>Descrição</th>
                        <th>ManufacturedDate</th>
                        <th>LastMaintenanceDate</th>
                        <th>MaintenanceDueDate</th>
                        <th>ManufacturedBy</th>
                        <th>CreatedBy</th>
                        <th>CreatedDate</th>
                        <th>ModifiedBy</th>
                        <th>ModifiedDate</th>
                    </tr>
                    {(Devices.items)?.map(device => (
                        <tr key={device.id}>
                            <td>{device.id}</td>
                            <td>{device.id_DeviceType}</td>
                            <td>{device.name}</td>
                            <td>{device.description}</td>
                            <td>{device.manufacturedDate}</td>
                            <td>{device.lastMaintenanceDate}</td>
                            <td>{device.maintenanceDueDate}</td>
                            <td>{device.manufacturedBy}</td>
                            <td>{device.createdBy}</td>
                            <td>{device.createdDate}</td>
                            <td>{device.modifiedBy}</td>
                            <td>{device.modifiedDate}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>)
}

export default Devices;