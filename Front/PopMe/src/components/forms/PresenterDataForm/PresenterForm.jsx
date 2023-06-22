import { useState } from "react";
import { useParams } from "react-router-dom";
import styles from "./Presenter.module.css";
import axios from "axios";

const PresenterForm = () => {
  const { id } = useParams();
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
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    try {
      const response = await axios.put(
        "https://localhost:53746/updatePresenter/" + id,
        formData
      );
      console.log(response.data);
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
        placeholder="Как зовут человека, которого Вы хотите удивить?"
        value={formData.email}
        onChange={handleInputChange}
      />

      <input
        type="tel"
        name="phoneNumber"
        placeholder="Оставьте нам Ваш контактный номер телефона"
        value={formData.message}
        onChange={handleInputChange}
      />

      <input
        type="tel"
        name="phoneNumberReceiver"
        placeholder="Оставьте нам контактный номер телефона, человека которого вы хотите удивить:"
        value={formData.message}
        onChange={handleInputChange}
      />

      <input
        type="datetime-local"
        name="birthDateReceiver"
        placeholder="Дата рождения поздравителя:"
        value={formData.message}
        onChange={handleInputChange}
      />

      <button type="submit">Send</button>
    </form>
  );
};

export default PresenterForm;
