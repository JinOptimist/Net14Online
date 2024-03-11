import { useState } from "react";
import IHero from "../../../models/IHero";
import './heroes.css'
import Hero from "../hero/hero";

const Heroes = () => {
	const [Heroes, setHeroes] = useState<IHero[]>([
		{
			id: 1,
			name: 'Ivan'
		},
		{
			id: 2,
			name: 'Lera'
		}
	]);

	const onAddHeroClick = () => {
		const newHero = {
			id: 34,
			name: 'Edmund'
		}
		setHeroes(currentHeroesData => [...currentHeroesData, newHero]);
	}

	function removeHero(id: number): void {
		setHeroes(currentHeroesData => currentHeroesData.filter(hero => hero.id !== id));
	}

	return (
		<div>
			<div>
				Всего у нас {Heroes.length} героев
			</div>
			<button onClick={onAddHeroClick}>One Hero</button>
			<div className="heroes">
				{Heroes.map(hero => (
					<Hero hero={hero} isFullDetails={true} onRemove={removeHero}></Hero>
				))}
			</div>
		</div>
	);
}

export default Heroes;
