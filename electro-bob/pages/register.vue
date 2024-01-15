<script setup>
import { storeToRefs } from 'pinia';
import { useAuthStore } from '../store/auth';

definePageMeta({
        layout: false
    })

const { registerUser } = useAuthStore();
const { authenticated } = storeToRefs(useAuthStore());

const err = ref('')

const user = ref({
    login: '',
    password: '',
    confirm: ''
});

const register = async () => {
    if (!user.value.login) {
        err.value = 'a user email is required';
    } else if (!user.value.password) {
        err.value = 'a password is required';
    } else if (user.value.password !== user.value.confirm) {
        err.value = 'passwords are not identical'
    } else {
        err.value = "";
    }
    await registerUser(user.value);
};
</script>

<template>
    <div class="background" v-if="$device.isDesktop">
        <div class="base">
            <div class="modal">
                <img src="../assets/ElectroBob 1.png" type="logo">
                <h1>REGISTER</h1>
                <div class="uform">
                    <input
                      v-model="user.login"
                      type="text"
                      class="input"
                      placeholder="user email"
                      name="uname"
                      required
                    />
                    <input
                      v-model="user.password"
                      type="password"
                      class="input"
                      placeholder="user password"
                      name="psw"
                      required
                    />
                    <input
                      v-model="user.confirm"
                      type="password"
                      class="input"
                      placeholder="confirm password"
                      name="psw"
                      required
                    />
                    <p class="err" v-if="err"> {{err}} </p>
                    <button @click.prevent="register" class="submit">
                        <img src="../assets/submit button.png" type="submit" />
                    </button>
                </div>
            </div>
        </div>
    </div>
    <div v-else class="background">
        <div class="base">
            <div class="mobile-modal">
                <img src="../assets/ElectroBob 1.png" type="logo">
                <h1>REGISTER</h1>
                <div class="mobile-uform">
                  <input
                    v-model="user.login"
                    type="text"
                    class="mobile-input"
                    placeholder="user email"
                    name="uname"
                    required
                  />
                  <input
                    v-model="user.password"
                    type="password"
                    class="mobile-input"
                    placeholder="user password"
                    name="psw"
                    required
                  />
                  <input
                      v-model="user.confirm"
                      type="password"
                      class="mobile-input"
                      placeholder="confirm password"
                      name="psw"
                      required
                    />
                  <p class="err" v-if="err"> {{err}} </p>
                  <button @click.prevent="register" class="mobile-submit">
                      <img src="../assets/submit button.png" type="submit" />
                  </button>
                </div>
                <a class="mobile-register" href="/register">register</a>
            </div>
        </div>
    </div>
</template>

<style>
body {
    font-family:'LeagueSpartan';
    font-size: 30px;
  }

.background {
    background-color: #BFDBDE;
    height: 100vh;
    margin-top: 0px;
    display: flex;
    justify-content: center;
    align-items: center;
}

.base {
    display: flex;
    justify-content: center;
    align-items: center;
    align-self: center;
}

.modal {
    width: 570px;
    height: 559px;
    display: flex;
    justify-content: space-evenly;
    align-items: center;
    flex-direction: column;
    background-color: #062F33;
    border-radius: 15px;
}

.uform {
    height: 320px;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
}

.input {
    width: 319px;
    height: 49px;
    background-color: #BFDBDE;
    border-radius: 15px;
    color: #062F33;
    text-align: center;
    font-size: 25px;
    font-weight: 500;
    outline: none;
}

.err {
    color: #b53029;
    font-size: 20px;
}

h1 {
    color: #BFDBDE;
    font-size: 45px;
}

img[type="logo"] {
    width: 130px;
    margin-top: -80px;
}

.submit {
    width: 65px;
}

img[type=submit] {
    width: 65px;
}

/* CSS FOR MOBILE*/

.mobile-modal {
    width: 338px;
    height: 542px;
    display: flex;
    justify-content: space-evenly;
    align-items: center;
    flex-direction: column;
    background-color: #062f337c;
    border-radius: 15px;
}

.mobile-uform {
    margin-bottom: -40px;
    height: 300px;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
}

.mobile-input {
    width: 230px;
    height: 49px;
    background-color: #BFDBDE;
    border-radius: 15px;
    color: #062F33;
    text-align: center;
    font-size: 25px;
    font-weight: 500;
    outline: none;
}

.mobile-submit {
    width: 66px;
    height: 68px;
}


.mobile-register {
    width: 129px;
    height: 38px;
    margin-left: 200px;
    margin-bottom: -35px;
    background-color: #BFDBDE;
    border-radius: 15px;
    color: #062F33;
    text-align: center;
    font-size: 25px;
    font-weight: 500;
}
</style>
