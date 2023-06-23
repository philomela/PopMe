import { useParams } from "react-router-dom";
import PresenterForm from "../../forms/PresenterDataForm/PresenterForm";

const Presenter = () => {

  return (
    <div>
      <p>
        Привет, ты попал на страницу оформления подарка, заполни данные ниже,
        чтобы мы могли, корректно поздравить получателя сюрприза
      </p>
      <div>
        <PresenterForm />
      </div>
    </div>
  );
};

export default Presenter;
