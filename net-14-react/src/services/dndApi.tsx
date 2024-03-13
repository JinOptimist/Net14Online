import axios from "axios";
import IHero from "../models/IHero";
import Race from "../models/Race";

const BASE_URL = 'https://localhost:7163/api/'

const getHeroes = () => {
	return axios.get(`${BASE_URL}dnd/heroes`);
}

const getHeroProfile = (id: string) => {
	return axios.get(`${BASE_URL}dnd/heroProfile/${id}`);
}

const createHero = (hero: IHero) => {
	const raceNumber = (hero.race ?? Race.Human) - 0 
	const heroToServer = { ...hero, race: raceNumber }
	return axios.post(
		`${BASE_URL}dnd/AddHero`,
		heroToServer
	);
}

const dndApi = {
	getHeroes,
	getHeroProfile,
	createHero
}

export default dndApi;