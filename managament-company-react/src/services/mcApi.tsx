import axios from "axios";
import IUser from "../models/IUser";

const BASE_URL = 'https://localhost:7258/api/';

const getUsers = () => {
    return axios.get(`${BASE_URL}ManagementCompany/GetUsers`);
}

const getUserProfile = (id: string): Promise<IUser[]> => {
    return axios.get(`${BASE_URL}ManagementCompany/UserProfile/${id}`);
}

const AddExecutor = (user: IUser) => {
    return axios.post(`${BASE_URL}ManagementCompany/AddExecutor/`, user)
}

const mcApi = {
    getUsers,
    getUserProfile,
    AddExecutor
}

export default mcApi;