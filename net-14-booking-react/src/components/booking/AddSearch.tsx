import { useState } from "react";
import Search from "./search";
import { ISearch } from "../../models/ISearch";
import bookingApi from "../../services/bookingApi";
import { useNavigate } from "react-router-dom";

function AddSearch (){
    const [SearchInfo, setSearchInfo] = useState({
        id: 0,
        country: '',
        city: '',
        isFullDetails: false
    });
    const {AddNewSearch} = bookingApi
    const navigate = useNavigate();

    const onCountryChange = (evt: React.ChangeEvent<HTMLInputElement> ) => {
        const countryName = evt.target.value;
        setSearchInfo(oldSearch => {
            const newSearch = ({...oldSearch, country: countryName})
             return newSearch 
    });
};
const onCityChange = (evt: React.ChangeEvent<HTMLInputElement> ) => {
    const cityName = evt.target.value;
    setSearchInfo(oldSearch => {
        const newSearch = ({...oldSearch, city: cityName})
         return newSearch 
});
};

function onCreateClick(): void {
    AddNewSearch(SearchInfo)
        .then(({ data }) => {
            navigate(`/search/SearchInfo/${data}`)
        });
}
    return(
        <div className="AddSearch">
            <div className="SearchData">
            <input type="text" placeholder="country" onChange={onCountryChange} value={SearchInfo.country}/>
            </div>
            <div className="SearchData">
            <input type="text" placeholder="city" onChange={onCityChange} value={SearchInfo.city}/>
            </div>
            <div className="preview">
                <Search search={SearchInfo} isFullDetails={false}></Search>
            </div>
            <div>
                <button onClick={onCreateClick}>Create</button>
            </div>
    </div>
    );
}
export default AddSearch;