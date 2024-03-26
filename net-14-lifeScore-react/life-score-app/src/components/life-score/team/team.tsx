import { FunctionComponent } from "react";
import { ITeam } from "../../../models/ITeam";
import '../team/team.css';
import { Link } from "react-router-dom";


interface TeamProps{
    team: ITeam,
    onRemove?: (id:number) => void,
    isFullDetails?: boolean
}

const Team: FunctionComponent<TeamProps> = ({team, isFullDetails, onRemove}) => {
    return (
        <div className="team">
            {team.name} 
            {
                isFullDetails &&
                <span>({team.id})</span>
            }
            {
                 isFullDetails &&
                 <span onClick={() => onRemove?.(team.id)} className="removeTeam">X</span>
            }
            <Link to={`/teams/team-profile/${team.id}`}>Profile</Link>
        </div>
    )
}

export default Team;