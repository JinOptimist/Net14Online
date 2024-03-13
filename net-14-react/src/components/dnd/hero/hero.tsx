import { FC, useState } from "react";
import IHero from "../../../models/IHero";
import './hero.css'
import { Link } from "react-router-dom";
import Race from "../../../models/Race";

interface HeroProps {
	hero: IHero,
	isFullDetails?: boolean,
	onRemove?: (id: number) => void
}

const Hero: FC<HeroProps> = ({ hero, isFullDetails, onRemove }) => {
	const [ShowDetails, setShowDetails] = useState<boolean>(isFullDetails ?? false);

	function toggleShowDetails(): void {
		setShowDetails(oldShowDetails => !oldShowDetails)
	}

	return (
		<div className="hero">
			<div>
				{Race[hero.race ?? 1]}: {hero.name}
				{ShowDetails && <span className="toggle-details" onClick={toggleShowDetails}>-</span>}
				{!ShowDetails && <span className="toggle-details" onClick={toggleShowDetails}>+</span>}
			</div>
			<div>
				{ShowDetails && <span>id: {hero.id}</span>}
			</div>
			<div>
				{ShowDetails && <span>coin: {hero.coins}</span>}
			</div>
			<div>
				<Link to={`/hero/profile/${hero.id}`}>Profile</Link>
			</div>
			{ShowDetails && <span onClick={() => onRemove?.(hero.id)} className="remove">remove</span>}
		</div>
	);
}

export default Hero;
