import { BrowserRouter, Link, Route, Routes } from "react-router-dom";
import Countries from "./countries";
import AddSearch from "./AddSearch";
import SearchInfo from "./SearchInfo";
import Searches from "./searches";
import "/Repo/Net14Online/net-14-booking-react/src/components/booking/layout.css"

function Layout(){
    return(
        <BrowserRouter>
        <div className="header">
            <Link to={""}>Home page</Link>
            <Link to={"countries"}> Countries</Link>
            <Link to={"searches"}> Searches</Link>
        </div>
         <Routes>
            <Route path="countries" element={<Countries/>}></Route>
            <Route path="searches" >
                <Route index element={<Searches/>}/>
                <Route path="AddSearch" element={<AddSearch/>}></Route>
                <Route path="SearchInfo/:id" element={<SearchInfo/>}></Route>
            </Route>
            <Route index element={<div> First page</div>}/>
            <Route path="*" element={<div>Unknown page</div>}></Route>
        </Routes>
      </BrowserRouter>);
}
export default Layout;