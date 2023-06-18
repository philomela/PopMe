import Button from '../../ui/controls/Button/Button';
import { useState } from "react";
import { useEffect } from "react";
import axios from "axios"
import dayjs from "dayjs"
import styles from "./Admin.module.css"

const AdminMenu = (props) => {
    const countCreated = props.count
    
    const [info, setInfoQrCodes] = useState({});

    useEffect(() => {
        const fetchData = async () => {
          const result = await axios.get('https://localhost:53739/getInfoQrCodes');
          setInfoQrCodes(result.data);
        };
        fetchData();
      });

    return ( 
        <div className={styles.admin_menu}> 
            <ul className={styles.admin_menu_container}>
                <li><p>
                    <b>Statistic:</b> count created <b>{info.countPairsQrCodes}</b>, last created <b>{dayjs(info.lastDateTimeCreated).format('d MMM YYYY')}</b>
                    </p>
                </li>
            </ul>
        </div>
  )};

export default AdminMenu