import { createMemoryHistory, createRouter } from 'vue-router'

import HomeView from './views/HomeView.vue'
import BeersView from './views/RatingsView.vue'
import Beer3DView from './views/Beer3DView.vue'
import { components } from 'vuetify/dist/vuetify.js'

const routes = [
  { path: '/', component: HomeView },
  { path: '/ratings', component: BeersView },
  { path: '/3d', component: Beer3DView },
]

const router = createRouter({
  history: createMemoryHistory(),
  routes,
})

export default router