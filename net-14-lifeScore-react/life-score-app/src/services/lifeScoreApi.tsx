import axios from "axios";

const SERVER_URL = 'https://localhost:7163/'
const BASE_API_URL = `${SERVER_URL}api/`

const getTeams = () => {
    return axios.get(`${BASE_API_URL}lifescore/getteams`);
}

const lifeScoreApi = {
    getTeams,
    SERVER_URL
}

export default lifeScoreApi;