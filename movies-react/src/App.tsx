import { MovieSlider } from './components/movie/movieSlider';
import { IMovie } from './components/types/movie';
import { Genre } from './components/types/genre';
import { Login } from './components/login';
import { Registration } from './components/registrationBlock';
import { useState } from 'react';
import './css/index.css';
import './css/main.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import senko from './images/senko.png';

function App() {
	const [movies, setMovies] = useState<IMovie[]>([
    {
      title: "Test 1",
      posterUrl: senko,
      description : "TestDescription",
      genres: [
        Genre.Comedy,
        Genre.Fantasy,
        Genre.Thriller
      ]
    }, {
      title: "Test 2",
      posterUrl: senko,
      description : "TestDescription",
      genres: [
        Genre.Comedy,
        Genre.Fantasy,
        Genre.Thriller
      ]
    } 
  ]);

  const addMovie = () => {
    let movie: IMovie = {
      title: "Test " + (movies.length + 1),
      posterUrl: senko,
      description : "TestDescription",
      genres: [
        Genre.Comedy,
        Genre.Fantasy,
        Genre.Thriller
      ]
    };
    setMovies([...movies, movie]);
  }
  
  return (
    <div>
      <MovieSlider genre={Genre.Fantasy} movies={movies} />
      <Login />
      <Registration />
      <button onClick={() => addMovie()} value="Добавить фильм" />
    </div>
  );
}

export default App;
