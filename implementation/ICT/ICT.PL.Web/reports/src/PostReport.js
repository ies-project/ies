import { useState, useEffect } from 'react';
import DatePicker from './DatePicker';
import { Link, useHistory } from 'react-router-dom';

const PostReport = () => {

    const [devices, setDevices] = useState({});
    const [name, setName] = useState()
    const [date, setDate] = useState()
    const [criteria, setCriteria] = useState()
    const [createdBy, setCreatedBy] = useState()
    const [createdDate, setCreatedDate] = useState()
    const [modifiedBy, setModifiedBy] = useState()
    const [modifiedDate, setModifiedDate] = useState()

    function GetDeviceTypes() {

        fetch("http://localhost:7292/PostReport")
            .then((res) => res.json())
            .then((data) => {
                setDevices(data)
                console.log(data)
            });
    }

    const handleSubmit = (e) => {
        e.preventDefault()
        const report = { name, date, criteria, createdBy, createdDate, modifiedBy, modifiedDate }

        fetch("https://localhost:7292/postReport", {
            method: 'PUT',
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(report)
        }).then(() => {
            console.log('Novo Relatório Criado!')
        })

    }

    return (

        <div className="postReport">
            <Link to="/">
                <button>Voltar</button>
            </Link>
            <br></br>
            <h2>Criar um Relatório</h2>
            <form onSubmit={handleSubmit}>        
                <label>Nome</label>
                <input
                    class="form-control"
                    type="text"
                    required
                    value={name}
                    onChange={(e) => setName(e.target.value)}
                />
                <label>Data</label>
                <input
                    class="form-control"
                    type="text"
                    required
                    value={date}
                    onChange={(e) => setDate(e.target.value)}
                ></input>
                <label>Critério</label>
                <input
                    class="form-control"
                    type="text"
                    required
                    value={criteria}
                    onChange={(e) => setCriteria(e.target.value)}
                ></input>
                <label>Criado por</label>
                <input
                    class="form-control"
                    type="text"
                    required
                    value={createdBy}
                    onChange={(e) => setCreatedBy(e.target.value)}
                ></input>
                <label>Data de criação</label>
                <input
                    class="form-control"
                    type="text"
                    required
                    value={createdDate}
                    onChange={(e) => setCreatedDate(e.target.value)}
                ></input>    
                <button>Criar</button>        
            </form>
        </div>
    );
}

export default PostReport;