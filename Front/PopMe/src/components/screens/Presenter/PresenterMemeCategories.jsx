import { Navigate, useParams } from "react-router-dom";
import { useState } from "react";
import { useEffect } from "react";
import axios from "axios";
import { Link } from "react-router-dom";
import styles from "./PresenterMemeCategories.module.css";

const PresenterMemeCategories = () => {
  const { id } = useParams();
  const [playlists, setPlaylists] = useState([]);

  useEffect(() => {
    const fetchPlaylists = async () => {
      try {
        const response = await axios.get(
          `https://www.googleapis.com/youtube/v3/playlists?part=snippet&channelId=UCSIcnfAbb_q0y-ZouQy8vAg&key=AIzaSyDgFd5ZnUrJ3NLTfgcACnaaUVh0qpqyWRA`
        );
        setPlaylists(response.data.items);
      } catch (error) {
        console.error(error);
      }
    };
    fetchPlaylists();
  }, []);

  return (
    <div>
      <h1>Шаг 2</h1>
      <h2>Выберите категорию видео для поздравления</h2>
      {playlists.map((playlist) => (
        <div key={playlist.id}>
          <Link className={styles.category} to={`/presenter/${id}/playlist/${playlist.id}`}>
            {playlist.snippet.title}
          </Link>
          <p>{playlist.snippet.description}</p>
        </div>
      ))}
    </div>
  );
};

export default PresenterMemeCategories;
