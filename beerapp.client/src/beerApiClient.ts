import axios from 'axios';
import { useAuth0 } from '@auth0/auth0-vue';

// Access the base URL from the environment variable
const baseUrlApi = import.meta.env.VITE_BEER_API_URL

const authAudiance = import.meta.env.VITE_AUTH0_AUDIENCE

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
    const auth0 = useAuth0();
    const response = await axios.get(baseUrlApi,
    {
      headers: {
        Authorization: `Bearer ${await auth0.getAccessTokenSilently({
          authorizationParams: {
            audience: authAudiance
          }
        })}`,
      }
    });
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
    const response = await axios.post(`${baseUrlApi}/review`, review );
    console.log(response.status);
  } catch (error) {
    console.error('Error adding data:', error);
    return [];
  }
};
