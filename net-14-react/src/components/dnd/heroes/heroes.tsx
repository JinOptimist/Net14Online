import { useEffect, useState } from "react";
import IHero from "../../../models/IHero";
import './heroes.css'
import Hero from "../hero/hero";
import { Link } from "react-router-dom";
import dndApi from "../../../services/dndApi";

const Heroes = () => {
	const { getHeroes } = dndApi;
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

	useEffect(() => {
		getHeroes()
			.then(({ data }) => {
				setHeroes(data as IHero[])
			})
	}, []);

	const onAddHeroClick = () => {
		const newHero = {
			id: 34,
			name: 'Edmund'
		} as IHero
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
			<div>
				<Link to="add-hero">Add hero</Link>
			</div>
			<button onClick={onAddHeroClick}>One Hero</button>
			<div className="heroes">
				{Heroes.map(hero => (
					<Hero hero={hero} isFullDetails={true} onRemove={removeHero} key={hero.id}></Hero>
				))}
			</div>
		</div>
	);
}

export default Heroes;
