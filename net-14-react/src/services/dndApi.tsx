import axios from "axios";
import IHero from "../models/IHero";
import Race from "../models/Race";

const SERVER_URL = 'https://localhost:7163/'
const BASE_API_URL = `${SERVER_URL}api/`

const getHeroes = () => {
	return axios.get(`${BASE_API_URL}dnd/heroes`);
}

const getHeroProfile = (id: string) => {
	return axios.get(`${BASE_API_URL}dnd/heroProfile/${id}`);
}

const createHero = (hero: IHero) => {
	const raceNumber = (hero.race ?? Race.Human) - 0
	const heroToServer = { ...hero, race: raceNumber }
	return axios.post(
		`${BASE_API_URL}dnd/AddHero`,
		heroToServer
	);
}

const uploadAvatar = (heroId: string, avatar: File) => {
	let config = {
		headers: {
			'content-type': 'multipart/form-data'
		}
	}
	return axios
		.post(`${BASE_API_URL}dnd/UpdateAvatar/${heroId}`, { avatar }, config);
}

const dndApi = {
	getHeroes,
	getHeroProfile,
	createHero,
	uploadAvatar,
	SERVER_URL
}

export default dndApi;