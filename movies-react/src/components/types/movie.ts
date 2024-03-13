import { Genre } from "./genre";

export interface IMovie {
    title: string,
    posterUrl: string,
    description: string,
    genres: Genre[]
}
