import './App.css';
import DeviceTypes from './GetDeviceType';
import Create from './PostDeviceType';
import Home from './Home';
import Barra from './Barra';
import {BrowserRouter as Router, Route, Switch} from 'react-router-dom';

function App() {
  return (
    <Router>
      <div className='App'>
        <Barra />
        <div className='content'>
          <Switch>
            <Route exact path="/">
              <Home />
            </Route>
            <Route exact path="/gerir">
              <DeviceTypes />
            </Route>
            <Route exact path="/criarDeviceType">
              <Create />
            </Route>
          </Switch>
        </div>
      </div>
    </Router>
  )
}

export default App;
