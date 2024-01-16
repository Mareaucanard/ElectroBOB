<script setup>
const err = ref('')

const user = ref({
  username: '',
  password: '',
});

const login = async () => {
  if (!user.value.username) {
    err.value = 'a user email is required';
  } else if (!user.value.password) {
    err.value = 'a password is required';
  } else {
    err.value = "email or password is incorrect";
  }
};
</script>

<template>
  <div class="base" v-if="$device.isDesktop">
    <div class="modal">
      <img src="../assets/spotify.png" type="logo">
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
        <p class="err" v-if="err"> {{err}} </p>
        <button @click.prevent="login" class="submit">
          <img src="../assets/dark submit button.png" type="submit" />
        </button>
      </div>
    </div>
  </div>
  <div v-else class="base">
    <div class="mobile-modal">
        <img src="../assets/spotify.png" type="logo">
        <div class="mobile-uform">
          <input
            v-model="user.username"
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
          <p class="err" v-if="err"> {{err}} </p>
          <button @click.prevent="login" class="mobile-submit">
              <img src="../assets/dark submit button.png" type="submit" />
          </button>
        </div>
      </div>
  </div>
</template>

<style scoped>

.base {
    display: flex;
    justify-content: center;
}
.modal {
    width: 550px;
    height: 400px;
    margin-top: 10%;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-evenly;
    background-color: #BFDBDE;
    border-radius: 15px;
    color: #062F33;
}

.uform {
    margin-bottom: -40px;
    height: 220px;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
}

.input {
    width: 319px;
    height: 49px;
    background-color: #062F33;
    border-radius: 15px;
    color: #BFDBDE;
    text-align: center;
    font-size: 25px;
    font-weight: 500;
    outline: none;
}

.err {
  color: #b53029;
  font-size: 20px;
}

.register {
    width: 129px;
    height: 38px;
    margin-left: 400px;
    margin-bottom: -10px;
    background-color: #BFDBDE;
    border-radius: 15px;
    color: #062F33;
    text-align: center;
    font-size: 25px;
    font-weight: 500;
}

h1 {
    color: #BFDBDE;
    font-size: 45px;
}

img[type="logo"]{
    width: 130px;
    margin-top: -150px;
}

.submit {
    width: 65px;
}

img[type=submit] {
    width: 65px;
}

/* CSS FOR MOBILE*/

.mobile-modal {
    width: 340px;
    height: 400px;
    margin-top: 25%;
    display: flex;
    justify-content: space-evenly;
    align-items: center;
    flex-direction: column;
    background-color: #BFDBDE;
    border-radius: 15px;
    color: #062F33;
}

.mobile-uform {
    margin-bottom: -40px;
    height: 240px;
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    align-items: center;
}

.mobile-input {
    width: 210px;
    height: 49px;
    background-color: #062F33;
    border-radius: 15px;
    color: #BFDBDE;
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
