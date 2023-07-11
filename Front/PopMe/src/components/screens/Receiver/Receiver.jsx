import { useEffect } from "react"
import { useState } from "react";
import { useParams } from 'react-router-dom';
import axios from "axios"

const Receiver = () => {
    const { id } = useParams();
    const [data, setData] = useState({});

    useEffect(() => {
      var result;
      const fetchData = async () => {
        result = await axios.get('https://localhost:5010/receiver/' + id);
        setData(result.data);
      };
      
      fetchData();
    }, [id]);
  
    return (
      <div>
        {data ? (
          <p>Привет {data.name}! Сегодня знаменательная дата {data.birthDate}
          <br/>У Вас сегодня день рождения! <br/>Ваш знакомый, сделал вам подарок. <br/>Текст поздравления: {data.textСongratulations} </p>
        ) : (
          <p>Loading...</p>
        )}
        <iframe width="560" height="315" src={"https://www.youtube.com/embed/" + data.videoId}></iframe>
      </div>
    );
  };

export default Receiver