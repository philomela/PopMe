import "./App.css";
import Admin from "./components/screens/Admin/Admin";
import Receiver from "./components/screens/Receiver/Receiver";
import Presenter from "./components/screens/Presenter/Presenter";
import NotFound from "./components/screens/NotFound/NotFound";
import Error from "./components/screens/Error/Error";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import PresenterMemeCategories from "./components/screens/Presenter/PresenterMemeCategories";

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/admin" element={<Admin />} />
        <Route path="/presenter/:id" element={<Presenter />} />
        <Route
          path="/presenter/:id/memecategories"
          element={<PresenterMemeCategories />}
        />
        <Route path="/receiver/:id" element={<Receiver />} />
        <Route path="/notfound" element={<NotFound />} />
        <Route path="/error" element={<Error />} />
      </Routes>
    </Router>
  );
};

export default App;
