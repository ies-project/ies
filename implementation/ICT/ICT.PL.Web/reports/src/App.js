import Navbar from './Navbar';
import Home from './Home';
import PostReport from './PostReport';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'

function App() {

  return (
    <Router>
    <div className="App">
      <Navbar />
      <div className="content">
       <Routes>
          <Route path="/PostReport" element = {<PostReport/>} />
          <Route path="/" element = {<Home/>} />
       </Routes>
      </div>
    </div>
    </Router>
  );
}

export default App;