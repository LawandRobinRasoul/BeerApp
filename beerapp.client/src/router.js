import { createMemoryHistory, createRouter } from 'vue-router'

import HomeView from './views/HomeView.vue'
import BeersView from './views/BeersView.vue'

const routes = [
  { path: '/', component: HomeView },
  { path: '/beers', component: BeersView }
]

const router = createRouter({
  history: createMemoryHistory(),
  routes,
})

export default router