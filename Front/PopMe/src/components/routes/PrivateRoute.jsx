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
    const fetchData = async () => {
      var token = localStorage.getItem("token");

      const auth = async () => {
        await axios
          .get(`https://localhost:5010/account/auth/` + id)
          .then((response) => {
            const token = response.data.token;
            localStorage.setItem("token", token);
          })
          .catch((error) => {
            if (error.response.status === 401) {
              navigate("/Error");
            }
          });

        //setIsLoading(false);
      };
      if (token) {
        await auth();
      }
      setIsAuthenticated(true);
    };
    fetchData();
  }, []);

  return isAuthenticated ? <Outlet /> : "Loading...";
};

export default PrivateRoute;
