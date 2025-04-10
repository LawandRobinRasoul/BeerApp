<template>
  <v-app>
    <!-- Navbar (App Bar) -->
    <v-app-bar app>
      <v-app-bar-nav-icon @click="drawer = !drawer">
        <div class="burger-icon">
          <span></span>
          <span></span>
          <span></span>
        </div>
      </v-app-bar-nav-icon>
      <v-toolbar-title>Beer Review</v-toolbar-title>
    </v-app-bar>

    <!-- Sidebar (Navigation Drawer) -->
    <v-navigation-drawer v-model="drawer" app :temporary="isSmallScreen">
      <v-list>
        <v-list-item title="Home" :to="'/'"></v-list-item>
        <v-list-item title="My Ratings" :to="'/ratings'"></v-list-item>
        <v-list-item title="Watch 3D" :to="'/3d'"></v-list-item>
      </v-list>
    </v-navigation-drawer>

    <!-- Main Content -->
    <v-main class="full-layout">
      <RouterView />
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import { ref } from 'vue';
import { useDisplay } from 'vuetify';

const drawer = ref(true);
const { smAndDown } = useDisplay();
const isSmallScreen = smAndDown;
</script>

<style scoped>
/* Navbar styles */
.v-app-bar {
  background-color: #00274d !important; /* Dark blue */
  color: #ffd700 !important; /* Gold */
  font-weight: bold;
}

/* Toggle button styles */
.v-app-bar-nav-icon {
  display: flex;
  align-items: center;
  justify-content: center;
  background-color: #003366 !important; /* Darker blue for contrast */
  border: 2px solid #ffd700 !important; /* Gold border for visibility */
  border-radius: 50%; /* Circular button */
  width: 40px;
  height: 40px;
  padding: 0; /* Remove default padding */
}

/* Burger menu icon styles */
.burger-icon {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  width: 20px;
  height: 16px;
}

.burger-icon span {
  display: block;
  height: 2px;
  background-color: #ffd700; /* Gold */
  border-radius: 1px;
}

/* Sidebar styles */
.v-navigation-drawer {
  background-color: #001f3f; /* Slightly darker blue */
  color: #ffd700; /* Gold */
}

/* Sidebar list item styles */
.v-list-item {
  color: #ffd700; /* Gold */
}

.v-list-item:hover {
  background-color: #003366; /* Hover effect with a lighter blue */
}
</style>


