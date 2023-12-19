<script setup>

const state = reactive({
    email: undefined,
    password: undefined
})

const validate = (state) => {
    const errors = []
    if (!state.email) errors.push({ path: 'email', message: 'Required' })
    if (!state.password) errors.push({ path: 'password', message: 'Required' })
    return errors
}

async function onSubmit(event) {
    console.log(event.data)
}

</script>

<template>
    <ion-page v-if="$device.isDesktop">
        <ion-content :fullscreen="true">
            <div class="hello">
                <div class="modal">
                    <img src="../assets/ElectroBob 1.png" type="logo">
                    <h1>LOGIN</h1>
                    <UForm :ui="{ label: {} }" :validate="validate" :state="state" class="space-y-4 uform" @submit="onSubmit">
                        <UFormGroup name="email">
                            <Input v-model="state.email" placeholder="user email" class="input"/>
                        </UFormGroup>

                        <UFormGroup name="password">
                            <Input v-model="state.password" type="password" placeholder="user password" class="input" />
                        </UFormGroup>

                        <UButton type="submit" class="submit">
                            <img src="../assets/submit button.png" type="submit"/>
                        </UButton>
                    </UForm>
                    <a class="register" href="/register">
                        register
                    </a>
                </div>
            </div>
        </ion-content>
    </ion-page>
    <ion-page v-else>
        <h1>HELLOOOOO THIS IS MOBILE LOGIN</h1>
    </ion-page>
</template>

<style>
.hello {
    display: flex;
    justify-content: center;
    align-items: center;
    align-self: center;
    margin-top: 200px;
}

.modal {
    width: 570px;
    height: 437px;
    display: flex;
    justify-content: space-evenly;
    align-items: center;
    flex-direction: column;
    background-color: #062F33;
    border-radius: 15px;
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
    background-color: white;
    border-radius: 15px;
    color: black;
    text-align: center;
    font-size: 25px;
    font-weight: 500;
}

.register {
    width: 129px;
    height: 38px;
    margin-left: 400px;
    margin-bottom: -10px;
    background-color: white;
    border-radius: 15px;
    color: black;
    text-align: center;
    font-size: 25px;
    font-weight: 500;
}

h1 {
    color: white;
    font-size: 45px;
}

img[type="logo"]{
    width: 130px;
    margin-top: -80px;
}

.submit {
    width: 65px;
}

img[type=submit] {
    width: 65px;
}

</style>
