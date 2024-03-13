import { Link } from "react-router-dom";
import './header.css'

function Header() {
	return (
		<div className="header">
			<Link to="">Home page</Link>
			<Link to="hero">Heroes</Link>
			<Link to="dungeon">Dungeon</Link>
		</div>
	);
}

export default Header;