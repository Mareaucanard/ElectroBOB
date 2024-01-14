import { defineStore } from 'pinia';

interface UserPayloadInterface {
  username: string;
  password: string;
}

interface UserRegisterInterface {
  login: string;
  password: string;
}

export const useAuthStore = defineStore('auth', {
  state: () => ({
    authenticated: false,
    loading: false,
    email: '',
    password: '',
  }),
  actions: {
    async authenticateUser({ username, password }: UserPayloadInterface) {
      const { data, pending }: any = await useFetch('https://dummyjson.com/auth/login', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: {
          username,
          password,
        },
      });
      this.loading = pending;

      if (data.value) {
        this.email = data.value.email;
        this.password = data.value.username;
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
    async registerUser({ login, password}: UserRegisterInterface) {
      const { data, pending }: any = await useFetch('ouiouiouioui', {
        method: 'post',
        headers: { 'Content-Type': 'application/json'},
        body: {
          login,
          password
        },
      });
      this.loading = pending;

      if (data.value) {
        this.email = data.value.email;
        this.password = data.value.username;
        const token = useCookie('token');
        token.value = data?.value?.token;
        this.authenticated = true;
      }
    },
  },
  persist: {
    storage: persistedState.localStorage,
  },
});