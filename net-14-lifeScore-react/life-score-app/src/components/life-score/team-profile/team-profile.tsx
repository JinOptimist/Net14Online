import { useParams } from "react-router-dom";

const TeamProfile = () => {

    const {id} = useParams()

    return(
        <div>
            Team Profile {id}
        </div>
    )
}

export default TeamProfile;