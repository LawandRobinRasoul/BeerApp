import { createMemoryHistory, createRouter } from 'vue-router'

import HomeView from './views/HomeView.vue'
import BeersView from './views/RatingsView.vue'

const routes = [
  { path: '/', component: HomeView },
  { path: '/ratings', component: BeersView },
]

const router = createRouter({
  history: createMemoryHistory(),
  routes,
})

export default router