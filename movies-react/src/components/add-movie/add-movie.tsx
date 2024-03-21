import { useState } from "react";
import IMovie from "../../models/IMovie";
import movieApi from "../../services/movie-api";
import { useNavigate } from 'react-router-dom';

const AddMovie = () => {
    const navigate = useNavigate();
    const { addMovie } = movieApi;
    const [movieData, setMovieData] = useState<IMovie>({} as IMovie);

    const onMovieTitleChange = (evt: any) => {
        const title = evt.target.value
        setMovieData(oldMovie => {
            const newMovie = { ...oldMovie, title }
            return newMovie
        });
    }

    const onMovieDescriptionChange = (evt: any) => {
        const description = evt.target.value
        setMovieData(oldMovie => {
            const newMovie = { ...oldMovie, description }
            return newMovie
        });
    }

    function onAddMovieClick(): void {
        addMovie(movieData)
            .then(() => {
                navigate('/');
                navigate(0);
            });
    }

    return (
        <div>
            <section className="vh-100">
                <div className="container h-100">
                    <div className="row d-flex justify-content-center align-items-center h-100">
                        <div className="col-lg-12 col-xl-11">
                            <div className="card text-black">
                                <div className="card-body p-md-5">
                                    <br />
                                    <div className="row">
                                        <div className="input-group">
                                            <input type="file" name="poster" />
                                            <input placeholder="Название фильма" className="form-control" onChange={onMovieTitleChange} />
                                            <input placeholder="Описание фильма" className="form-control" onChange={onMovieDescriptionChange} />
                                            <button type="submit" className="btn btn-outline-secondary"
                                                id="input-group-button-right" onClick={onAddMovieClick}>
                                                Добавить фильм
                                            </button>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    );
}

export default AddMovie;