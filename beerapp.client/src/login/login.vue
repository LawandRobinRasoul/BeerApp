<template>
  <div>
    <button @click="login">Log in</button>
  </div>
</template>

<script setup lang="ts">
  import { useAuth0 } from '@auth0/auth0-vue';

    const auth0 = useAuth0();

    const login = () => {
      auth0.loginWithRedirect({
  authorizationParams: {
    audience: 'https://dev-konzewxurlz5v74y.us.auth0.com/api/v2/',
    scope: 'read:users',
  },
});
    };
</script>