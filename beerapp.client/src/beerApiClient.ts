import axios from 'axios';

// Access the base URL from the environment variable
const baseUrlApi = import.meta.env.VITE_BEER_API_URL

interface Beer {
  id: number;
  name: string;
  rating: string;
  imageUrl: string;
  description: string;
  createdAt: string;
}

export interface Review {
  beerId: number;
  rating: number;
  username: string;
  comment: string;
  bitternessScore: number;
  fruitinessScore: number;
  sweetnessScore: number;
}


export const GetBeers = async () => {
  try {
    const response = await axios.get(baseUrlApi);
    console.log(response.status);
    return response.data as Beer[];
  } catch (error) {
    console.error('Error fetching data:', error);
    return [];
  }
};

export const GetBeersBySearch = async (searchQuery: string) => {
  try {
    const response = await axios.get(`${baseUrlApi}/search?beerName=${encodeURIComponent(searchQuery)}`);
    console.log(response.status);
    return response.data as Beer[];
  } catch (error) {
    console.error('Error fetching data:', error);
    return [];
  }
};

export const GetBeerById = async (id: number) => {
  try {
    const response = await axios.get(`${baseUrlApi}/${encodeURIComponent(id)}`);
    console.log(response.status);
    return response.data as Beer;
  } catch (error) {
    console.error('Error fetching data:', error);
    return [];
  }
};


export const GetBeerReviewsById = async (id: number) => {
  try {
    const response = await axios.post(`${baseUrlApi}/${encodeURIComponent(id)}/reviews`);
    console.log(response.status);
    return response.data as Review[];
  } catch (error) {
    console.error('Error fetching data:', error);
    return [];
  }
};

export const CreateBeer = async (beer: Beer) => {
  try {
    const response = await axios.post(`${baseUrlApi}`, beer);
    console.log(response.status);
    return response.data as Beer[];
  } catch (error) {
    console.error('Error adding data:', error);
    return [];
  }
};

export const CreateReview = async (review: Review) => {
  try {
    const response = await axios.post(`${baseUrlApi}/review`, );
    console.log(response.status);
  } catch (error) {
    console.error('Error adding data:', error);
    return [];
  }
};