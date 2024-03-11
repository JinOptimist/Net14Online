import { FC } from "react";
import IHero from "../../../models/IHero";
import './hero.css'

interface HeroProps {
	hero: IHero,
	isFullDetails?: boolean,
	onRemove?: (id: number) => void
}

const Hero: FC<HeroProps> = ({ hero, isFullDetails, onRemove }) => {
	return (
		<div className="hero">
			{hero.name}
			{
				isFullDetails &&
				<span>({hero.id})</span>
			}

			{
				isFullDetails &&
				<span onClick={() => onRemove?.(hero.id)} className="remove">X</span>
			}
		</div>
	);
}

export default Hero;
