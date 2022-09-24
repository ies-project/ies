import { Link } from 'react-router-dom';
//Barra de navegacao que contem o Home e o trademark do projeto
const Barra = () => {
    return (
        <nav className="navbar navbar-dark bg-dark">
            <h1 style={{color: 'white'}}>SOA for Safety</h1>
            <div className="link-light">
                <Link to="/" className="btn btn-info" role="button">Home</Link>
            </div>
        </nav>
    )
}

export default Barra;