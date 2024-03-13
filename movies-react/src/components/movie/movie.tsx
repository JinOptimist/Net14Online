import { FC } from "react";
import { IMovie } from "../../Models/movie";
import './slider.css';

interface MovieProps {
    movie: IMovie
}

export const Movie: FC<MovieProps> = ({ movie }) => {
    return (
        <div className="slider-content ds-flex">
            <img src={movie.posterUrl} className="image-slider" alt="none"/>
            <div className="slider-movie-name">
                {movie.title}
            </div>
        </div>
    );
}