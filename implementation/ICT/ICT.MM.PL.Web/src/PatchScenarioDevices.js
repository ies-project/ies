import { useState, useEffect } from "react";
import { Link } from 'react-router-dom';
import { useLocation } from "react-router-dom";

const EditScenarioDevices = () => {

    //Utilização do state passado pelo link anterior com informacao sobre o scenariodevice a editar
    const location = useLocation()
    const data = location.state

    //Inicialização de variáveis utilizando o hook useState para lhes atribuir valores por defeito e posteriormente alterá-las
    const [id_Device, setIdDevice] = useState(data.sc.id_Device)
    const [id_Scenario, setIdScenario] = useState(data.sc.id_Scenario)
    const [manufacturedDate, setManufacturedDate] = useState(data.sc.manufacturedDate)
    const [lastMaintenanceDate, setLastMaintenanceDate] = useState(data.sc.lastMaintenanceDate)
    const [maintenanceDueDate, setMaintenanceDueDate] = useState(data.sc.maintenanceDueDate)
    const [originalState, setOriginalState] = useState(data.sc.originalState)
    const [currentState, setCurrentState] = useState(data.sc.currentState)

    //Funcao que atualiza um scenariodevice dados o id do device e do scenario associados
    function atualizarDevice(id_Scenario, id_Device) {
        const scData = { id_Device,id_Scenario, manufacturedDate, lastMaintenanceDate, maintenanceDueDate, originalState, currentState }
        fetch("https://localhost:7207/ScenarioDevice", {
            method: 'PATCH',
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(scData)
        }).then(() => {
            console.log('Cen�rio Dispositivo Atualizado!')
            console.log(scData)
        })
    }

    return (
        <div>

            <table className="table table-striped">
                <tbody>
                    <tr>
                        <th>ID do Cenrio</th>
                        <th>ID do Dispositivo</th>
                        <th>Data de Fabrico</th>
                        <th>Data da Ultima Manutencao</th>
                        <th>Data da Proxima Manutencao</th>
                        <th>Estado Original</th>
                        <th>Estado Atual</th>
                    </tr>
                    <tr key={data.sc.id_Scenario}>
                        <td>
                            {data.sc.id_Scenario}
                        </td>
                        <td>
                            {data.sc.id_Device}
                        </td>
                        <td>
                            <input
                                placeholder={data.sc.manufacturedDate}
                                class="form-control"
                                type="datetime-local"
                                required
                                value={manufacturedDate}
                                onChange={(e) => setManufacturedDate(e.target.value)}
                            >
                            </input>
                        </td>
                        <td>
                            <input
                                placeholder={data.sc.lastMaintenanceDate}
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
                                placeholder={data.sc.maintenanceDueDate}
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
                                placeholder={data.sc.originalState}
                                class="form-control"
                                type="text"
                                required
                                value={originalState}
                                onChange={(e) => setOriginalState(e.target.value)}
                            >
                            </input>
                        </td>
                        <td>
                            <input
                                placeholder={data.sc.currentState}
                                class="form-control"
                                type="text"
                                required
                                value={currentState}
                                onChange={(e) => setCurrentState(e.target.value)}
                            >
                            </input>
                        </td>
                        <td>
                            <Link to="/gerirScenarioDevices" class="btn btn-info" role="button">Cancelar</Link>
                        </td>
                        <td>
                            <Link to="/gerirScenarioDevices" class="btn btn-info" role="button" onClick={() => { atualizarDevice(data.sc.id_Scenario, data.sc.id_Device) }}>Guardar</Link>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

    )
}


export default EditScenarioDevices;

/**<tr key={device.id}>
<td>{device.id}</td>
<td>{device.name}</td>
<td>{device.description}</td>
<td><Link to="/gerir" class="btn btn-info" role="button">Cancelar</Link></td>
<td><button class="btn btn-info">Guardar</button></td>
</tr>**/