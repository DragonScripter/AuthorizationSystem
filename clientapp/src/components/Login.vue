<template>
    <div class="body-container">
        <div class="container">
            <div class="form-content">
            <div class="Intro-content">
                <h1>Login</h1>
                <h3>Don't have an account yet? <a href="#">Sign up</a></h3>
            </div>
            <form @submit.prevent="handleSubmit">
                <div class="group">
                    <label for="username"><strong>Username</strong></label>
                    <input type="text"
                           v-model="formData.username"
                           id="username"
                           placeholder="Username"
                           class="input-box"
                           required />
                </div>
                <div class="group">
                    <label for="Password"><strong>Password</strong></label>
                    <input type="password"
                           v-model="formData.password"
                           id="password"
                           placeholder="Password"
                           class="input-box"
                           required />
                    <button type="submit" class="btn btn-primary custom">Login</button>
                </div>
                <div v-if="formData.errorMessage" class="error">
                    {{ formData.errorMessage }}
                </div>
            </form>
                </div>
        </div>
    </div>
</template>

<script lang="ts">
    import { defineComponent, reactive } from 'vue';

    export default defineComponent({
        setup() {
            const formData = reactive({
                username: '',
                password: '',
                errorMessage: ''
            });

            const handleSubmit = async () => {
                if (formData.username === '' || formData.password === '') {
                    formData.errorMessage = 'Please fill in all fields.';
                } else {
                    try {
                        const response = await fetch('https://auth/login', {
                            method: 'POST',
                            headers: {
                                'Content-Type': 'application/json',
                            },
                            body: JSON.stringify({
                                username: formData.username,
                                password: formData.password,
                            }),
                        });

                        if (!response.ok) {
                            throw new Error('Login failed');
                        }

                        const data = await response.json();
                        console.log('Login successful:', data);
                        formData.errorMessage = 'Login Sucess!'; 
                    } catch (error) {
                        formData.errorMessage = 'Login failed. Please try again.';
                        console.error(error);
                    }
                }
            };

            return {
                formData,
                handleSubmit
            };
        },
    });
</script>

<style>
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
        background-image: url(..//assets//clip-woman-asking-question-on-website.png);
        background-repeat: no-repeat;
        background-position: right center; 
        padding: 20px; 
        border-radius: 5px;
        border-block-color:black;
        height: 500px; 
        width: 100%;
        max-width: 100%; 
        text-align: center; 
    }
    .form-content {
        position: relative;
        width: 600px;
        height: 400px;
        padding: 20px;
        box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2);
        border-radius: 5px;
    }
    .Intro-content h3, h1 {
        text-align: left;
        color: black;
    }

    .Intro-content h1 {
        font-size: 2.5em;
    }

    .Intro-content {
        margin-bottom: 10px;
    }

    .group label, input {
        display: block;
        text-align: left;
        color: black;
        margin-left: 10px;
    }

    .group {
        padding: 5px;
    }

    .group label {
        font-size: 1.5em;

    }
    .group button {
        display: flex;
        justify-content: flex-start;
        margin-top: 30px;
    }

    .input-box {
        width: 250px;
        height: 40px;
    }

    input {
        border-radius: 10px;
    }
    button {
        padding: 30px;
    }
    .custom {
        font-size: 2rem;
        padding: 10px 20px;
        width: 159px;
        border-radius: 5px;
        display: flex;
        justify-content: center;
        align-items: center;
    }
</style>
