<template>
    <div v-if="$device.isDesktop">
        <form class="automate-page">
            <div class="tag">
                <input v-model="automate.tag"
                type="text"
                class="input"
                placeholder="Automation tag"
                name="uname"
                required/>
                <button @click.prevent="sendAutomate" class="submit">
                    <img src="../assets/submit button.png" type="submit" />
                </button>
            </div>
            <div class="recipient">
                <p>Action:</p>
                <select class="select" v-model="automate.action">
                    <option value="" disabled selected>Action name</option>
                    <option value="mail">send mail</option>
                    <option value="time">trigger clock</option>
                    <option value="music">search artiste</option>
                </select>
            </div>
            <div class="object">
                <p>Reaction:</p>
                <select class="reaction-select" v-model="automate.reaction">
                    <option value="" disabled selected>Reaction name</option>
                    <option value="mail">get notification</option>
                    <option value="time">get time</option>
                </select>
            </div>
        </form>
    </div>
    <div v-else>
        <form class="automate-page">
            <div class="mobile-tag">
                <input v-model="automate.tag"
                type="text"
                class="mobile-input"
                placeholder="Automation tag"
                name="uname"
                required/>
                <button @click.prevent="sendAutomate" class="mobile-submit">
                    <img src="../assets/submit button.png" class="mobile-submit" />
                </button>
            </div>
            <div class="mobile-recipient">
                <p class="mobile-font">Action:</p>
                <select class="mobile-select" v-model="automate.action">
                    <option value="" disabled selected>Action name</option>
                    <option value="mail">send mail</option>
                    <option value="time">trigger clock</option>
                    <option value="music">search artiste</option>
                </select>
            </div>
            <div class="mobile-object">
                <p class="mobile-font">Reaction:</p>
                <select class="mobile-reaction-select" v-model="automate.reaction">
                    <option value="" disabled selected>Reaction name</option>
                    <option value="mail">get notification</option>
                    <option value="time">get time</option>
                </select>
            </div>
        </form>
    </div>
</template>

<script setup>
const automate = ref({
    tag: '',
    action: '',
    reaction: '',
    message: '',
})

const sendAutomate = async () => {}

</script>

<style scoped>

.automate-page {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    margin-top: 5%;
}

.recipient {
    margin-top: 20px;
    display: flex;
    justify-content: space-around;
}

p {
    font-size: 30px;
}
.tag {
    width: 1314px;
    display: flex;
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
}
.input {
    width: 1230px;
    height: 58px;
    font-size: 30px;
}

.input::placeholder {
    opacity: 40%;
}
.object {
    font-size: 30px;
    height: 100vh;
    display: flex;
    justify-content: space-around;
}

.select {
    width: 950px;
    height: 65px;
    background-color: #BFDBDE;
    border-top-right-radius: 15px;
    border-top-left-radius: 15px;
    margin-top: 10px;
    color: #062f3390;
    font-weight: 600;
    text-indent: 2%;
}

.reaction-select {
    width: 950px;
    height: 70px;
    background-color: #BFDBDE;
    border-radius: 15px;
    margin-top: 10px;
    margin-left: -30px;
    color: #062f3390;
    font-weight: 600;
    text-indent: 2%;
}

/* CSS FOR MOBILE*/

.mobile-tag {
    margin-top: 30%;
    width: 100%;
    display: flex;
    flex-direction: row;
    justify-content: space-around;
    align-items: center;
}

.mobile-input {
    width: 70%;
    height: 58px;
    font-size: 30px;
    background-color: #BFDBDE;
    border-radius: 15px;
    color: #062f33;
    text-align: center;
}

.mobile-font {
    font-size: 20px;
}

.mobile-input::placeholder {
    opacity: 40%;
}

.mobile-submit {
    height: 58px;
}

.mobile-recipient {
    border-top-right-radius: 0%;
    justify-content: space-around;
}

.mobile-select {
    width: 280px;
    height: 45px;
    background-color: #BFDBDE;
    border-top-right-radius: 15px;
    border-top-left-radius: 15px;
    margin-top: 10px;
    color: #062f3390;
    font-weight: 600;
    font-size: 20px;
    text-indent: 2%;
}

.mobile-object {
    font-size: 30px;
    height: 100vh;
    display: flex;
    justify-content: space-evenly;
    border-top-right-radius: 0%;
    margin-top: -45px;
}

.mobile-reaction-select {
    width: 280px;
    height: 50px;
    background-color: #BFDBDE;
    border-radius: 15px;
    margin-top: 10px;
    color: #062f3390;
    font-size: 20px;
    font-weight: 600;
    text-indent: 2%;
}

</style>