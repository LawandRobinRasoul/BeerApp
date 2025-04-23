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

import { createAuth0 } from '@auth0/auth0-vue';

const vuetify = createVuetify({
  components,
  directives
})

createApp(App)
  .use(createAuth0({
    domain: import.meta.env.VITE_Domain,
    clientId: import.meta.env.VITE_ClientId,
    authorizationParams: {
      redirect_uri: window.location.origin
    }
  }))
  .use(router)
  .use(vuetify)
  .mount('#app')

