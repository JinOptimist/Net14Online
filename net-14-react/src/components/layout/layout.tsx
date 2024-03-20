import { BrowserRouter, Route, Routes } from "react-router-dom";
import Heroes from "../dnd/heroes/heroes";
import Dungeon from "../dnd/dungeon/dungeon";
import AddHero from "../dnd/add-hero/add-hero";
import HeroProfile from "../dnd/hero-profile/hero-profile";
import Header from "./header";

function Layout() {
	return (

		<BrowserRouter>
			<Header />
			<Routes>
				<Route path="hero">
					<Route index element={<Heroes />} />
					<Route path="add-hero" element={<AddHero />}></Route>
					<Route path="profile/:id" element={<HeroProfile />}></Route>
				</Route>

				<Route path="dungeon" element={<Dungeon />}></Route>

				<Route index element={<div>Первая страничка</div>} />

				<Route path="*" element={<div>не понятный путь. Мы такого не знаем</div>} />
			</Routes>
		</BrowserRouter>);
}

export default Layout;