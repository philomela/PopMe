import { useParams } from "react-router-dom";
import { useState } from "react";
import { useEffect } from "react";
import axios from "axios";
import styles from "./PresenterDetail.module.css";
import PresenterForm from "../../forms/PresenterDataForm/PresenterForm";

const PresenterDetail = () => {
  const { id } = useParams();
  const { playlistId } = useParams();
  const [videos, setVideos] = useState([]);
  const [video, setVideo] = useState({ id: null });

  const handleSubmit = async (event) => {
    event.preventDefault();
    const fetchData = async () => {
      const data = {
        id: id,
        textCongratulations: "Hello!",
        videoId: video.id
      };

      const response = await axios.put(
        "https://localhost:5010/updatePresenterDetail/" + id,
        data
      );
    };
    await fetchData()
  };

  useEffect(() => {
    const fetchVideos = async () => {
      try {
        const response = await axios.get(
          `https://www.googleapis.com/youtube/v3/playlistItems?part=snippet&maxResults=50&playlistId=${playlistId}&key=AIzaSyDgFd5ZnUrJ3NLTfgcACnaaUVh0qpqyWRA`
        );
        setVideos(response.data.items);
      } catch (error) {
        console.error(error);
      }
    };
    fetchVideos();
  }, []);

  return (
    <div>
      <h1>Шаг 3</h1>
      <h2>Выберите видео для поздравления:</h2>
      <div className={styles.videos_wrapper}>
        <div className={styles.video_item}>
          {videos.map((videoItem) => (
            <div key={videoItem.id}>
              <h3>{videoItem.snippet.title}</h3>
              <p>{videoItem.snippet.description}</p>
              <div
                className={
                  video.id === videoItem.snippet.resourceId.videoId
                    ? styles.video_item_selected
                    : styles.video_item
                }
                onClick={() =>
                  setVideo({ id: videoItem.snippet.resourceId.videoId })
                }
              >
                <iframe
                  width="560"
                  height="315"
                  src={
                    "https://www.youtube.com/embed/" +
                    videoItem.snippet.resourceId.videoId
                  }
                ></iframe>
              </div>
              {video.id === videoItem.snippet.resourceId.videoId ? (
                <button type="submit" onClick={handleSubmit}>
                  Выбрать и завершить
                </button>
              ) : null}
            </div>
          ))}
        </div>
      </div>
    </div>
  );
};

export default PresenterDetail;
