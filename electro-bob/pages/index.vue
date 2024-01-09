
<template>
    <div v-if="$device.isDesktop" class="base">
        <svg width="466" height="51" viewBox="0 0 466 51" fill="none" xmlns="http://www.w3.org/2000/svg">
            <path d="M0.5 51C76.6202 51 227.991 41.0318 231.44 1.38656C231.426 0.913066 231.447 0.450564 231.5 0C231.5 0.466173 231.48 0.928351 231.44 1.38656C231.942 18.7784 278.699 51 466 51H0.5Z" fill="#BFDBDE"/>
          </svg>
        <div class="joke">
            <div v-if="getPartJoke() != 0">
                <h2 v-if="joke.length === 2"> {{ joke[0] }} <br><br><br> {{joke[1]}}</h2>
            </div>
            <div v-if="getPartJoke() != 0">
                <h2 v-if="joke.length === 1"> {{joke}}</h2>
            </div>
        </div>
    </div>
    <div v-else class="base">
        <svg width="466" height="51" viewBox="0 0 466 51" fill="none" xmlns="http://www.w3.org/2000/svg">
            <path d="M0.5 51C76.6202 51 227.991 41.0318 231.44 1.38656C231.426 0.913066 231.447 0.450564 231.5 0C231.5 0.466173 231.48 0.928351 231.44 1.38656C231.942 18.7784 278.699 51 466 51H0.5Z" fill="#BFDBDE"/>
          </svg>
        <div class="joke">
            <div v-if="getPartJoke() != 0">
                <h2 v-if="joke.length === 2"> {{ joke[0] }} <br><br><br> {{joke[1]}}</h2>
            </div>
            <div v-if="getPartJoke() != 0">
                <h2 v-if="joke.length === 1"> {{joke}}</h2>
            </div>
        </div>
    </div>
</template>

<script setup>
import { useSettingsStore } from '~/store/settings';

const store = useSettingsStore();

const result = ref('');
const joke = ref([]);
const url = `https://v2.jokeapi.dev/joke/Any?lang=${store.language}&blacklistFlags=${store.blacklistFlags.join(',')}`;;
const options = {
	method: 'GET',
};

try {
	const response = await fetch(url, options);
	result.value = await response.json();
    console.log(result.value)
} catch (error) {
    console.error(error);
}

function getPartJoke() {
    if (result.value.type === 'twopart') {
        console.log(result.value.setup);
        const fisrt = result.value.setup;
        const delivery = result.value.delivery;
        joke.value = [fisrt,delivery]
    } else {
        joke.value = result.value.joke;
    }
    return joke;
}
</script>

<style>
.base {
    margin-top: 60px;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

.joke {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 540px;
    height: 250px;
    flex-shrink: 0;
    border-radius: 25px;
    background: #BFDBDE;
}

.bob {
    width: 250px;
    margin-top: 150px;
}

.bubble {
    clip-path: polygon(0% 0%, 100% 0%, 100% 75%, 34% 75%, 0 89%, 14% 75%, 0% 75%);
    background-color: #BFDBDE;
    width: 280px;
    height: 220px;
}

h2 {
    color: #062F33;
}
</style>
