import { useState, useEffect } from "react";
import { Link } from 'react-router-dom';
import { useLocation } from "react-router-dom";

const EditDevice = () => {

    //Utiliza��o do state passado pelo link anterior com informacao sobre o device a editar
    const location = useLocation()
    const data = location.state

    //Inicializa��o de vari�veis utilizando o hook useState para lhes atribuir valores por defeito e posteriormente alter�-las
    const [deviceTypes, setDeviceTypes] = useState([])
    const [id_DeviceType, setIdDeviceType] = useState(data.device.id_DeviceType)
    const [name, setName] = useState(data.device.name)
    const [description, setDescription] = useState(data.device.description)
    const [manufacturedDate, setManufacturedDate] = useState(data.device.manufacturedDate)
    const [lastMaintenanceDate, setLastMaintenanceDate] = useState(data.device.lastMaintenanceDate)
    const [maintenanceDueDate, setMaintenanceDueDate] = useState(data.device.maintenanceDueDate)
    const [manufacturedBy, setManufacturedBy] = useState(data.device.manufacturedBy)
    const [createdBy, setCreatedBy] = useState(data.device.createdBy)
    const [createdDate, setCreatedDate] = useState(data.device.createdDate)
    const [modifiedBy, setModifiedBy] = useState(data.device.modifiedBy)
    const [modifiedDate, setModifiedDate] = useState(data.device.modifiedDate)

    //Funcao que atualiza um device dado o seu id
    function atualizarDevice(id) {
        const deviceData = { id, id_DeviceType, name, description, manufacturedDate, lastMaintenanceDate, maintenanceDueDate, manufacturedBy, createdBy, createdDate, modifiedBy, modifiedDate }
        fetch("https://localhost:7207/Device", {
            method: 'PATCH',
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(deviceData)
        }).then(() => {
            console.log('Dispositivo Atualizado!')
            console.log(deviceData)
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
        <div>

            <table className="table table-striped">
                <tbody>
                    <tr>
                        <th>ID</th>
                        <th>Tipo de Dispositivo</th>
                        <th>Nome</th>
                        <th>Descricao</th>
                        <th>Data da Ultima Manutencao</th>
                        <th>Data da Proxima Manutencao</th>
                        <th>Modificado Por</th>
                        <th>Data da Ultima Modificacao</th>
                    </tr>
                    <tr key={data.device.id}>
                        <td>
                            {data.device.id}
                        </td>
                        <td>
                            <select required onChange={(e) => setIdDeviceType(e.target.value)}>
                                {(deviceTypes.items)?.map(deviceType => (
                                    <option key={deviceType.id} value={deviceType.id}>{deviceType.name}</option>
                                ))}
                            </select>
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
                            <input
                                placeholder={data.device.lastMaintenanceDate}
                                class="form-control"
                                type="datetime-local"
                                required
                                value={lastMaintenanceDate}
                                onChange={(e) => setLastMaintenanceDate(e.target.value)}
                            >
                            </input>
                        </td>
                        <td>
                            <input
                                placeholder={data.device.maintenanceDueDate}
                                class="form-control"
                                type="datetime-local"
                                required
                                value={maintenanceDueDate}
                                onChange={(e) => setMaintenanceDueDate(e.target.value)}
                            >
                            </input>
                        </td>
                        <td>
                            <input
                                placeholder={data.device.modifiedBy}
                                class="form-control"
                                type="text"
                                required
                                value={modifiedBy}
                                onChange={(e) => setModifiedBy(e.target.value)}
                            >
                            </input>
                        </td>
                        <td>
                            <input
                                placeholder={data.device.modifiedDate}
                                class="form-control"
                                type="datetime-local"
                                required
                                value={modifiedDate}
                                onChange={(e) => setModifiedDate(e.target.value)}
                            >
                            </input>
                        </td>
                        <td>
                            <Link to="/gerirDevices" class="btn btn-info" role="button">Cancelar</Link>
                        </td>
                        <td>
                            <Link to="/gerirDevices" class="btn btn-info" role="button" onClick={() => { atualizarDevice(data.device.id) }}>Guardar</Link>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

    )
}


export default EditDevice;

/**<tr key={device.id}>
<td>{device.id}</td>
<td>{device.name}</td>
<td>{device.description}</td>
<td><Link to="/gerir" class="btn btn-info" role="button">Cancelar</Link></td>
<td><button class="btn btn-info">Guardar</button></td>
</tr>**/