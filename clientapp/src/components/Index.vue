<template>
    <div class="container">
        <h1>Main</h1>
        <div class="posts" v-for="post in posts" :key="post.id">

        </div>
    </div>
</template>



<style scoped>
    .body-container {
        background-color: #f0f0f0;
        background-size: cover;
        width: 100vw;
        height: 100vh;
        position: absolute;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        display: flex;
        justify-content: center;
        align-items: center;
    }
    .container {
        height: 100vh;
        width: 100vw;
        display: flex;
        justify-content: center;
        align-items: center;
    }
</style>
