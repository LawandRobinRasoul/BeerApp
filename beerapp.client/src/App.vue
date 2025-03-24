<template>
  <v-app>
    <!-- Navbar (App Bar) -->
    <v-app-bar app>
      <v-toolbar-title>Beer Review</v-toolbar-title>
    </v-app-bar>

    <!-- Sidebar (Navigation Drawer) -->
    <v-navigation-drawer v-model="drawer" app>
      <v-list>
        <v-list-item title="Home" :to="'/'"></v-list-item>
        <v-list-item title="Beers" :to="'/beers'"></v-list-item>
        <v-list-item title="Favorites" :to="'/favorites'"></v-list-item>
      </v-list>
    </v-navigation-drawer>

    <!-- Main Content -->
    <v-main>
      <h1>popo</h1>
      <RouterView />
    </v-main>
  </v-app>
</template>

<script setup lang="ts">
import { ref } from 'vue';

const drawer = ref(true);
</script>

<style scoped>
/* Add styles if needed */
</style>


