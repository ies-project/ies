import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

function ScenarioDevices() {

    const [scenarioDevices, setScenarioDevices] = useState([]);

    function GetScenarioDevices() {

        fetch("https://localhost:7207/ScenarioDevice")
            .then((res) => res.json())
            .then((data) => {
                setScenarioDevices(data)
                console.log(data)
            });
    }

    function eliminarScenarioDevice(id_Scenario, id_Device) {
        const scenario = { id_Scenario, id_Device }
        fetch("https://localhost:7207/ScenarioDevice", {
            method: 'DELETE',
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(scenario)
        }).then(() => {
            console.log('Cenário Dispositivo Eliminado!')
            GetScenarioDevices()
        })
    }



    useEffect(() => {
        GetScenarioDevices();
    }, []);


    return (
        <div>
            <Link to="/criarScenarioDevices">
                <button>Criar Novo ScenarioDevice</button>
            </Link>
            <table className="table table-striped">
                <tbody>
                    <tr>
                        <th>ID do Cenario</th>
                        <th>ID do Device</th>
                        <th>Manufacture Date</th>
                        <th>Last Maintenance Date</th>
                        <th>Maintenance Due Date</th>
                        <th>Estado Original</th>
                        <th>Estado Atual</th>
                    </tr>
                    {(scenarioDevices.items)?.map(sc => (
                        <tr key={sc.id_Scenario}>
                            <td>{sc.id_Scenario}</td>
                            <td>{sc.id_Device}</td>
                            <td>{sc.manufacturedDate}</td>
                            <td>{sc.lastMaintenanceDate}</td>
                            <td>{sc.maintenanceDueDate}</td>
                            <td>{sc.originalState}</td>
                            <td>{sc.currentState}</td>
                            <td><Link to={{
                                pathname: "/editarScenarioDevices",
                                state: { sc }
                            }} class="btn btn-info" role="button">Editar</Link></td>
                            <td><button class="btn btn-info" onClick={() => eliminarScenarioDevice(sc.id_Scenario,sc.id_Device)}>Eliminar</button></td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>)
}

export default ScenarioDevices;