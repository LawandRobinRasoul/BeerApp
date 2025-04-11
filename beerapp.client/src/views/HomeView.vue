<template>
  <div class="home-view full-layout">
    <!-- Search Bar -->
    <div class="search-bar">
      <input type="text" v-model="searchQuery" placeholder="Search beers..." />
      <button class="search-btn" v-on:click="searchBeers">Search</button>
    </div>

    <!-- Beer Cards -->
    <div class="beer-cards">
      <div
        v-for="beer in beers"
        :key="beer.name"
        class="beer-card"
        @click="openModal(beer)"
      >
        <img :src="beer.image" alt="Beer Image" class="beer-image" />
        <h3>{{ beer.name }}</h3>
        <p>Rating: {{ beer.rating }}</p>
      </div>
    </div>

    <!-- BeerCard Modal -->
    <BeerCard v-if="selectedBeer" :beer="selectedBeer" @close="closeModal" />
  </div>
</template>

<script setup lang="ts">
import { ref, computed, onMounted } from 'vue';
import BeerCard from '@/components/BeerCard.vue';
import { GetBeers, GetBeersBySearch } from '@/beerApiClient.ts';

// Define the Beer interface for TypeScript
interface Beer {
  name: string;
  rating: string;
  image: string;
  description: string;
}

// Reactive state for search query
const searchQuery = ref('');

// Reactive state for beers array
const beers = ref<Beer[]>([]); // Initialize as an empty array

// Reactive state for selected beer (for modal)
const selectedBeer = ref<Beer | null>(null);

const searchBeers = async () => {
  if (searchQuery.value) {
    beers.value = await GetBeersBySearch(searchQuery.value);
  }
};

// Function to open the modal with the selected beer
const openModal = (beer: Beer) => {
  selectedBeer.value = beer;
};

// Function to close the modal
const closeModal = () => {
  selectedBeer.value = null;
};

// Fetch beers on component mount
onMounted(async () => {
  beers.value = await GetBeers();
});
</script>

<style scoped>
.home-view {
  padding: 20px;
}

.search-bar {
  display: flex;
  justify-content: flex-end;
  margin-bottom: 20px;
}

.search-btn {
  background-color: #ffd700;
  border: 1px solid black;
  border-radius: 0px 20px 20px 0px;
  padding: 1%;
}

.search-bar input {
  padding: 8px;
  font-size: 16px;
  width: 15em;
  border: 1px solid black;
  border-radius: 20px 0px 0px 20px;
}

.beer-cards {
  display: grid;
  grid-template-columns: repeat(auto-fill, minmax(150px, 1fr));
  gap: 20px;
}

.beer-card {
  border: 1px solid #ddd;
  border-radius: 8px;
  padding: 10px;
  text-align: center;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  cursor: pointer;
}

.beer-card:hover {
  background-color: #f9f9f9;
}

.beer-image {
  width: 100%;
  height: 100px;
  object-fit: cover;
  border-radius: 4px;
}

.home-view.full-layout {
  width: 100%;
  height: 100%;
  display: flex;
  flex-direction: column;
}
</style>