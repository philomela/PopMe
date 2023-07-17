import axios from 'axios';

const PresenterService = async (route) => {
  try {
    const response = await axios.get(route); 
    return response.data;
  } catch (error) {
    throw new Error('Failed to fetch data');
  }
};

export default PresenterService;