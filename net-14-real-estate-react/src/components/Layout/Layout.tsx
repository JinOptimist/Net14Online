import { BrowserRouter, Link, Route, Routes } from "react-router-dom";
import Owners from "../owners";
import Apartaments from "../Apartaments/apartaments";
import AddOwner from "../AddOwner/add-owner";
import OwnerProfile from "../OwnerProfile/OwnerProfile";

function Layout() {
    return (
        <div>
            <BrowserRouter>
                <div>
                    <Link to="">Home page</Link>
                    <Link to="owner">Owner</Link>
                    <Link to="apartaments">Apartaments</Link>
                </div>
                <Routes>
                    <Route path="owner">
                        <Route index element={<Owners />} />
                        <Route path="AddOwner" element={<AddOwner />}></Route>
                        <Route path="Profile/:id" element={<OwnerProfile />}></Route>
                    </Route>
                    <Route path="apartaments" element={<Apartaments />}></Route>
                    <Route path="*" element={<div>NOT FOUND 404</div>}></Route>
                </Routes>
            </BrowserRouter>
        </div>
    );
}
export default Layout