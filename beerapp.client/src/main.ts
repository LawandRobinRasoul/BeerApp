import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'

// Import Vuetify and its styles
import { createVuetify } from 'vuetify'
import 'vuetify/styles'

// Import Vuetify components (fix for missing component errors)
import * as components from 'vuetify/components'
import * as directives from 'vuetify/directives'

const vuetify = createVuetify({
  components,
  directives
})

createApp(App)
  .use(router)
  .use(vuetify)
  .mount('#app')
