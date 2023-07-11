import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { useNavigate } from "react-router-dom";
import { Outlet } from "react-router-dom";
import axios from "axios";

const PrivateRoute = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  var [isAuthenticated, setIsAuthenticated] = useState(false);

  useEffect(() => {
    var isAuth = false;
    const fetchData = async () => {
      var token = localStorage.getItem("token");

      const validate = async (token) => {
        var response;
        const headers = {
          "Content-Type": "application/json",
          Accept: "*/*",
        };
        const data = `"${token}"`;

        response = await axios
          .post(`https://localhost:5010/account/validate/` + id, data, {
            headers,
          })
          .then((response) => {
            if (response.data.isValid) {
              isAuth = true;
            }
          })
          .catch((error) => {
            if (error.response.status === 401) {
              isAuth = false;
            } else navigate("/Error");
          });

        //setIsLoading(false);
      };
      const auth = async () => {
        var response;
        response = await axios
          .get(`https://localhost:5010/account/auth/` + id)
          .then((response) => {
            const token = response.data.token;
            localStorage.setItem("token", token);
            isAuth = true;
          })
          .catch((error) => {
            if (error.response.status === 401) {
              isAuth = false;
              navigate("/Error");
            }
          });

        //setIsLoading(false);
      };
      if (token) {
        await validate(token);
      }
      if (!isAuth) {
        await auth();
      }
      setIsAuthenticated(isAuth)
    };
    fetchData();
    
  }, []);

  return isAuthenticated ? <Outlet /> : "Loading...";
};

export default PrivateRoute;
