import axios from 'axios';
import { useAuth0 } from '@auth0/auth0-vue';

// Access the base URL from the environment variable
const baseUrlApi = import.meta.env.VITE_BEER_API_URL;

const authAudiance = import.meta.env.VITE_AUTH0_AUDIENCE;

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

let accessToken: string | null = null;

const getAccessToken = async () => {
  if (!accessToken) {
    const auth0 = useAuth0();
    accessToken = await auth0.getAccessTokenSilently({
      authorizationParams: {
        audience: authAudiance,
      },
    });
  }
  return accessToken;
};

export const GetBeers = async () => {
  try {
    const token = await getAccessToken();
    const response = await axios.get(baseUrlApi, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
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
    const token = await getAccessToken();
    const response = await axios.get(`${baseUrlApi}/search?beerName=${encodeURIComponent(searchQuery)}`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });
    console.log(response.status);
    return response.data as Beer[];
  } catch (error) {
    console.error('Error fetching data:', error);
    return [];
  }
};

export const GetBeerById = async (id: number) => {
  try {
    const token = await getAccessToken();
    const response = await axios.get(`${baseUrlApi}/${encodeURIComponent(id)}`, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });
    console.log(response.status);
    return response.data as Beer;
  } catch (error) {
    console.error('Error fetching data:', error);
    return [];
  }
};

export const GetBeerReviewsById = async (id: number) => {
  try {
    const token = await getAccessToken();
    const response = await axios.post(`${baseUrlApi}/${encodeURIComponent(id)}/reviews`, null, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });
    console.log(response.status);
    return response.data as Review[];
  } catch (error) {
    console.error('Error fetching data:', error);
    return [];
  }
};

export const CreateBeer = async (beer: Beer) => {
  try {
    const token = await getAccessToken();
    const response = await axios.post(`${baseUrlApi}`, beer, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });
    console.log(response.status);
    return response.data as Beer[];
  } catch (error) {
    console.error('Error adding data:', error);
    return [];
  }
};

export const CreateReview = async (review: Review) => {
  try {
    const token = await getAccessToken();
    const response = await axios.post(`${baseUrlApi}/review`, review, {
      headers: {
        Authorization: `Bearer ${token}`,
      },
    });
    console.log(response.status);
  } catch (error) {
    console.error('Error adding data:', error);
    return [];
  }
};
