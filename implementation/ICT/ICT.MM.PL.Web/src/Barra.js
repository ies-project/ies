import { Link } from 'react-router-dom';

const Barra = () => {
    return (
        <nav className="navbar navbar-dark bg-dark">
            <h1 style={{color: 'white'}}>SOA for Safety</h1>
            <div class="link-light">
                <Link to="/" class="btn btn-info" role="button">Home</Link>
                <Link to="/gerir" class="btn btn-info" role="button">Gerir</Link>
            </div>
        </nav>
    )
}

export default Barra;