import axios from "axios";
import IUser from "../models/IUser";
import { useNavigate } from "react-router-dom";

const BASE_URL = 'https://localhost:7258/api/';



const getUsers = () => {
    return axios.get(`${BASE_URL}ManagementCompany/GetUsers`);
}

const getUserProfile = (id: string): Promise<IUser[]> => {
    return axios.get(`${BASE_URL}ManagementCompany/UserProfile/${id}`);
}

const addExecutor = (user: IUser) => {
    return axios.post(`${BASE_URL}ManagementCompany/AddExecutor/`, user)
}

const deleteExecutor = (id: number) => {
    return axios.get(`${BASE_URL}ManagementCompany/DeleteExecutor/${id}`);
}

const mcApi = {
    getUsers,
    getUserProfile,
    addExecutor, 
    deleteExecutor
}

export default mcApi;