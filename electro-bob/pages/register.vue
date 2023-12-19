<script setup>

const state = reactive({
    email: undefined,
    password: undefined
})

const validate = (state) => {
    const errors = []
    if (!state.email) errors.push({ path: 'email', message: 'Required' })
    if (!state.password) errors.push({ path: 'password', message: 'Required' })
    if (state.password != state.confirm) errors.push({ path: 'confirm', message: 'Does not match'})
    return errors
}

async function onSubmit(event) {
    console.log(event.data)
}
</script>

<template>
    <div class="hello" v-if="$device.isDesktop">
        <div class="modal">
            <img src="../assets/ElectroBob 1.png" type="logo">
            <h1>REGISTER</h1>
            <UForm :ui="{ label: {} }" :validate="validate" :state="state" class="space-y-4 uform" @submit="onSubmit">
                <UFormGroup name="email">
                    <Input v-model="state.email" placeholder="user email" class="input"/>
                </UFormGroup>

                <UFormGroup name="password">
                    <Input v-model="state.password" type="password" placeholder="user password" class="input"/>
                </UFormGroup>
                <UFormGroup name="confirm">
                    <Input v-model="state.confirm" type="password" placeholder="confirm password" class="input"/>
                </UFormGroup>

                <UButton type="submit" class="submit">
                    <img src="../assets/submit button.png" type="submit"/>
                </UButton>
            </UForm>
        </div>
    </div>
    <div class="hello" v-else>
        <div class="mobile-modal">
            <img src="../assets/ElectroBob 1.png" type="logo">
            <h1>LOGIN</h1>
            <UForm :ui="{ label: {} }" :validate="validate" :state="state" class="space-y-4 uform" @submit="onSubmit">
                <UFormGroup name="email">
                    <Input v-model="state.email" placeholder="user email" class="mobile-input"/>
                </UFormGroup>

                <UFormGroup name="password">
                    <Input v-model="state.password" type="password" placeholder="user password" class="mobile-input" />
                </UFormGroup>

                <UFormGroup name="confirm">
                    <Input v-model="state.confirm" type="password" placeholder="confirm password" class="mobile-input"/>
                </UFormGroup>

                <UButton type="submit" class="mobile-submit" variant="link">
                    <img src="../assets/submit button.png" type="mobile-submit"/>
                </UButton>
            </UForm>
        </div>
    </div>
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
    height: 559px;
    display: flex;
    justify-content: space-evenly;
    align-items: center;
    flex-direction: column;
    background-color: #062F33;
    border-radius: 15px;
}

.uform {
    height: 320px;
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
    outline: none;
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

/* CSS FOR MOBILE*/

.mobile-modal {
    width: 338px;
    height: 542px;
    display: flex;
    justify-content: space-evenly;
    align-items: center;
    flex-direction: column;
    background-color: #062f337c;
    border-radius: 15px;
}

.mobile-input {
    width: 210px;
    height: 49px;
    background-color: white;
    border-radius: 15px;
    color: black;
    text-align: center;
    font-size: 25px;
    font-weight: 500;
    outline: none;
}

.mobile-submit {
    width: 66px;
    height: 68px;
}


.mobile-register {
    width: 129px;
    height: 38px;
    margin-left: 200px;
    margin-bottom: -35px;
    background-color: white;
    border-radius: 15px;
    color: black;
    text-align: center;
    font-size: 25px;
    font-weight: 500;
}

</style>
