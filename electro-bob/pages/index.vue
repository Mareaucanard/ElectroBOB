
<template>
    <div id="container">
        <div class="buttonWrapper">
            <div class="base">
                <h1>WELCOME</h1>
                <h2> {{result}} </h2>
            </div>
        </div>
    </div>
</template>

<script lang="ts" setup>
const result = ref('');
const url = 'https://v2.jokeapi.dev/joke/Any?format=txt&lang=fr&blacklistFlags=nsfw';
const options = {
	method: 'GET',
};

try {
	const response = await fetch(url, options);
	result.value = await response.text();
	console.log(result);
} catch (error) {
	console.error(error);
}
</script>

<style>
.buttonWrapper {
    margin-top: 100px;
    display: flex;
    justify-content: center;
}

.spacing {
    height: 20px;
}

.base {
    flex-direction: column;
    display: flex;
    width: 100px;
    align-items: center;
}
</style>
