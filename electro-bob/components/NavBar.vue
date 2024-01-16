<script setup>
const isOpen = ref(false)
</script>

<template>
    <nav v-if="$device.isDesktop">
        <div class="start-bar">
            <UButton class="UButton" to="/user" :ui="{ rounded: 'rounded-full' }" type="icon">
                <img src="../assets/profile.png" type="icon">
            </UButton>
            <div class="line"/>
            <UButton class="UButton" to="/settings" :ui="{ rounded: 'rounded-full' }" type="icon">
                <img src="../assets/parameter.png" type="icon">
            </UButton>
            <div class="line"/>
            <UButton class="UButton" to="/spotify" :ui="{ rounded: 'rounded-2xl' }">spotify</UButton>
            <div class="line"/>
            <UButton class="UButton" to="/messages" :ui="{ rounded: 'rounded-2xl' }">message</UButton>
            <div class="line"/>
        </div>
        <div class="logo">
                <img src="../assets/ElectroBob 1.png" type="logo button">
        </div>
        <div class="start-bar">
            <div class="line"/>
            <UButton class="UButton" to="/login" :ui="{ rounded: 'rounded-2xl' }" >services</UButton>
            <div class="line"/>
            <UButton class="UButton" to="/login" :ui="{ rounded: 'rounded-2xl' }">automate</UButton>
            <div class="line"/>
            <UButton class="UButton" to="/help" :ui="{ rounded: 'rounded-2xl' }" type="help">help</UButton>
        </div>
    </nav>
    <div class="mobile-nav" v-if="$device.isMobile">
        <button @click="isOpen = true" class="toggel-button">
            <img src="../assets/ElectroBob 1.png" type="toggel-button">
        </button>
        <USlideover class="slider h-2/3 rounded-br-2xl" v-model="isOpen" :overlay="false" :side="left">
          <div class="slider-button">
                <button @click="isOpen = false" class="inside-toggel-button">
                  <img src="../assets/ElectroBob 1.png" type="">
                </button>
                <UButton class="UButton" to="/user" :ui="{ rounded: 'rounded-full' }" type="icon">
                    <img src="../assets/profile.png" type="icon">
                </UButton>
                <UButton class="UButton" to="/settings" :ui="{ rounded: 'rounded-full' }" type="icon">
                    <img src="../assets/parameter.png" type="icon">
                </UButton>
                <UButton class="UButton" to="/spotify" :ui="{ rounded: 'rounded-full' }" type="icon">
                    <img src="../assets/groups.png" type="icon">
                </UButton>
                <UButton class="UButton" to="/messages" :ui="{ rounded: 'rounded-full' }" type="icon">
                    <img src="../assets/messages.png" type="icon">
                </UButton>
                <UButton class="UButton" to="/login" :ui="{ rounded: 'rounded-full' }" type="icon">
                    <img src="../assets/services.png" type="icon">
                </UButton>
                <UButton class="UButton" to="/login" :ui="{ rounded: 'rounded-full' }" type="icon">
                    <img src="../assets/automate.png" type="icon">
                </UButton>
                <UButton class="UButton" to="/help" :ui="{ rounded: 'rounded-full' }" type="icon">
                    <img src="../assets/help.png" type="icon">
                </UButton>
          </div>
        </USlideover>
    </div>
</template>

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

/* CSS FOR MOBILE*/

.mobile-nav {
    width: 100%;
    display: flex;
}

.slider {
    width: 80px;
    background-color: #bfdbde9b;
}

.slider-button {
    display: flex;
    flex-direction: column;
    justify-content: space-evenly;
    align-items: center;
    height: 100%;
}

.toggel-button{
    width: 57px;
    margin-top: 13px;
    margin-left: 12px;
}

.inside-toggel-button {
    width: 57px;
}

img[type="toggel-button"] {
    width: 57px;
    margin-top: 15px;
}

</style>
