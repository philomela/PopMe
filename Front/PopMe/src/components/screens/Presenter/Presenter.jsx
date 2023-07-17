import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { isUUID } from "validator";
import styles from "./Presenter.module.css";
import PresenterForm from "../../forms/PresenterDataForm/PresenterForm";

const Presenter = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [isValidGuid, setIsValidGuid] = useState(isUUID(id));
  const [isLoading, setIsLoading] = useState(true);

  if (isValidGuid) {
    useEffect(() => {
      const fetchData = async () => {
        try {
          const token = localStorage.getItem("token");
          const config = {
            headers: { Authorization: `Bearer ${token}` },
          };
          await axios.get(
            `https://localhost:5010/getPresenter/` + id.toUpperCase(),
            config
          ).then((response) => {
            if (response.status === 204) {
              setIsValidGuid(false);
            }
          })
          .catch(() => {
              navigate("/Error");
          });

          
        } catch (error) {
          navigate("/error");
        }

        setIsLoading(false);
      };

      fetchData();
    }, []);
  } else {
    useEffect(() => {
      return navigate("/NotFound");
    }, []);
  }

  if (!isValidGuid) {
  }

  return (
    <div>
      {!isLoading ? (
        <>
          <h1>Шаг 1</h1>
          <h2>
            Привет! <br />
            Ты попал на страницу оформления подарка. <br /> Заполни данные ниже,
            чтобы мы могли корректно поздравить получателя сюрприза.
          </h2>

          <div>
            <PresenterForm id={id} />
          </div>
        </>
      ) : (
        <>
          <p>Loading...</p>
        </>
      )}
    </div>
  );
};

export default Presenter;
