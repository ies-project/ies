const Navbar = () => {
    return ( 
        <nav className="navbar">
            <h1>Relatórios</h1>
            <div className="links">
                <a href="/">Home</a>
                <a href="/PostReport" style={{
                    color: "white",
                    backgroundColor: '#f1356d',
                    borderRadius: '8px'
                }}>Criar Relatório</a>
            </div>
        </nav>
     );
}
 
export default Navbar;