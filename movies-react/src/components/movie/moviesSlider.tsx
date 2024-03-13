import { Genre } from "../../Models/genre";
import { IMovie } from "../../Models/movie";
import { Movie } from './movie'
import Slider from 'react-slick';
import { FC } from "react";
import 'slick-carousel/slick/slick.css';
import './slider.css'

interface MovieSliderProps {
    movies: Array<IMovie>,
    genre: Genre
}

export const MovieSlider : FC<MovieSliderProps> = ({ movies, genre }) => {
    const settings = {
        dots: false,
        speed: 500,
        slidesToShow: 3,
        slidesToScroll: 2
    };
    return (
        <div>
            <p className="h4 fw-bold slider-header">
                {genre.toLocaleString()}
            </p>
            <div className="slider">
                <Slider {...settings}>
                    {movies.map((movie, index) => <Movie movie={movie} key={index}/>)}
                </Slider>
            </div>
        </div>
    );
}