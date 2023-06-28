import { useParams } from "react-router-dom";
import { useState } from "react";
import { useEffect } from "react";
import axios from "axios";
import PresenterForm from "../../forms/PresenterDataForm/PresenterForm";

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
      <h2>Выберите категорию видео для поздравления:</h2>
      {playlists.map((playlist) => (
        <div key={playlist.id}>
          <h3>{playlist.snippet.title}</h3>
          <p>{playlist.snippet.description}</p>
        </div>
      ))}
    </div>
  );
};

export default PresenterMemeCategories;
