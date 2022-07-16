import {useState, useEffect } from 'react'; 

function DeviceTypes() {

    const [devices, setDevices] = useState([]);
    const [firstRun, setFirstRun] = useState(true);

    function GetDevices() {

        fetch("https://localhost:7207/DeviceType")
            .then((res) => res.json())
            .then((data) => {
                setDevices(data)
                setFirstRun(false)
                console.log(data)
            });
    }

    useEffect(() => {
        GetDevices();
    }, []);


    if (firstRun) {
        return (
            <div>
                <a href="https://localhost:7207/swagger/index.html" target="_blank">
                    <button type="button">Swagger</button>
                </a>
                <button onClick={GetDevices}>Listar Dispositivos</button>
            </div>)
    }

        return (
        <div>
            <a href="https://localhost:7207/swagger/index.html" target="_blank">
                <button type="button">Swagger</button>
            </a>
            <button onClick={GetDevices}>Listar Dispositivos</button>
            <table className="table table-striped">
                <tbody>
                    <tr>
                        <th>ID</th>
                        <th>Nome</th>
                        <th>Descrição</th>
                    </tr>
                    {(devices.items)?.map(device => (
                        <tr key={device.id}>
                            <td>{device.id}</td>
                            <td>{device.name}</td>
                            <td>{device.description}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>)
}

export default DeviceTypes;