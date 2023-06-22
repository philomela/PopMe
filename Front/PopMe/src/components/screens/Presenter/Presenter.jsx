import { useEffect } from "react";
import { useState } from "react";
import { useParams } from "react-router-dom";
import PresenterForm from "./PresenterForm";
import styles from "./Presenter.module.css";
import axios from "axios";

const Presenter = () => {
  const { id } = useParams();

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
