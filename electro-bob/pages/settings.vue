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

<style>

.settings {
    width: 550px;
    height: 550px;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: space-evenly;
    background-color: #062F33;
    border-radius: 15px;
}

.label {
    display: flex;
    font-size: 25px;
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
    background-color: #BFDBDE;
    color: #062F33;
    border-radius: 15px;
    width: 150px;
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
}

input[type="checkbox"] {
    accent-color: #062F33;
    background-color: #BFDBDE;
    width: 20px;
    cursor: pointer;
}

.save {
    background-color: #BFDBDE;
    color: #062F33;
    width: 90px;
    border-radius: 15px;
    font-size: 25px;
}

</style>
