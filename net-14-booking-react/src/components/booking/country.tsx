import { FC, FunctionComponent, useState } from "react"
import { ICountry } from "../../models/ICountry"
import "/Repo/Net14Online/net-14-booking-react/src/components/booking/country.css"

interface CountryProps{
    country: ICountry,
    onRemove?: (id: number) => void
}

const Country: FunctionComponent <CountryProps> = ({country, onRemove}) => {
    return (
    <div className="country">
        {country.city} ({country.id})
        <span onClick={()=> onRemove?.(country.id)} className="remove">X</span>
    </div>        
    );
}       

export default Country;