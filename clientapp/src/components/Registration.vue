<template>
    <div class="container">
        <div class="left">
            <div class="left-content">
                <h3>Welcome Back!</h3>
            </div>
        </div>
        <div class="right">
            <div class="intro-content">
            <h1>Registration Page</h1>
                </div>
            <form @submit.prevent="handleSubmit">
                <div class="group">
                    <label for="name"><strong>Name</strong></label>
                    <input type="text"
                           v-model="formData.name"
                           id="name"
                           placeholder="Enter your name"
                           class="input-box"
                           required />
                </div>
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
                    <label for="email"><strong>Email</strong></label>
                    <input type="text"
                           v-model="formData.email"
                           id="email"
                           placeholder="Enter your email"
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

<script lang="ts">
    import { defineComponent, reactive } from 'vue';

    export default defineComponent({
        setup() {
            const formData = reactive({
                name: '',
                username: '',
                email: '',
                password: '',
                errorMessage: ''
            });

            const handleSubmit = async () => {
                if (formData.name == '' ||formData.username === '' || formData.email == '' ||formData.password === '') {
                    formData.errorMessage = 'Please fill in all fields.';
                }
                else
                {
                    try {
                        const response = await fetch('https://auth/registraion', {
                            method: 'POST',
                            headers: {
                                'Content-Type': 'application/json',
                            },
                            body: JSON.stringify({
                                name: formData.name,
                                username: formData.username,
                                email: formData.email,
                                password: formData.password,
                            }),
                        });

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