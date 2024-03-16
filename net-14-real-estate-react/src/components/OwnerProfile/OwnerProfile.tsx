import { useParams } from "react-router-dom";

function OwnerProfile() {
    const { id } = useParams()

    return (
        <div>
            You are looking for information about {id } the owner 
        </div>
    );
}

export default OwnerProfile;