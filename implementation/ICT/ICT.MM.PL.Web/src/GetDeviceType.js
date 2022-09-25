import {useState, useEffect } from 'react'; 
import { Link } from 'react-router-dom';

function DeviceTypes() {

    //Inicialização de variáveis utilizando o hook useState para lhes atribuir valores por defeito e posteriormente alterá-las
    const [devices, setDevices] = useState([]);

    //Funcao que retorna e atribui uma lista com todos os devicetypes na base de dados a constante devicetypes
    function GetDeviceTypes() {

        fetch("https://localhost:7207/DeviceType")
            .then((res) => res.json())
            .then((data) => {
                setDevices(data)
                console.log(data)
            });
    }

    //Funcao utilizada para eliminar um devicetype dado o seu id
    function eliminarDeviceType(id) {
        const device = {id}
        fetch("http://soaforsafety.ddns.net:81/DeviceType", {
            method: 'DELETE',
            headers: { "Content-Type" : "application/json" },
            body: JSON.stringify(device)
        }).then(() => {
            console.log('Dispositivo Eliminado!')
            GetDeviceTypes()
        })
    }
    

    //useEffect utilizado para carregar todos os devicetypes sempre que a pagina seja aberta
    useEffect(() => {
        GetDeviceTypes();
    }, []);


        return (
        <div>
            <Link to="/criarDeviceType">
                    <button>Criar Novo Tipo de Dispositivo</button>
            </Link>
            <table className="table table-striped">
                <tbody>
                    <tr>
                        <th>ID</th>
                        <th>Nome</th>
                        <th>Descrição</th>
                        <th></th>
                        <th></th>
                    </tr>
                    {(devices.items)?.map(device => (
                        <tr key={device.id}>
                            <td>{device.id}</td>
                            <td>{device.name}</td>
                            <td>{device.description}</td>
                            <td><Link to={{
                                pathname: "/editarDeviceType", 
                                state: {device}
                            }} class="btn btn-info" role="button">Editar</Link></td>
                            <td><button class="btn btn-info" onClick={() => eliminarDeviceType(device.id)}>Eliminar</button></td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>)
}

export default DeviceTypes;