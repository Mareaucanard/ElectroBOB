<script setup>
import { storeToRefs } from 'pinia'; // import storeToRefs helper hook from pinia
import { useAuthStore } from '../store/auth'; // import the auth store we just created

definePageMeta({
        layout: false
    })

const user = ref({
    email: '',
    password: '',
    confirm: ''
});

const validate = (user) => {
    const errors = []
    if (!user.email) errors.push({ path: 'email', message: 'Required' })
    if (!user.password) errors.push({ path: 'password', message: 'Required' })
    if (user.password != user.confirm) errors.push({ path: 'confirm', message: 'Does not match' })
    return errors
}

async function onSubmit(event) {
    const { email, password } = event.data
    const API_URL = "http://localhost:8080/api/Register"
    try {
        const response = await useFetch('https://dummyjson.com/users/add', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify({
            firstName: 'Muhammad',
            lastName: 'Ovi',
            age: 250,
          })
        })
        .then(res => res.json())
        .then(console.log);
    } catch (e) {
        console.error(e)
    }
}

const register = async () => {
    const API_URL = "http://localhost:8080/api/Register"
    try {
        const response = await useFetch('https://dummyjson.com/users/add', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify({
            firstName: 'Muhammad',
            lastName: 'Ovi',
            age: 250,
          })
        })
        .then(res => res.json())
        .then(console.log);
    } catch (e) {
        console.error(e)
    }
}
</script>

<template>
    <div class="hello" v-if="$device.isDesktop">
        <div class="modal">
            <img src="../assets/ElectroBob 1.png" type="logo">
            <h1>REGISTER</h1>
            <div class="uform">
                <input
                  v-model="user.username"
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

                <button @click.prevent="register" class="submit">
                    <img src="../assets/submit button.png" type="submit" />
                </button>
            </div>
        </div>
    </div>
    <div class="hello" v-else>
        <div class="mobile-modal">
            <img src="../assets/ElectroBob 1.png" type="logo">
            <h1>LOGIN</h1>
            <UForm :ui="{ label: {} }" :validate="validate" :state="state" class="space-y-4 uform" @submit="onSubmit">
                <UFormGroup name="email">
                    <input v-model="state.email" placeholder="user email" class="mobile-input" />
                </UFormGroup>

                <UFormGroup name="password">
                    <input v-model="state.password" type="password" placeholder="user password" class="mobile-input" />
                </UFormGroup>

                <UFormGroup name="confirm">
                    <input v-model="state.confirm" type="password" placeholder="confirm password" class="mobile-input" />
                </UFormGroup>

                <UButton type="submit" class="mobile-submit" variant="link">
                    <img src="../assets/submit button.png" type="mobile-submit" />
                </UButton>
            </UForm>
        </div>
    </div>
</template>

<style>
.hello {
    display: flex;
    justify-content: center;
    align-items: center;
    align-self: center;
    margin-top: 200px;
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
    background-color: white;
    border-radius: 15px;
    color: black;
    text-align: center;
    font-size: 25px;
    font-weight: 500;
    outline: none;
}

h1 {
    color: white;
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

.mobile-input {
    width: 210px;
    height: 49px;
    background-color: white;
    border-radius: 15px;
    color: black;
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
    background-color: white;
    border-radius: 15px;
    color: black;
    text-align: center;
    font-size: 25px;
    font-weight: 500;
}
</style>
