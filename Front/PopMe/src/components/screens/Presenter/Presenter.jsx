import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { isUUID } from "validator";
import PresenterForm from "../../forms/PresenterDataForm/PresenterForm";

const Presenter = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [isValidGuid, setIsValidGuid] = useState(isUUID(id));
  const [isLoading, setIsLoading] = useState(true);

  if (isValidGuid) {
    useEffect(() => {
      try {
        const fetchData = async () => {
          var response;

          try {
            // Получение токена из локального хранилища
            const token = localStorage.getItem("token");

            // Добавление токена к заголовкам запроса
            const config = {
              headers: { Authorization: `Bearer ${token}` }
            };
            response = await axios.get(
              `https://localhost:5010/getPresenter/` + id.toUpperCase(),
              config
            );

            if (response.status === 204) {
              setIsValidGuid(false);
            }
          } catch (error) {
            navigate("/error");
          }

          setIsLoading(false);
        };

        fetchData();
      } catch (error) {
        navigate("/error");
      }
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
          <p>
            Привет, ты попал на страницу оформления подарка, заполни данные
            ниже, чтобы мы могли корректно поздравить получателя сюрприза
          </p>

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
