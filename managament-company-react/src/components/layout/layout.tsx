import { BrowserRouter, Route, Routes } from "react-router-dom";
import Users from "../management-company/users/users";
import Links from "../links/links";
import AddUser from "../management-company/add-user/add-user";
import UserProfile from "../management-company/user-profile/user-profile";

function Layout() {
    return ( 
        <BrowserRouter>
        <Links />
        <Routes>
          <Route path="user" >
            <Route index element={<Users/>}/>
            <Route path="add-user" element={<AddUser/>} />
            <Route path="profile/:id" element={<UserProfile/>} />
          </Route>
          
          <Route index element={<div>Main</div>} />
          <Route path="*" element={<div> Empty</div>} />
        </Routes>
      </BrowserRouter>
     );
}

export default Layout;