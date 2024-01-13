<!-- pages/settings.vue -->
<template>
<div class="base" v-if="$device.isDesktop">
    <div class="settings">
        <h1>SETTINGS</h1>
        <label class="label language">
          LANGUAGE:
          <br>
          <select class="select" v-model="language">
              <option value="cs">Czech</option>
              <option value="de">German</option>
              <option value="en">English</option>
              <option value="es">Spanish</option>
              <option value="fr">Français</option>
              <option value="pt">Portuguese</option>
          </select>
        </label>
        <br>
        <label class="label backlist">
          BLACKLIST:
            <div class="check">
                NSFW <input type="checkbox" v-model="blacklistFlags" value="nsfw">
            </div>
            <div class="check">
                Racist<input type="checkbox" v-model="blacklistFlags" value="racist">
            </div>
            <div class="check">
                Sexist <input type="checkbox" v-model="blacklistFlags" value="sexist">
            </div>
            <div class="check">
                Explicit<input type="checkbox" v-model="blacklistFlags" value="explicit">
            </div>
            <div class="check">
                Religious<input type="checkbox" v-model="blacklistFlags" value="religious">
            </div>
            <div class="check">
                Political<input type="checkbox" v-model="blacklistFlags" value="political">
            </div>
        </label>
        <button class="save" @click="saveSettings">
            <a href="/">SAVE</a>
        </button>
    </div>
</div>
<div class="base" v-else>
    <div class="mobile-settings">
        <h1>SETTINGS</h1>
        <label class="label language">
          LANGUAGE:
          <br>
          <select class="select" v-model="language">
              <option value="cs">Czech</option>
              <option value="de">German</option>
              <option value="en">English</option>
              <option value="es">Spanish</option>
              <option value="fr">Français</option>
              <option value="pt">Portuguese</option>
          </select>
        </label>
        <br>
        <label class="label backlist">
          BLACKLIST:
            <div class="check">
                NSFW <input type="checkbox" v-model="blacklistFlags" value="nsfw">
            </div>
            <div class="check">
                Racist<input type="checkbox" v-model="blacklistFlags" value="racist">
            </div>
            <div class="check">
                Sexist <input type="checkbox" v-model="blacklistFlags" value="sexist">
            </div>
            <div class="check">
                Explicit<input type="checkbox" v-model="blacklistFlags" value="explicit">
            </div>
            <div class="check">
                Religious<input type="checkbox" v-model="blacklistFlags" value="religious">
            </div>
            <div class="check">
                Political<input type="checkbox" v-model="blacklistFlags" value="political">
            </div>
        </label>
        <button class="save" @click="saveSettings">
            <a href="/">SAVE</a>
        </button>
    </div>
</div>
</template>

<script setup>
import { useSettingsStore } from '~/store/settings';

const store = useSettingsStore();

const language = ref(store.language);
const blacklistFlags = ref([...store.blacklistFlags]);

const saveSettings = () => {
  store.setLanguage(language.value);
  store.setBlacklistFlags(blacklistFlags.value);
};
</script>

<style scoped>
.settings {
    width: 550px;
    height: 550px;
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

.select {
    background-color: #062F33;
    color: #BFDBDE;
    border-radius: 15px;
    width: 150px;
    height: 30px;
    text-align: center;
    cursor: pointer;
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

.save {
    background-color: #062F33;
    color: #BFDBDE;
    width: 90px;
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
    height: 550px;
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
