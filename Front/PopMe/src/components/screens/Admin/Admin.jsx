import Button from '../../ui/controls/Button/Button';
import { useState } from "react";
import { useEffect } from "react"
import axios from "axios"
import styles from "./Admin.module.css"
import AdminMenu from "./AdminMenu"

const Admin = () => {
    
    const [data, setQrCodes] = useState({});

    useEffect(() => {
        const fetchData = async () => {
          const result = await axios.get('https://localhost:53739/generatePairQrCodes');
          setQrCodes(result.data);
        };
        fetchData();
      }, []);

    return ( 
        <div className={styles.admin_screen}>  
          <AdminMenu/>
      <div className={styles.admin_container}>
        <div className={styles.qr}>
        <p className={styles.name}>
                For presenter
            </p>
        
        <div className={styles.qr_container}>
            
            <div className={styles.qr_border}>
            
            <img src={`data:image/jpeg;base64,${data.presenterQrCodeImg}`} />
            
            <p className={styles.qr_name}>
                Scan me!
            </p>
            </div>
            </div>
        </div>
      <div>
      <div className={styles.qr}>
      <p className={styles.name}>
                For receiver
            </p>

            <div className={styles.qr_container}>

            <div className={styles.qr_border}>
            <img src={`data:image/jpeg;base64,${data.receiverQrCodeImg}`} />
            <p className={styles.qr_name}>
                Scan me!
            </p>

            </div>
            </div>
            
      </div>
        </div>
       
    
      </div>
      <button className={styles.generate_button} onClick={async () => setQrCodes((await axios.get('https://localhost:53739/generatePairQrCodes')).data)}>Generate Qr Codes</button>
      </div>
      
    );
  };

export default Admin