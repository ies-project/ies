import { useState, useEffect } from "react";
import { Link } from 'react-router-dom';
import { useLocation } from "react-router-dom";

const EditScenario = () => {

    //Utilização do state passado pelo link anterior com informacao sobre o scenario a editar
    const location = useLocation()
    const data = location.state

    //Inicialização de variáveis utilizando o hook useState para lhes atribuir valores por defeito e posteriormente alterá-las
    const [name, setName] = useState(data.scenario.name)
    const [description, setDescription] = useState(data.scenario.description)

    //Funcao que atualiza um cenario dado o seu id
    function atualizarScenario(id) {
        const scenarioData = { id, name, description }
        fetch("https://localhost:7207/Scenario", {
            method: 'PATCH',
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(scenarioData)
        }).then(() => {
            console.log('Cenario Atualizado!')
            console.log(scenarioData)
        })
    }


    return (
        <div>

            <table className="table table-striped">
                <tbody>
                    <tr>
                        <th>ID</th>
                        <th>Nome</th>
                        <th>Descricao</th>
                    </tr>
                    <tr key={data.scenario.id}>
                        <td>
                            {data.scenario.id}
                        </td>
                        <td>
                            <input
                                placeholder={data.scenario.name}
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
                                placeholder={data.scenario.description}
                                class="form-control"
                                type="text"
                                required
                                value={description}
                                onChange={(e) => setDescription(e.target.value)}
                            >
                            </input>
                        </td>
                        <td>
                            <Link to="/gerirScenarios" class="btn btn-info" role="button">Cancelar</Link>
                        </td>
                        <td>
                            <Link to="/gerirScenarios" class="btn btn-info" role="button" onClick={() => { atualizarScenario(data.scenario.id) }}>Guardar</Link>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>

    )
}


export default EditScenario;
