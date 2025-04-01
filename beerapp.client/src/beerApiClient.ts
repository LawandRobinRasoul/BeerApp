import axios from 'axios';

// Access the base URL from the environment variable
const baseUrlApi = import.meta.env.VITE_BEER_API_URL

interface Beer {
  name: string;
  rating: string;
  image: string;
  description: string;
}

export const GetBeers = async () => {
  try {
    const response = await axios.get(baseUrlApi);
    console.log(response.data);
    console.log(response.status);
    return response.data as Beer[];
  } catch (error) {
    console.error('Error fetching data:', error);
    return [];
  }
};