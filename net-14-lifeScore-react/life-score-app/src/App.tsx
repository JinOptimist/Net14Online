import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import Teams from './components/life-score/teams/teams';
import Team from './components/life-score/team/team';
import Table from './components/life-score/table/table';
import Layout from './components/layout/layout';

const App = () => {
  return (
    <div className="App">
      <Layout/>
    </div>
  );
}

export default App;
