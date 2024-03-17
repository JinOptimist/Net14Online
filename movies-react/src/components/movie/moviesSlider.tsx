import IMovie from '../../models/IMovie';
import { MovieSliderBlock } from './movieSliderBlock'
import Slider from 'react-slick';
import { FC } from "react";
import 'slick-carousel/slick/slick.css';
import './slider.css'

interface MovieSliderProps {
    movies: IMovie[],
    onRemove?: (id: number) => void
}

const MovieSlider : FC<MovieSliderProps> = ({ movies, onRemove }) => {
    const settings = {
        dots: false,
        speed: 500,
        slidesToShow: 3,
        slidesToScroll: 2
    };
    return (
        <div>
            <div className="slider">
                {movies && 
                    <Slider {...settings}>
                    {movies.map((movie, index) => <MovieSliderBlock movie={movie} onRemove={onRemove} key={index}/>)}
                    </Slider>
                }
            </div>
        </div>
    );
}

export default MovieSlider;