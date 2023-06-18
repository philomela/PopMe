import { useEffect } from "react"
import { useState } from "react";
import { useParams } from 'react-router-dom';
import axios from "axios"

const index = () => {
    const { id } = useParams();
    const [data, setData] = useState(null);

    useEffect(() => {
      const fetchData = async () => {
        const result = await axios.get('https://localhost:53752/getReceiver/' + id);
        setData(result.data);
      };
      fetchData();
    }, [id]);
  
    return (
      <div>
        {data ? (
          <p>Привет {data.name}! Сегодня знаменательная дата {data.birthDate}
          <br/>У Вас сегодня день рождения! <br/>Ваш знакомый, сделал вам подарок, если вы готовы его получить, нажмите продолжить!</p>
        ) : (
          <p>Loading...</p>
        )}
      </div>
    );
  };

export default index