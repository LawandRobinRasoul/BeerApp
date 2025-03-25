<!-- filepath: c:\Users\lawand.rasoul\source\repos\BeerApp\HomeView.vue -->
<template>
    <div class="home-view full-layout">
      <!-- Search Bar -->
      <div class="search-bar">
        <input type="text" v-model="searchQuery" placeholder="Search beers..." />
      </div>
  
      <!-- Beer Cards -->
      <div class="beer-cards">
        <div v-for="beer in filteredBeers" :key="beer.name" class="beer-card">
          <img :src="beer.image" alt="Beer Image" class="beer-image" />
          <h3>{{ beer.name }}</h3>
          <p>Rating: {{ beer.rating }}</p>
        </div>
      </div>
    </div>
  </template>
  
  <script lang="ts">
  import { defineComponent, ref, computed } from "vue";
  
  interface Beer {
    name: string;
    rating: string;
    image: string;
  }
  
export default defineComponent({
    name: "HomeView",
    setup() {
      const searchQuery = ref<string>("");
      const beers = ref<Beer[]>([
        { name: "Lager", rating: "4.5", image: "lager.png" },
        { name: "IPA", rating: "4.7", image: "ipa.png" },
        { name: "Stout", rating: "4.8", image: "stout.png" },
      ]);
  
const filteredBeers = computed(() =>
beers.value.filter((beer) =>
  beer.name.toLowerCase().includes(searchQuery.value.toLowerCase())
)
);

return {
searchQuery,
beers,
filteredBeers,
};
},
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

.search-bar input {
  padding: 8px;
  font-size: 16px;
  width: 200px;
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