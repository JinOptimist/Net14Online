import { useState } from "react";
import IHero from "../../../models/IHero";
import Hero from "../hero/hero";
import './add-hero.css'
import Race from "../../../models/Race";
import dndApi from "../../../services/dndApi";
import { useNavigate } from "react-router-dom";

function AddHero() {
	const navigate = useNavigate();
	const { createHero } = dndApi
	const [HeroData, setHeroData] = useState<IHero>({} as IHero);

	const onHeroNameChange = (evt: any) => {
		const name = evt.target.value
		setHeroData(oldHero => {
			const newHero = { ...oldHero, name }
			return newHero
		});

	}

	const onHeroCoinChange = (evt: any) => {
		const coins = evt.target.value
		setHeroData(oldHero => {
			const newHero = { ...oldHero, coins }
			return newHero
		});
	}

	const onHeroRaceChange = (evt: any) => {
		const race = evt.target.value
		setHeroData(oldHero => {
			const newHero = { ...oldHero, race }
			return newHero
		});
	}

	function onCreateClick(): void {
		createHero(HeroData)
			.then(({ data }) => {
				navigate(`/hero/profile/${data}`)
			});
	}

	return (
		<div className="add-hero-container">
			<div className="hero-data">
				<div>
					<input type="text" placeholder="name" onChange={onHeroNameChange} />
				</div>
				<div className="hero-data">
					<input type="number" placeholder="coin" onChange={onHeroCoinChange} />
				</div>
				<div>
					<select onChange={onHeroRaceChange}>
						<option value={Race.Elf}>Elf</option>
						<option value={Race.Human}>Human</option>
						<option value={Race.Orc}>Orc</option>
					</select>
				</div>
				<div>
					<button onClick={onCreateClick}>Create</button>
				</div>
			</div>

			<div className="hero-preview">
				<Hero hero={HeroData} isFullDetails={false}></Hero>
			</div>
		</div>
	);
}

export default AddHero;