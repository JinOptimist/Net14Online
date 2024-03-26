import { BrowserRouter, Route, Routes } from "react-router-dom";
import Countries from "./components/booking/countries";
import Searches from "./components/booking/searches";
import Layout from "./components/booking/layout";
import AddSearch from "./components/booking/AddSearch";

function App() {
  return (
    <div className="App">
      <Layout></Layout>
    </div>
  );
}

export default App;
