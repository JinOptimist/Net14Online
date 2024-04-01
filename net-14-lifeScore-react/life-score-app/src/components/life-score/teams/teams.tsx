import { useEffect, useState } from "react";
import { ITeam } from "../../../models/ITeam";
import '../teams/teams.css';
import Team from "../team/team";
import { Link } from "react-router-dom";
import lifeScoreApi from "../../../services/lifeScoreApi";

const Teams = () => {
    const { getTeams } = lifeScoreApi;
    const [Teams, setTeams] = useState<ITeam[]>([
        {
            id: 1,
            name: 'Ynost'
        },
        {
            id: 2,
            name: 'Mogilev'
        }
    ]);

    useEffect(() => {
		getTeams()
			.then(({ data }) => {
				setTeams(data as ITeam[])
			})
	}, []);

    const onAddNewTeam = () => {
        const newTeam = {
            id: 4,
            name: 'Vitebsk'
        }

       setTeams(currentTeamsData => [...currentTeamsData, newTeam]);
    }

    function removeTeam(id: number): void {
        setTeams(currentTeamsData => currentTeamsData.filter(team => team.id !== id));
    }

    return (
        
       

        <div>
            <div>
                <Link to='add-team'>Add team</Link>
            </div>

            <button onClick={onAddNewTeam}>One Team</button>
           
            <div className="teams">
                {Teams.map(team=>(
                    <Team team = {team} isFullDetails={true} onRemove={removeTeam} key={team.id}></Team>
                ))}
            </div>
        </div>
    )
} 

export default Teams;