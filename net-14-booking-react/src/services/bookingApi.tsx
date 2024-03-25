import axios from "axios";
import { ISearch } from "../models/ISearch";

const BASE_URL =`https://localhost:7163/`

const GetSearches = () =>{
    return axios.get(`${BASE_URL}bookingWeb/searches`);
}

const GetSearchInfo =(id:string): Promise<ISearch[]>=>{
    return axios.get(`${BASE_URL}/bookingWeb/SearchInfo/${id}`);
}
const bookingApi = {
 GetSearches,
 GetSearchInfo
}

export default bookingApi;