import './App.css';
import DeviceTypes from './GetDeviceType';
import Devices from './GetDevice';
import CreateDeviceType from './PostDeviceType';
import CreateDevice from './PostDevice';
import EditDeviceType from './PatchDeviceType';
import EditDevice from './PatchDevice';
import EditScenario from './PatchScenario';
import CreateScenario from './PostScenario';
import Home from './Home';
import Barra from './Barra';
import {BrowserRouter as Router, Route, Switch} from 'react-router-dom';
import Scenarios from './GetScenario';
import ScenarioDevices from './GetScenarioDevice';
import EditScenarioDevices from './PatchScenarioDevices';
import CreateScenarioDevice from './PostScenarioDevice';


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
            <Route exact path="/gerirDevices">
              <Devices />
            </Route>
            <Route exact path="/gerirDeviceTypes">
              <DeviceTypes />
            </Route>
            <Route exact path="/criarDeviceType">
              <CreateDeviceType />
            </Route>
            <Route exact path="/criarDevice">
              <CreateDevice />
            </Route>
            <Route exact path="/editarDeviceType">
              <EditDeviceType />
            </Route>
            <Route exact path="/editarDevices">
              <EditDevice />
            </Route>
            <Route exact path="/editarScenario">
              <EditScenario />
            </Route>
            <Route exact path="/criarScenario">
              <CreateScenario />
                </Route>
            <Route exact path="/gerirScenarios">
                <Scenarios />
            </Route>
            <Route exact path="/gerirScenarioDevices">
               <ScenarioDevices />
            </Route>
            <Route exact path="/editarScenarioDevices">
               <EditScenarioDevices />
            </Route>
            <Route exact path="/criarScenarioDevices">
               <CreateScenarioDevice />
            </Route>
          </Switch>
        </div>
      </div>
    </Router>
  )
}

export default App;