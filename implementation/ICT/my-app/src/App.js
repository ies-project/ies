import logo from './logo.svg';
import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <a href="https://192.168.1.69:7207/swagger/index.html">
        <img src={logo} className="App-logo" alt="logo" />
        </a>
        <p>
          O Rafa adormeceu
        </p>
        <a
          className="App-link"
          href="https://192.168.1.69:7207/swagger/index.html"
          target="_blank"
          rel="noopener noreferrer"
        >
          Ir para o API FUDIDO MEMO YA?
        </a>
      </header>
    </div>
  );
}

export default App;
