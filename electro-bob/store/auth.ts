import { defineStore } from 'pinia';

interface UserPayloadInterface {
  login: string;
  password: string;
}

export const useAuthStore = defineStore('auth', {
  state: () => ({
    authenticated: false,
    loading: false,
  }),
  actions: {
    async authenticateUser({ login, password }: UserPayloadInterface) {
      const { data, pending }: any = await useFetch('https://localhost:32774/api/connexion', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: {
          login,
          password,
        },
      });
      this.loading = pending;

      if (data.value) {
        const token = useCookie('token');
        token.value = data?.value?.token;
        this.authenticated = true;
      }
    },
    logUserOut() {
      const token = useCookie('token');
      this.authenticated = false;
      token.value = null;
    },
  },
});