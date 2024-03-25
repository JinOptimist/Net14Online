import { BrowserRouter, Link, Route, Routes } from "react-router-dom";
import Teams from "../life-score/teams/teams";
import Table from "../life-score/table/table";
import AddTeam from "../life-score/add-team/add-team";
import TeamProfile from "../life-score/team-profile/team-profile";
import Header from "./header";

function Layout(){
    return (
    <BrowserRouter>
    
        <Header/>

        <Routes>
            <Route path='teams' >
                <Route index element={<Teams />}></Route>
                <Route path="add-team" element={<AddTeam/>}></Route>
                <Route path="team-profile/:id" element={<TeamProfile/>}></Route>
            </Route>

            <Route path='table' element={<Table/>}></Route>

            <Route index element={<div> First page</div>}></Route>
            
            <Route path='*' element={<div> Неизвестный путь</div>}></Route>
        </Routes>
     </BrowserRouter>
    )
}

export default Layout;