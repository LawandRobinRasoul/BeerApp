<template>
    <div v-if="isLoading">Loading ...</div>
    <div v-else>
      <h2>User Profile</h2>
      <button @click="login">Log in</button>
      <pre v-if="isAuthenticated">
          <code>{{ user }}</code>
        </pre>
    </div>
  </template>
  <script>
    // Composition API
    import { useAuth0 } from '@auth0/auth0-vue';
  
    export default {
      setup() {
        const auth0 = useAuth0();
  
        return {
          login: () => auth0.loginWithRedirect({
  authorizationParams: {
    audience: 'https://dev-konzewxurlz5v74y.us.auth0.com/api/v2/',
    scope: 'read:users',
  },
}),
          user: auth0.user,
          isAuthenticated: auth0.isAuthenticated,
          isLoading: auth0.isLoading,
        };
      }
    };

  </script>