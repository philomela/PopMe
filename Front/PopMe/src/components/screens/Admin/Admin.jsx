import { useState } from "react";
import { useEffect } from "react";
import axios from "axios";
import styles from "./Admin.module.css";
import AdminMenu from "./AdminMenu";

const Admin = () => {
  const [countQrCodes, setCountQrCodes] = useState(null);
  const [lastQrDate, setLastQrDate] = useState("");
  const [pairQrCodes, setPairQrCodes] = useState({});

  const fetchData = async () => {
    try {
      const responseInfoQrCodes = await axios.get(
        "https://localhost:53739/getInfoQrCodes"
      );
      const responseGeneratePairQrCode = await axios.post(
        "https://localhost:53739/generatePairQrCodes"
      );
      const responseGetPairQrCodes = await axios.get(
        "https://localhost:53739/getPairQrCodes/" + responseGeneratePairQrCode.data
      );

      setPairQrCodes(responseGetPairQrCodes.data);

      setCountQrCodes(responseInfoQrCodes.data.countPairsQrCodes);
      setLastQrDate(responseInfoQrCodes.data.lastDateTimeCreated);
    } catch (error) {
      console.error(error);
    }
  };

  useEffect(() => {
    fetchData();
  }, []);

  const handleGenerateQrClick = async () => {
    try {
      fetchData();
    } catch (error) {
      console.error(error);
      alert("Произошла ошибка при попытке выполнить запрос!");
    }
  };

  return (
    <div className={styles.admin_screen}>
      <AdminMenu countPairsQrCodes={countQrCodes} lastQrDate={lastQrDate} />
      <div className={styles.admin_container}>
        <div className={styles.qr}>
          <p className={styles.name}>For presenter</p>
          <div className={styles.qr_container}>
            <div className={styles.qr_border}>
              <img
                src={`data:image/jpeg;base64,${pairQrCodes.presenterQrCodeImg}`}
              />
              <p className={styles.qr_name}>Scan me!</p>
            </div>
          </div>
        </div>
        <div>
          <div className={styles.qr}>
            <p className={styles.name}>For receiver</p>
            <div className={styles.qr_container}>
              <div className={styles.qr_border}>
                <img
                  src={`data:image/jpeg;base64,${pairQrCodes.receiverQrCodeImg}`}
                />
                <p className={styles.qr_name}>Scan me!</p>
              </div>
            </div>
          </div>
        </div>
      </div>
      <button
        className={styles.generate_button}
        onClick={handleGenerateQrClick}
      >
        Generate Qr Codes
      </button>
    </div>
  );
};

export default Admin;
