import 'bootstrap/dist/css/bootstrap.min.css'
import 'jquery/dist/jquery.min.js'
import 'bootstrap/dist/js/bootstrap.min.js'
import logo from './logo.svg';
import './App.css';
import Navbar from './layout/navbar';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';

function App() {
  return (
      <Router>
          <div className='App'>
              <Navbar />
              <div className='content'>
                 
              </div>
          </div>
      </Router>
  );
}

export default App;
