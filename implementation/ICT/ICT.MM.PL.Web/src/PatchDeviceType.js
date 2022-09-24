import { useState } from "react";
import { Link } from 'react-router-dom';
import { useLocation } from "react-router-dom";

const EditDeviceType = () => {

    //Utilização do state passado pelo link anterior com informacao sobre o devicetype a editar
    const location = useLocation()
    const data = location.state

    //Inicialização de variáveis utilizando o hook useState para lhes atribuir valores por defeito e posteriormente alterá-las
    const [name, setName] = useState(data.device.name)
    const [description, setDescription] = useState(data.device.description)

    //Funcao que atualiza um devicetype dado o seu id
    function atualizarDeviceType(id) {
        const deviceData = {id, name, description}
        fetch("https://localhost:7207/DeviceType", {
            method: 'PATCH',
            headers: { "Content-Type" : "application/json" },
            body: JSON.stringify(deviceData)
        }).then(() => {
            console.log('Dispositivo Atualizado!')
            console.log(deviceData)
        })
    }

    return (
        <div>

        <table className="table table-striped">
            <tbody>
                <tr>
                    <th>ID</th>
                    <th>Nome</th>
                    <th>Descrição</th>
                </tr>
                <tr key={data.device.id}>
                    <td>
                        {data.device.id}
                    </td>
                    <td>
                        <input
                        placeholder={data.device.name}
                        class="form-control"
                        type="text"
                        required
                        value={name}
                        onChange={(e) => setName(e.target.value)}
                        >
                        </input>
                    </td>
                    <td>
                        <input
                            placeholder={data.device.description}
                            class="form-control"
                            type="text"
                            required
                            value={description}
                            onChange={(e) => setDescription(e.target.value)}
                            >
                        </input>
                    </td>
                    <td>
                        <Link to="/gerirDeviceTypes" class="btn btn-info" role="button">Cancelar</Link>
                    </td>
                    <td>
                        <Link to="/gerirDeviceTypes" class="btn btn-info" role="button" onClick={ () => {atualizarDeviceType(data.device.id)} }>Guardar</Link>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>

    )
}


export default EditDeviceType;

/**<tr key={device.id}>
<td>{device.id}</td>
<td>{device.name}</td>
<td>{device.description}</td>
<td><Link to="/gerir" class="btn btn-info" role="button">Cancelar</Link></td>
<td><button class="btn btn-info">Guardar</button></td>
</tr>**/