import Race from "./Race";

export default interface IHero {
	id: number,
	name: string,
	coins?: number,
	race?: Race
}