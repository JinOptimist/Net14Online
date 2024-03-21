import { useEffect, useState } from 'react';
import movieApi from "../../services/movie-api";
import { Login } from "../authorithation/login";
import { Registration } from "../authorithation/registration";
import MovieSlider from "../movie/moviesSlider";
import IMovie from "../../models/IMovie";
import AddMovie from "../add-movie/add-movie";
import { BrowserRouter, Route, Routes } from "react-router-dom";

function Layout() {
    const { getIndexMovies, deleteMovie } = movieApi;
    const [moviesData, setMoviesData] = useState<IMovie[]>([]);

    useEffect(() => {
        getIndexMovies()
            .then(({ data }) => {
                setMoviesData(data as IMovie[])
            });
    }, []);

    const onDeleteMovie = (id: number) => {
        deleteMovie(id);
        setMoviesData(moviesData.filter(item => item.id !== id));
    }


    return (
        <BrowserRouter>
            <Routes>
                <Route path="add-movie" element={<AddMovie />}></Route>
                <Route path="*" element={<div>Не верный путь</div>} />
            </Routes>
            <MovieSlider movies={moviesData} onRemove={onDeleteMovie} />
            <Login />
            <Registration />
            <a href="/add-movie/"> Добавить фильм </a>
        </BrowserRouter>
    );
}

export default Layout;