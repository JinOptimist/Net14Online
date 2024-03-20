import axios from 'axios';
import IMovie from '../models/IMovie';

const BASE_URL = 'https://localhost:7163/api/'

const getIndexMovies = () => {
	return axios.get(`${BASE_URL}movies/getIndexMovies`);
}

const deleteMovie = (id: number) => {
	return axios.post(`${BASE_URL}movies/deleteMovie/` + id);
}

const addMovieToDb = (addMovie: IMovie) => {
	return axios.post(
		`${BASE_URL}movies/addMovie`,
		addMovie
	);
}

const movieApi = {
	getIndexMovies,
	deleteMovie,
	addMovie: addMovieToDb
}

export default movieApi;