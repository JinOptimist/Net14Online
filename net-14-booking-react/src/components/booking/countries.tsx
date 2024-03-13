import React from "react";
import { useState } from "react";
import { ICountry } from "../../models/ICountry";

const Countries = () => {
    const [Countries, setCountry] = useState<ICountry[]>([
        {
            id: 1,
            city: 'Rome'
        },
        {
            id: 2,
            city: 'Madrid'
        }
    ]);
    
    const onClickAddCountry = () => {
		const newCountry = {
			id: 3,
			city: 'Berlin'
		}

		setCountry(currentCountries => [...currentCountries, newCountry]);
	}

    function removeCountry(id: number): void {
		setCountry(currentCountries => currentCountries.filter(country => country.id !== id));
	}
    return (
        <div>
            <button onClick ={onClickAddCountry}>Add country</button>
            {Countries.map(country => (
                <div>
                    {country.city} ({country.id})  
                    <span onClick={()=> removeCountry(country.id)} className="remove">X</span>          
      </div>
            ))}
        </div>
    );   
}

export default Countries;