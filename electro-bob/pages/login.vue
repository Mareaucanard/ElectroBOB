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
    <h1>Login</h1>
    <div class="hello">
        <UForm :ui="{label: {}}" :validate="validate" :state="state" class="space-y-4" @submit="onSubmit">
            <UFormGroup label="Email" name="email">
                <UInput v-model="state.email" />
            </UFormGroup>

            <UFormGroup label="Password" name="password">
                <UInput v-model="state.password" type="password" />
            </UFormGroup>

            <UButton type="submit">
                Submit
            </UButton>
        </UForm>
    </div>
</template>

<style>
    .hello {
        display: flex;
        justify-content: center;
    }
    .form {
        width: 500px;
    }
</style>
