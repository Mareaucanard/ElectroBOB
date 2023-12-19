<template>
    <nav v-if="$device.isDesktop">
        <div class="start-bar">
            <UButton class="UButton" to="/login" :ui="{ rounded: 'rounded-full' }" type="icon">
                <img src="../assets/profile.png" type="icon">
            </UButton>
            <div class="line"/>
            <UButton class="UButton" to="/login" :ui="{ rounded: 'rounded-full' }" type="icon">
                <img src="../assets/parameter.png" type="icon">
            </UButton>
            <div class="line"/>
            <UButton class="UButton" to="/login" :ui="{ rounded: 'rounded-2xl' }">groups</UButton>
            <div class="line"/>
            <UButton class="UButton" to="/login" :ui="{ rounded: 'rounded-2xl' }">message</UButton>
            <div class="line"/>
        </div>
        <div class="logo">
            <button>
                <img src="../assets/ElectroBob 1.png" type="logo button">
            </button>
        </div>
        <div class="start-bar">
            <div class="line"/>
            <UButton class="UButton" to="/login" :ui="{ rounded: 'rounded-2xl' }" >services</UButton>
            <div class="line"/>
            <UButton class="UButton" to="/login" :ui="{ rounded: 'rounded-2xl' }">automate</UButton>
            <div class="line"/>
            <UButton class="UButton" to="/login" :ui="{ rounded: 'rounded-2xl' }" type="help">help</UButton>
        </div>
    </nav>
    <nav v-else>
        <h1>HELLO THIS IS APP</h1>
    </nav>
</template>

<script setup>
</script>

<style>
nav {
    height: 60px;
    background-color: #BFDBDE;
    display: flex;
    justify-content: space-evenly;
    align-items: center;
}

.start-bar {
    display: flex;
    justify-content: space-evenly;
    align-items: center;
    flex-direction: row;
    flex: 2;
}

.logo {
    display: flex;
    justify-content: center;
    flex: 1;
}

.UButton {
    height: 48px;
    font-size: 28px;
    font-weight: 700;
    align-items: center;
    width: 188px;
    justify-content: center;
}

.UButton[type="help"] {
    width: 119px;
}

.UButton[type="icon"] {
    width: 48px;
    height: 48px;
}

img[type="logo button"]{
    width: 130px;
    margin-top: 50px;
}

.line {
    height: 49px;
    width: 2px;
    background-color: #7A9597;
}

</style>
