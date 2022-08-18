import { useState, useEffect } from "react";
import { Link, useHistory } from 'react-router-dom';

const CreateDevice = () => {

    let history = useHistory()
    const [deviceTypes, setDeviceTypes] = useState([])
    const [name, setName] = useState('Device')
    const [description, setDescription] = useState('Description')
    const handleSubmit = (e) => {
        e.preventDefault()
        const device = {name, description}

        fetch("https://localhost:7207/Device", {
            method: 'PUT',
            headers: { "Content-Type" : "application/json" },
            body: JSON.stringify(device)
        }).then(() => {
            console.log('Novo Tipo de Dispositivo Criado!')
            history.push("/gerirDevices")
        })

    }

    function GetDeviceTypes() {

        fetch("https://localhost:7207/DeviceType")
            .then((res) => res.json())
            .then((data) => {
                setDeviceTypes(data)
                console.log(data)
            });
    }

    useEffect(() => {
        GetDeviceTypes();
    }, []);


    return (

        <div className="form-group">
            <Link to="/gerirDevices">
                    <button>Voltar</button>
            </Link>
            <h2>Criar um Novo Dispositivo</h2>
            <form onSubmit={handleSubmit}>
                <label>Tipo de Dispositivo </label>
                <br></br>
                
                <select>
                {(deviceTypes.items)?.map(deviceType => (
                        <option key={deviceType.id} value={deviceType.id}>{deviceType.name}</option>
                    ))}
                </select>
                <br></br>
                <label>Nome do Dispositivo</label>
                <input
                    placeholder="Nome"
                    class="form-control"
                    type="text"
                    required
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />

                <label>Descrição do Dispositivo</label>
                <textarea 
                    placeholder="Descrição"
                    class="form-control"
                    required
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                ></textarea>
                <button>Adicionar Novo Dispositivo</button>
            </form>
        </div>


    )
}


export default CreateDevice;