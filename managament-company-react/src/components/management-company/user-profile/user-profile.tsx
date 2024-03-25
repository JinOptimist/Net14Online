import { useParams } from "react-router-dom";

function UserProfile() {
    const {id} = useParams();

    return ( 
    <div>
        Profile {id} user
        </div> );
}

export default UserProfile;