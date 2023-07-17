import { useEffect, useState } from "react";
import { useNavigate  } from "react-router-dom";
import styles from "./PresenterForm.module.css"
import axios from "axios";

const PresenterForm = ({id}) => {
  const navigate = useNavigate();
  const [formData, setFormData] = useState({
    id: id,
    name: "",
    nameReceiver: "",
    phoneNumber: "",
    phoneNumberReceiver: "",
    birthDateReceiver: "",
  });

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setFormData({ ...formData, [name]: value });
    const [response, setResponse] = useState({});
  };

  useEffect(() => {
    
  });

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const response = await axios.put(
        "https://localhost:53746/updatePresenter/" + id,
        formData
      );
      console.log(response.data);
      navigate("/presenter/"+ id + "/memecategories");
      // здесь можно добавить логику обработки ответа от сервера
    } catch (error) {
      console.error(error);
      // здесь можно добавить логику обработки ошибки
    }
  };

  return (
    <form className={styles.presenter_form} onSubmit={handleSubmit}>
      <input
        type="text"
        name="name"
        placeholder="Как вас зовут?"
        value={formData.name}
        onChange={handleInputChange}
      />

      <input
        type="text"
        name="nameReceiver"
        placeholder="Как зовут получателя?"
        value={formData.email}
        onChange={handleInputChange}
      />

      <input
        type="tel"
        name="phoneNumber"
        placeholder="Ваш номер телефона"
        value={formData.message}
        onChange={handleInputChange}
      />

      <input
        type="tel"
        name="phoneNumberReceiver"
        placeholder="Номер телефона получателя"
        value={formData.message}
        onChange={handleInputChange}
      />

      <input
        type="date"
        name="surpriseDate"
        placeholder="Дата сюрприза"
        value={formData.message}
        onChange={handleInputChange}
      />

      <button type="submit">Продолжить</button>
    </form>
  );
};

export default PresenterForm;
