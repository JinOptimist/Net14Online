import { Link } from "react-router-dom";
import "./links.css"

function Links() {
    return ( 
        <div className="link-lay">
            <Link to="">Home</Link>
            <Link to="user">Users</Link>
        </div>
     );
}

export default Links;