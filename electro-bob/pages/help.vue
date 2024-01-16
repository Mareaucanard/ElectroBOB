<template>
    <div v-if="$device.isDesktop" class="base desktop">
        <svg width="466" height="51" viewBox="0 0 466 51" fill="none" xmlns="http://www.w3.org/2000/svg">
            <path d="M0.5 51C76.6202 51 227.991 41.0318 231.44 1.38656C231.426 0.913066 231.447 0.450564 231.5 0C231.5 0.466173 231.48 0.928351 231.44 1.38656C231.942 18.7784 278.699 51 466 51H0.5Z" fill="#BFDBDE"/>
          </svg>
        <div class="joke">
            <div class="text">
                <a target="_blank" href="https://www.canva.com/design/DAF6DGsb2hI/BIHYrng_BqRwCDK2PDdotg/edit">This is the help you need !</a>
            </div>
        </div>
    </div>
    <div v-else class="base">
        <svg width="346" height="115" viewBox="0 0 466 53" fill="none" xmlns="http://www.w3.org/2000/svg">
            <path d="M0.981567 104.229C57.767 104.229 36.166 61.0137 36.0009 1.18543C35.9871 0.952732 35.9868 0.724224 36 0.5C36 0.728717 36.0003 0.957194 36.0009 1.18543C37.5331 26.9767 204.427 104.229 345.585 104.229H0.981567Z" fill="#BFDBDE"/>
        </svg>
        <div class="mobile-joke">
            <button class="mobile-text">
                <a target="_blank" href="https://www.canva.com/design/DAF6DGsb2hI/BIHYrng_BqRwCDK2PDdotg/edit">This is the help you need !</a>
            </button>
        </div>
    </div>
</template>

<script setup>

</script>

<style>
.base {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}
.desktop {
    margin-top: 60px;
}
.joke {
    display: flex;
    flex-direction:column;
    justify-content: center;
    align-items: center;
    width: 540px;
    height: 250px;
    border-radius: 25px;
    background: #BFDBDE;
}

.bob {
    width: 250px;
    margin-top: 150px;
}

.bubble {
    clip-path: polygon(0% 0%, 100% 0%, 100% 75%, 34% 75%, 0 89%, 14% 75%, 0% 75%);
    background-color: #BFDBDE;
    width: 280px;
    height: 220px;
}

h2 {
    color: #062F33;
}

.text {
    display: flex;
    width: 470px;
    color: #062F33;
}

.mobile-joke {
    display: flex;
    flex-direction:column;
    justify-content: center;
    align-items: center;
    width: 440px;
    height: 350px;
    background: #BFDBDE;
}

.mobile-text {
    display: flex;
    width: 340px;
    color: #062F33;
}

</style>