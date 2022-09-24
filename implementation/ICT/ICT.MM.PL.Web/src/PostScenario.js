import { useState } from "react";
import { Link, useHistory } from 'react-router-dom';

const CreateScenario = () => {

    let history = useHistory()

    //Inicialização de variáveis utilizando o hook useState para lhes atribuir valores por defeito e posteriormente alterá-las
    const [name, setName] = useState('Scenario')
    const [description, setDescription] = useState('Description')

    //Cria um novo scenario com base nas constantes definidas anteriormente e submete o pedido para o API
    const handleSubmit = (e) => {
        e.preventDefault()
        const scenario = { name, description }

        fetch("https://localhost:7207/Scenario", {
            method: 'PUT',
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(scenario)
        }).then(() => {
            console.log('Novo Cenário Criado!')
            //Utilização do history para redirecionamento
            history.push("/gerirScenarios")
        })

    }

    return (

        <div className="form-group">
            <Link to="/gerirScenarios">
                <button>Voltar</button>
            </Link>
            <h2>Criar um Novo Cenario</h2>
            <form onSubmit={handleSubmit}>
                <label>Nome do Cenario</label>
                <input
                    placeholder="Nome"
                    class="form-control"
                    type="text"
                    required
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />

                <label>Descricao do Cenario</label>
                <textarea
                    placeholder="Descricao"
                    class="form-control"
                    required
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                ></textarea>
                <button>Adicionar Novo Cenario</button>
            </form>
        </div>


    )
}


export default CreateScenario;