import { useState } from "react";
import { Link, useHistory } from 'react-router-dom';

const CreateDeviceType = () => {

    let history = useHistory()
    //Inicialização de variáveis utilizando o hook useState para lhes atribuir valores por defeito e posteriormente alterá-las
    const [name, setName] = useState('Device')
    const [description, setDescription] = useState('Description')

    //Cria um novo devicetype com base nas constantes definidas anteriormente e submete o pedido para o API
    const handleSubmit = (e) => {
        e.preventDefault()
        const device = {name, description}

        fetch("https://localhost:7207/DeviceType", {
            method: 'PUT',
            headers: { "Content-Type" : "application/json" },
            body: JSON.stringify(device)
        }).then(() => {
            console.log('Novo Tipo de Dispositivo Criado!')
            //Utilização do history para redirecionamento
            history.push("/gerirDeviceTypes")
        })

    }

    return (

        <div className="form-group">
            <Link to="/gerirDeviceTypes">
                    <button>Voltar</button>
            </Link>
            <h2>Criar um Novo Tipo de Dispositivo</h2>
            <form onSubmit={handleSubmit}>
                <label>Nome do Tipo de Dispositivo</label>
                <input
                    placeholder="Nome"
                    class="form-control"
                    type="text"
                    required
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />

                <label>Descrição do Tipo de Dispositivo</label>
                <textarea 
                    placeholder="Descrição"
                    class="form-control"
                    required
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                ></textarea>
                <button>Adicionar Novo Tipo de Dispositivo</button>
            </form>
        </div>


    )
}


export default CreateDeviceType;