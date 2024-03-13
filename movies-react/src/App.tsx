import { MovieSlider } from './components/movie/moviesSlider';
import { IMovie } from './Models/movie';
import { Genre } from './Models/genre';
import { Login } from './components/Authorithation/login';
import { Registration } from './components/Authorithation/registration';
import { useState } from 'react';
import senko from './images/senko.png';
import 'bootstrap/dist/css/bootstrap.min.css';

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
