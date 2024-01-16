<template>
    <div v-if="$device.isDesktop" class="base desktop">
        <img src="../assets/ElectroBob-shadow.png" class="welcome">
        <h2>WELCOME TO</h2>
        <h1>ELECTRO-BOB</h1>
    </div>
    <div v-else class="base mobile">
        <img src="../assets/ElectroBob-shadow.png" class="welcome">
        <h2>WELCOME TO</h2>
        <h1>ELECTRO-BOB</h1>
    </div>
</template>
<script setup>
</script>

<style scoped>
.base {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.mobile {
    margin-top: 70%;
}

.desktop {
    margin-top: 10%;
}

h2 {
    font-size: 35px;
    color: #BFDBDE;
}

h1 {
    font-size: 45px;
    color: #BFDBDE;
}

.welcome {
    width: 200px;
}

</style>
