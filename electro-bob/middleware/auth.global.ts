import { storeToRefs } from 'pinia';
import { useAuthStore } from '~/store/auth';

export default defineNuxtRouteMiddleware((to) => {
  console.log('From auth middleware')
  const { authenticated } = storeToRefs(useAuthStore());
  const token = useCookie('token');

  if (token.value) {
    authenticated.value = true;
  }

  if (to?.name === 'register') {
    return;
  }

  if (authenticated.value = true) {
    console.log("you are gay")
  }

  if (token.value && to?.name === 'login') {
    return navigateTo('/');
  }

  if (!token.value && to?.name !== 'login') {
    abortNavigation();
    return navigateTo('/login');
  }
});
