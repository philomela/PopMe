import './App.css'
import Admin from './components/screens/Admin/Admin';
import Receiver from './components/screens/Receiver/Receiver'
import Presenter from './components/screens/Presenter/Presenter'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

const App = () => {
  return (
    <Router>
      <Routes>
      <Route path="/receiver/:id" element={<Receiver/>} />
      <Route path="/presenter/:id" element={<Presenter/>} />
      <Route path="/admin" element={<Admin/>} />
    </Routes>
    </Router>
  );
};

export default App
