<template>
    <div class="container">
        <div class="left">
            <div class="left-content">
                <h3>Welcome Back!</h3>
            </div>
        </div>
        <div class="right">
            <h1>Registration Page</h1>
            <form @submit.prevent="handleRegister">
                <input type="text" v-model="username" placeholder="Username" required />
                <input type="password" v-model="password" placeholder="Password" required />
                <button type="submit">Register</button>
            </form>
        </div>
    </div>
</template>

<style scoped>
    .container {
        background-color: #f0f0f0;
        display:flex;
        height: 100vh;
    }
    .left {
        background-color: blue;
        width: 20%;
        color: white;
        display: flex;
        align-items: center;
        justify-content: center;
    }
    .right {
        background-color: white;
        width: 80%; 
        color: black;
        display: flex;
        align-items: center;
        justify-content: center;
    }
</style>