import { useState, useEffect } from 'react';
import DatePicker from './DatePicker';
const PostReport = () => {
    
    const [devices, setDevices] = useState([]);

    function GetDeviceTypes() {

        fetch("http://localhost:3000/PostReport")
            .then((res) => res.json())
            .then((data) => {
                setDevices(data)
                console.log(data)
            });
    }

    return ( 
        <div className="postReport">
            <h2 style={{
                paddingBottom: '20px' 
            }}>Criar um Relatório</h2>      
            <div className="insertDate" style={{display: 'flex'}}>
                <p>Escolha uma data</p>
                <DatePicker/>
            </div>
            
        </div>
     );
}
 
export default PostReport;