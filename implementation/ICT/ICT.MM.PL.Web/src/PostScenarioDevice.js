import { useState, useEffect } from "react";
import { Link, useHistory } from 'react-router-dom';

const CreateScenarioDevice = () => {

    let history = useHistory()

    const [scenarios, setScenarios] = useState([])
    const [devices, setDevices] = useState([])

    const [id_Device, setIdDevice] = useState({})
    const [id_Scenario, setIdScenario] = useState({})
    const [manufacturedDate, setManufacturedDate] = useState('')
    const [lastMaintenanceDate, setLastMaintenanceDate] = useState('')
    const [maintenanceDueDate, setMaintenanceDueDate] = useState('')
    const [originalState, setOriginalState] = useState('')
    const [currentState, setCurrentState] = useState('')


    const handleSubmit = (e) => {
        e.preventDefault()
        const sc = { id_Scenario, id_Device, manufacturedDate, lastMaintenanceDate, maintenanceDueDate, originalState, currentState }

        fetch("https://localhost:7207/ScenarioDevice", {
            method: 'PUT',
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(sc)
        }).then(() => {
            console.log('Novo cenario Dispositivo Criado!')
            history.push("/gerirScenarioDevices")
        })

    }

    function GetScenarios() {

        fetch("https://localhost:7207/Scenario")
            .then((res) => res.json())
            .then((data) => {
                setScenarios(data)
                console.log(data)
            });
    }

    function GetDevices() {

        fetch("https://localhost:7207/Device")
            .then((res) => res.json())
            .then((data) => {
                setDevices(data)
                console.log(data)
            });
    }

    useEffect(() => {
        GetScenarios();
        GetDevices();
    }, []);


    return (

        <div className="form-group">
            <Link to="/gerirScenarioDevices">
                <button>Voltar</button>
            </Link>
            <h2>Criar um Novo Cenario Dispositivo </h2>
            <form onSubmit={handleSubmit}>
                        <td>
                            <label>Cenario</label>
                            <br />
                            <select required onChange={(e) => setIdScenario(e.target.value)}>
                                <option selected value disabled>-- Selecione um Cenario --</option>
                                {(scenarios.items)?.map(scenario => (
                                <option key={scenario.id} value={scenario.id}>{scenario.name}</option>
                                ))}
                            </select>
                        </td>
                        <br />
                        <td>
                            <label>Device</label>
                            <br />
                            <select required onChange={(e) => setIdDevice(e.target.value)}>
                                <option selected value disabled>-- Selecione um Dispositivo --</option>
                                {(devices.items)?.map(device => (
                                <option key={device.id} value={device.id}>{device.name}</option>
                                ))}
                            </select>
                        </td>
                        <br />
                        <td>
                            <label>Data de Fabrico</label>
                            <input
                                class="form-control"
                                type="datetime-local"
                                required
                                value={manufacturedDate}
                                onChange={(e) => setManufacturedDate(e.target.value)}
                            >
                            </input>
                        </td>
                        <br />
                        <td>
                            <label>Data da ultima Manutencao</label>
                            <input
                                class="form-control"
                                type="datetime-local"
                                required
                                value={lastMaintenanceDate}
                                onChange={(e) => setLastMaintenanceDate(e.target.value)}
                            >
                            </input>
                        </td>
                        <br />
                        <td>
                            <label>Data da proxima Manutencao</label>
                            <input
                                class="form-control"
                                type="datetime-local"
                                required
                                value={maintenanceDueDate}
                                onChange={(e) => setMaintenanceDueDate(e.target.value)}
                            >
                            </input>
                        </td>
                        <br />
                        <td>
                            <label>Estado Original</label>
                            <input
                                placeholder={"Estado Original"}
                                class="form-control"
                                type="text"
                                required
                                value={originalState}
                                onChange={(e) => setOriginalState(e.target.value)}
                            >
                            </input>
                        </td>
                        <br />
                        <td>
                            <label>Estado Atual</label>
                            <input
                                placeholder={"Estado Atual"}
                                class="form-control"
                                type="text"
                                required
                                value={currentState}
                                onChange={(e) => setCurrentState(e.target.value)}
                            >
                            </input>
                        </td>
                <button>Adicionar</button>
            </form>
        </div>


    )
}


export default CreateScenarioDevice;