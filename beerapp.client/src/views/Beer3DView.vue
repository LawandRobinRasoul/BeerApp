<template>
    <h1>3D Beer View</h1>
    <div id="scene-container">
     <!-- Three.js canvas will be inserted here -->
</div>
</template>

<script setup lang="ts">

import { World } from "../components/three/world.ts";

import { onMounted } from "vue";

onMounted(() => {
    const container = document.querySelector("#scene-container");
    if (container) {
        const world = new World(container);
    } else {
        console.error("Scene container not found");
    }
});

</script>