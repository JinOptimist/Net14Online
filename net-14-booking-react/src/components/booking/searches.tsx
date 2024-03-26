import React, { useEffect } from "react";
import { useState } from "react";
import { ISearch } from "../../models/ISearch";
import Search from "./search";
import bookingApi from "../../services/bookingApi";

const Searches = () => {
    const {GetSearches} = bookingApi;
    const [Searches, setSearch] = useState<ISearch[]>([
        {
            id:1,
            country: 'Italy',
            isFullDetails: false,
            city:'Rome'
        },
        {
            id:2,
            country: 'Spain',
            isFullDetails: false,
            city: 'Madrid'
        }
    ]);    
    
    useEffect(()=>{
            GetSearches().then(({data}) =>{
                setSearch(data as ISearch[])
            })
    },[]);
    
    const onClickAddSearch = () => {
		const newSearch = {
			id: 3,
			country: 'Germany',
            isFullDetails: false,
            city: 'Berlin'
		}

		setSearch(currentSearches => [...currentSearches, newSearch]);
	}

    function removeSearch(id: number): void {
		setSearch(currentSearches => currentSearches.filter(search => search.id !== id));
	}
    return (
        <div>
            <button onClick ={onClickAddSearch}>Add search</button>  
            <div className="searches">
                {Searches.map(search => (
                <Search search ={search} onRemove={removeSearch} isFullDetails={false} key={search.id} ></Search>
        ))}
        </div>
    </div>
    );   
}

export default Searches;