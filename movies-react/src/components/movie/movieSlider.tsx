import { Genre } from "../types/genre";
import { IMovie } from "../types/movie";
import { Movie } from './movie'
import 'slick-carousel/slick/slick.css';
import '../../css/slider.css'
import Slider from 'react-slick';

interface MovieSliderProps {
    movies: Array<IMovie>,
    genre: Genre
}

export const MovieSlider = (movies: MovieSliderProps) => {
    const settings = {
        dots: false,
        speed: 500,
        slidesToShow: 3,
        slidesToScroll: 2
    };
    return (
        <div>
            <p className="h4 fw-bold slider-header">
                {movies.genre.toLocaleString()}
            </p>
            <div className="slider">
                <Slider {...settings}>
                    {movies.movies.map((movie, index) => <Movie information={movie} key={index}/>)}
                </Slider>
            </div>
        </div>
    );
}