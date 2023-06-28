import './App.css'
import Admin from './components/screens/Admin/Admin';
import Receiver from './components/screens/Receiver/Receiver'
import Presenter from './components/screens/Presenter/Presenter'
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import PresenterMemeCategories from './components/screens/Presenter/PresenterMemeCategories';

const App = () => {
  return (
    <Router>
      <Routes>
      <Route path="/admin" element={<Admin/>} />
      <Route path="/presenter/:id" element={<Presenter/>} />
      <Route path="/presenter/:id/memecategories" element={<PresenterMemeCategories/>} />
      <Route path="/receiver/:id" element={<Receiver/>} />
    </Routes>
    </Router>
  );
};

export default App
