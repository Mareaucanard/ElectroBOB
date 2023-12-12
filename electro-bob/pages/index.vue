
<template>
    <div class="buttonWrapper">
        <div class="hello">
            <UButton to="/login" block>Login</UButton>
            <div class="spacing" />
            <UButton to="/register" block>Register</UButton>
        </div>
    </div>
</template>

<script setup>
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

.hello {
    flex-direction: column;
    display: flex;
    width: 100px;
    align-items: center;
}
</style>
