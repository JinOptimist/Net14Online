import axios from "axios";
import { ISearch } from "../models/ISearch";

const SERVER_URL =`https://localhost:7163/`
const BASE_API_URL = `${SERVER_URL}api/`

const GetSearches = () =>{
    return axios.get(`${BASE_API_URL}bookingWeb/searches`);
}

const GetSearchInfo =(id:string)=>{
    return axios.get(`${BASE_API_URL}bookingWeb/SearchInfo/${id}`);
}

const AddNewSearch =(search:ISearch) => {
        return axios.post(`${BASE_API_URL}bookingWeb/AddSearch`, search)
};

const bookingApi = {
 GetSearches,
 GetSearchInfo,
 AddNewSearch,
 SERVER_URL,
 BASE_API_URL
}

export default bookingApi;