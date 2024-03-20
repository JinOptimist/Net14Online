import { FC } from "react";
import IMovie from "../../models/IMovie";
import './slider.css';

interface MovieProps {
    movie: IMovie,
    onRemove?: (id: number) => void
}

export const MovieSliderBlock: FC<MovieProps> = ({ movie, onRemove }) => {
    return (
        <div className="slider-content ds-flex">
            <button onClick={() => onRemove?.(movie.id)} >
                X
            </button>
            <img src={movie.posterUrl} className="image-slider" alt="none"/>
            <div className="slider-movie-name">
                {movie.title}
            </div>
        </div>
    );
}