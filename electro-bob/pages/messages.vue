<script setup>
const state = reactive({
    recipient: undefined,
    object: undefined,
    message: undefined
})

const validate = (state) => {
    const errors = []
    if (!state.recipient) errors.push({ path: 'recipient', message: 'Required' })
    if (!state.object) errors.push({ path: 'object', message: 'Required' })
    if (!state.message) errors.push({ path: 'message', message: 'Required' })
    return errors
}

async function onSubmit(event) {
    console.log(event.data)
}
</script>

<template>
    <ion-page v-if="$device.isDesktop">
        <ion-content :fullscreen="true">
            <NavBar/>
            <UForm class="message-page" :validate="validate" :state="state" @submit="onSubmit">
                <div class="recipient">
                    <p>New message to:</p>
                    <div class="underline-input">
                        <input v-model="state.recipient" class="recipient-input">
                        <div class="underline"/>
                    </div>
                </div>
                <div class="object">
                    <p>Object:</p>
                    <div class="underline-input">
                        <input v-model="state.object" class="object-input">
                        <div class="underline"/>
                    </div>
                </div>
                <div class="message">
                    <textarea v-model="state.message" class="message-input" placeholder="Write here"/>
                </div>
            </UForm>
        </ion-content>
    </ion-page>
    <ion-page v-else>
        <ion-content :fullscreen="true">
            <NavBar/>
            <UForm class="message-page" :validate="validate" :state="state" @submit="onSubmit">
                <div class="mobile-recipient">
                    <p>To:</p>
                    <div class="mobile-underline-input">
                        <input v-model="state.recipient" class="mobile-recipient-input">
                        <div class="mobile-underline"/>
                    </div>
                </div>
                <div class="mobile-object">
                    <p>Object:</p>
                    <div class="mobile-underline-input">
                        <input v-model="state.object" class="mobile-object-input">
                        <div class="mobile-underline"/>
                    </div>
                </div>
                <div class="mobile-message">
                    <textarea v-model="state.message" class="mobile-message-input" placeholder="Write here"/>
                </div>
            </UForm>
        </ion-content>
    </ion-page>
</template>

<style>
.message-page {
    background-color: #062F33;
    width: 100%;
    height: 100%;
    display: flex;
    flex-direction: column;
    align-items: center;
}

.recipient {
    display: flex;
    justify-content: space-between;
    background-color: #7A9597;
    width: 1314px;
    height: 97px;
    margin-top: 100px;
    border-radius: 15px;
}

.object {
    display: flex;
    justify-content: space-between;
    background-color: #9DB8BB;
    width: 1314px;
    height: 97px;
    border-radius: 15px;
    margin-top: -25px;
}

.message {
    display: flex;
    justify-content: center;
    background-color: #BFDBDE;
    width: 1314px;
    height: 100vh;
    border-radius: 15px;
    margin-top: -25px;
}

p {
    margin-top: 15px;
    margin-left: 30px;
    font-size: 20px;
    font-weight: 600;
    color: #062F33;
}

.underline-input {
    display: flex;
    flex-direction: column;
    align-items: center;
    margin-right: 30px;
}

.recipient-input {
    width: 1052px;
    height: 26px;
    margin-top: 12px;
    background-color: #7A9597;
    color: #062F33;
    font-size: 20px;
    font-weight: 500;
    outline: none;
}

.underline {
    width: 1052px;
    height: 2px;
    background-color: #000000;
    opacity: 22%;
}

.object-input {
    width: 1052px;
    height: 26px;
    margin-top: 12px;
    background-color: #9DB8BB;
    color: #062F33;
    font-size: 20px;
    font-weight: 500;
    outline: none;
}

.message-input {
    width: 1256px;
    margin-top: 12px;
    background-color: #BFDBDE;
    color: #062F33;
    font-size: 20px;
    font-weight: 500;
    outline: none;
}

.message-input::placeholder {
    font-weight: 600;
    opacity: 30%;
}

/*CSS FOR MOBILE*/

.mobile-recipient {
    display: flex;
    justify-content: space-between;
    background-color: #7A9597;
    width: 100%;
    height: 97px;
    margin-top: 50px;
    border-radius: 15px;
}

.mobile-object {
    display: flex;
    justify-content: space-between;
    background-color: #9DB8BB;
    width: 100%;
    height: 97px;
    margin-top: -25px;
    border-radius: 15px;
}

.mobile-message {
    display: flex;
    justify-content: center;
    background-color: #BFDBDE;
    width: 100%;
    height: 100vh;
    margin-top: -25px;
    border-radius: 15px;
}

.mobile-underline-input {
    width: 288px;
    margin-right: 15px;
}

.mobile-recipient-input {
    width: 288px;
    height: 26px;
    margin-top: 12px;
    background-color: #7A9597;
    color: #062F33;
    font-size: 20px;
    font-weight: 500;
    outline: none;
}

.mobile-object-input {
    width: 288px;
    height: 26px;
    margin-top: 12px;
    background-color: #9DB8BB;
    color: #062F33;
    font-size: 20px;
    font-weight: 500;
    outline: none;
}

.mobile-underline {
    width: 288px;
    height: 2px;
    background-color: #000000;
    opacity: 22%;
}

.mobile-message-input {
    width: 370px;
    margin-top: 12px;
    background-color: #BFDBDE;
    color: #062F33;
    font-size: 20px;
    font-weight: 500;
    outline: none;
}

.mobile-message-input::placeholder {
    font-weight: 600;
    opacity: 30%;
}

</style>
