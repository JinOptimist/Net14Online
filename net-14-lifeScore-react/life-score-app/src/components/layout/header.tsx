import { Link } from "react-router-dom";
import './header.css';

const Header = () => {

    return(
        <div className="header">
            <Link to=''>Home page</Link>
            <Link to='teams'>Teams</Link>
            <Link to='table'>Table</Link>
        </div>
    )
}

export default Header;