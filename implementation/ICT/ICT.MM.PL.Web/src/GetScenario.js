import { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';

function Scenarios() {

    //Inicialização de variáveis utilizando o hook useState para lhes atribuir valores por defeito e posteriormente alterá-las
    const [scenarios, setScenarios] = useState([]);
    const [firstRun, setFirstRun] = useState(true);

    //Funcao que retorna e atribui uma lista com todos os scenarios na base de dados a constante scenarios
    function GetScenarios() {
        fetch("http://soaforsafety.ddns.net:81/Scenario")
            .then((res) => res.json())
            .then((data) => {
                setScenarios(data)
                setFirstRun(false)
                console.log(data)
            });
    }
    //Funcao utilizada para eliminar um scenario dado o seu id
    function eliminarScenario(id) {
        const scenario = { id }
        fetch("http://soaforsafety.ddns.net:81/Scenario", {
            method: 'DELETE',
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(scenario)
        }).then(() => {
            console.log('Cenário Eliminado!')
            GetScenarios()
        })
    }

    //useEffect utilizado para carregar todos os scenarios sempre que a pagina seja aberta
    useEffect(() => {
        GetScenarios();
    }, []);

    return (
        <div>
            
            <Link to="/criarScenario">
                <button>Criar Novo Cenario</button>
            </Link>
            <table className="table table-striped">
                <tbody>
                    <tr>
                        <th>Id</th>
                        <th>Nome</th>
                        <th>Descricao</th>
                    </tr>
                    {(scenarios.items)?.map(scenario => (
                        <tr key={scenario.id}>
                            <td>{scenario.id}</td>
                            <td>{scenario.name}</td>
                            <td>{scenario.description}</td>
                            <td><Link to={{
                                pathname: "/editarScenario",
                                state: { scenario }
                            }} class="btn btn-info" role="button">Editar</Link></td>
                            <td><button class="btn btn-info" onClick={() => eliminarScenario(scenario.id)}>Eliminar</button></td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>)
}

export default Scenarios;