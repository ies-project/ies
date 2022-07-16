import {useState, useEffect } from 'react'; 
import { Link } from 'react-router-dom';

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

    function eliminarDeviceType(id) {
        const device = {id}
        fetch("https://localhost:7207/DeviceType", {
            method: 'DELETE',
            headers: { "Content-Type" : "application/json" },
            body: JSON.stringify(device)
        }).then(() => {
            console.log('Dispositivo Eliminado!')
            GetDevices()
        })
    }

    /**useEffect(() => {
        GetDevices();
    }, []);*/


    if (firstRun) {
        return (
            <div>
                <a href="https://localhost:7207/swagger/index.html" target="_blank">
                    <button type="button">Swagger</button>
                </a>
                <button onClick={GetDevices}>Listar Tipos de Dispositivos</button>
                <Link to="/criarDeviceType">
                    <button>Criar Novo Tipo de Dispositivo</button>
                </Link>
            </div>)
    }

        return (
        <div>
            <a href="https://localhost:7207/swagger/index.html" target="_blank">
                <button type="button">Swagger</button>
            </a>
            <button onClick={GetDevices}>Listar Dispositivos</button>
            <Link to="/criarDeviceType">
                    <button>Criar Novo Tipo de Dispositivo</button>
            </Link>
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
                            <td><button onClick={() => eliminarDeviceType(device.id)}>Eliminar</button></td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>)
}

export default DeviceTypes;