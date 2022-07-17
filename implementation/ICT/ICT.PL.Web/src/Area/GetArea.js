import { useState, useEffect } from 'react';

function Areas() {

    const [Areas, setAreas] = useState([]);

    function GetAreas() {

        fetch("https://localhost:7292/Area")
            .then((res) => res.json())
            .then((data) => {
                setAreas(data)
                console.log(data)
            });
    }

    useEffect(() => {
        GetAreas();
    }, []);

    return (
        <div>
            <table className="table table-striped">
                <tbody>
                    <tr>
                        <th>Id</th>
                        <th>Edifício</th>
                        <th>Tipo de Area</th>
                        <th>Nome</th>
                        <th>Piso</th>
                        <th>Número de Fireballs</th>
                        <th>Número de Springles</th>
                        <th>Número de Bocas Singulares</th>
                        <th>Número de Bocas Siameses</th>
                    </tr>
                    {(Areas.items)?.map(area => (
                        <tr key={area.id}>
                            <td>{area.id}</td>
                            <td>{area.id_Type}</td>
                            <td>{area.name}</td>
                            <td>{area.floor}</td>
                            <td>{area.numFireballs}</td>
                            <td>{area.numSpringles}</td>
                            <td>{area.numBocasSingulares}</td>
                            <td>{area.numBocasSiamesas}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>)
}


export default Areas;