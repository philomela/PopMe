import dayjs from "dayjs";
import styles from "./Admin.module.css";

const AdminMenu = ({ countPairsQrCodes, lastDateTimeCreated }) => {
  return (
    <div className={styles.admin_menu}>
      <div className={styles.logo}>
        <p>PopMe!</p>
      </div>
      <ul className={styles.admin_menu_container}>
        <li>
          <p>
            <b>Statistic:</b> count created <b>{countPairsQrCodes}</b>, last
            created <b>{dayjs(lastDateTimeCreated).format("d MMM YYYY")}</b>
          </p>
        </li>
      </ul>
    </div>
  );
};

export default AdminMenu;
