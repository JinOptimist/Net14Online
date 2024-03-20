import { FC,FunctionComponent, useState} from "react"
import { ISearch } from "../../models/ISearch"
import "/Repo/Net14Online/net-14-booking-react/src/components/booking/country.css"
import {Link} from "react-router-dom"
import "/Repo/Net14Online/net-14-booking-react/src/components/booking/search.css"

interface SearchProps{
 search: ISearch 
 onRemove?:(id:number) => void
 isFullDetails: boolean
}

const Search: FunctionComponent <SearchProps> = ({search, isFullDetails, onRemove }) => {
    const [ShowDetails, SetShowDetails] = useState<boolean>(isFullDetails ?? false)

    function toggleShowDetails(): void {
		SetShowDetails(oldShowDetails => !oldShowDetails)
	}

    return (
        <div className="search">
            <div>
        	{ShowDetails && <span className="toggle-details" onClick={toggleShowDetails}>-</span>}
		    {!ShowDetails && <span className="toggle-details" onClick={toggleShowDetails}>+</span>}
            {search.country}
            </div>
            {
            ShowDetails&&<span>({search.id})</span>
            }
         {  ShowDetails&&
            <span onClick={()=> onRemove?.(search.id)} className="remove">X</span>
         }
            <Link to={'search/searchInfo/${search.id}'}>SearchInfo</Link> 
    </div>
    );
}       

export default Search;