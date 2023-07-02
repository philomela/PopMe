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
            response = await axios.get(
              `https://localhost:53746/getPresenter/` + id
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
