import { IMovie } from "../types/movie";
import '../../css/slider.css';

interface movieProps {
    information: IMovie
}

export const Movie = (movie: movieProps) => {
    return (
        <div className="slider-content ds-flex">
            <img src={movie.information.posterUrl} className="image-slider" />
            <div className="slider-movie-name">
                {movie.information.title}
            </div>
        </div>
    );
}