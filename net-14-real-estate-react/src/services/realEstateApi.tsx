import axios from "axios"
import IOwner from "../models/IOwner"

const BASE_URL = "https://localhost:7285/"

const getOwners = () => {
    return axios.get(`${BASE_URL}realestate/ApartmentOwners`);
}

const getOwnersProfile = (id: string): Promise<IOwner[]> => {
    return axios.get(`${BASE_URL}realestate/ownerProfile/${id}`);
}

const addOwner = (addOwner: IOwner) => {
    return axios.post(
        `${BASE_URL}realestate/AddApartmentOwner`,
        addOwner
    );
}

const deleteOwner = (id: number) => {
    return axios.post(`${BASE_URL}realestate/Delete/` + id);
}

const realestateApi = {
    getOwners,
    getOwnersProfile,
    addOwner: addOwner,
    deleteOwner
}

export default realestateApi;