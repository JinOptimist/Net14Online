import { useParams } from "react-router-dom";

function HeroProfile() {
	const { id } = useParams()

	return (<div>
		Ты смотришь инфу про {id} героя
	</div>);
}

export default HeroProfile;