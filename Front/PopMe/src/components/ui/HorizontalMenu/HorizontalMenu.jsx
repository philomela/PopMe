import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { isUUID } from "validator";
import PresenterForm from "../../forms/PresenterDataForm/PresenterForm";
import styles from "./HorizontalMenu.module.css";

const HorizontalMenu = () => {
  return (
    <nav className={styles.horizontal_menu}>
      <ul>
        <li className={styles.menu_item}>
          <a className={styles.item_link} href="/about">
            Инструкция
          </a>
        </li>
        <li className={styles.menu_item}>
          <a className={styles.item_link} href="/about">
            О нас
          </a>
        </li>
        <li className={styles.menu_item}>
          <a className={styles.item_link} href="/contact">
            Поддержка
          </a>
        </li>
      </ul>
    </nav>
  );
};

export default HorizontalMenu;
