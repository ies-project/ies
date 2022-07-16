import { useState } from "react";
import { Link } from 'react-router-dom';

const Create = () => {

    const [name, setName] = useState('Device')
    const [description, setDescription] = useState('Description')

    const handleSubmit = (e) => {
        e.preventDefault()
        const device = {name, description}

        fetch("https://localhost:7207/DeviceType", {
            method: 'PUT',
            headers: { "Content-Type" : "application/json" },
            body: JSON.stringify(device)
        }).then(() => {
            console.log('Novo Tipo de Dispositivo Criado!')
        })

    }

    return (

        <div className="form-group">
            <Link to="/gerir">
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


export default Create;