<!-- pages/settings.vue -->
<template>
    <div class="base" v-if="$device.isDesktop">
        <div class="settings">
            <h1>USER</h1>
            <label class="label language">
              EMAIL:
              <br>
              <h2 class="email">
                {{email}}
              </h2>
            </label>
            <br>
            <label class="label language">
              PASSWORD:
                <button class="password" @click="toggleContent">
                    <div v-show="isContentVisible">
                        {{ password }}
                    </div>
                    <div v-show="!isContentVisible">
                        #######
                    </div>
                </button>
            </label>
            <button class="logout" @click="logout">
                LOGOUT
            </button>
        </div>
    </div>
    <div class="base" v-else>
        <div class="mobile-settings">
            <h1>USER</h1>
            <label class="label language">
              EMAIL:
              <br>
              <h2 class="email">
                {{email}}
              </h2>
            </label>
            <br>
            <label class="label language">
              PASSWORD:
                <button class="password" @click="toggleContent">
                    <div v-show="isContentVisible">
                        {{ password }}
                    </div>
                    <div v-show="!isContentVisible">
                        #######
                    </div>
                </button>
            </label>
            <button class="logout" @click="logout">
                LOGOUT
            </button>
        </div>
    </div>
</template>

<script setup>
import { useAuthStore } from '../store/auth';

const router = useRouter();

const store = useAuthStore();
const email = store.email;
const password = store.password;

const isContentVisible = ref(false);

const toggleContent = () => {
  isContentVisible.value = !isContentVisible.value;
};
const { logUserOut } = useAuthStore();

const logout = () => {
  logUserOut();
  router.push('/login');
};
</script>

<style scoped>
.settings {
    width: 350px;
    height: 420px;
    margin-top: 5%;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-evenly;
    background-color: #BFDBDE;
    border-radius: 15px;
    color: #062F33;
}

h1 {
    font-family:'LeagueSpartan';
    font-weight: 600;
    color: #062F33;
    font-size: 45px;
}

.label {
    display: flex;
    font-size: 25px;
    font-weight: 600;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
}

.language {
    height: 80px;
}

.backlist {
    width: 250px;
    height: 250px;
    justify-content: space-between;
}

.email {
    background-color: #062F33;
    color: #BFDBDE;
    border-radius: 15px;
    width: 300px;
    height: 30px;
    text-align: center;
    font-size: 20px;
}

.password {
    background-color: #062F33;
    color: #BFDBDE;
    border-radius: 15px;
    width: 250px;
    height: 30px;
    text-align: center;
    font-size: 20px;
}

.check {
    width: 200px;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    font-size: 20px;
    font-weight: 500;
}

input[type="checkbox"] {
    accent-color: #062F33;
    background-color: #BFDBDE;
    width: 20px;
    cursor: pointer;
}

.logout {
    background-color: #062F33;
    color: #BFDBDE;
    width: 120px;
    border-radius: 15px;
    font-size: 25px;
}

.base {
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
}
.mobile-settings {
    width: 340px;
    height: 450px;
    margin-top: 20%;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-evenly;
    background-color: #BFDBDE;
    border-radius: 15px;
    color: #062F33;
}

</style>
