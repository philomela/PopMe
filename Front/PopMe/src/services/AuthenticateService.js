import axios from "axios";
import { AUTH_URL } from "../constants/apiUrls"

const AuthenticateService = async (id) => {
  await axios
    .get(AUTH_URL + id)
    .then((response) => {
        const token = response.data.token;
        localStorage.setItem("token", token);
    })
    .catch((error) => {
        if (error.response.status === 401) {
            navigate("/Error");
          }
    })
};

export default AuthenticateService;
