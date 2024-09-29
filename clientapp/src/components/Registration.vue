<template>
    <div class="body-container">
        <div class="container">
            <div class="right">
                <div class="left">
                    <div class="left-content">
                        <h3>Welcome Back!</h3>
                        <p>To sign in please login with your personal info</p>
                        <button class="custom"><router-link to="/login">Login</router-link></button>
                    </div>
                </div>
                <div class="right-content">
                    <div class="intro-content">
                        <h1>Create Account</h1>
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
                            <button type="Submit" class="btn btn-primary Sign">Sign up</button>
                        </div>
                        <div v-if="formData.errorMessage" class="error">
                            {{ formData.errorMessage }}
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>
    .body-container {
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
        font-family: Arial, sans-serif;
        align-items: center;
        background-color: #4682b4;
        opacity: 0.95;
        background-image: linear-gradient(45deg, rgba(68, 76, 247, 0.4) 1px, transparent 1px), linear-gradient(45deg, transparent 50%, rgba(55, 55, 75, 0.4) 50%);
        background-size: 10px 10px;
    }
    .container {
        height: 100vh;
        width: 100vw;
        display: flex;
        justify-content: center;
        align-items: center;
    }
    .left {
        background-color: #4682b4;
        height:100%;
        padding: 80px;
    }
    .left-content {
        color: #ffffff;
    }
    .right-content {
        height: 500px;
        margin-right: 30px;
    }
    .intro-content {
        color: #4682b4;
        margin-top: 40px;
    }
    .right {
        flex: 0 0 75%;
        height: 70%;
        background-color: #ffffff;
        padding: 20px;
        display: flex;
        justify-content: left;
        align-items: center;
    }
    .group label, input {
        display:flex;
        justify-content: center;
        align-items: center;
        display: block;
        text-align: left;
        color: black;
        margin-left: 10px;
    }
    .input-box {
        width: 250px;
        height: 40px;
    }

    input {
        border-radius: 10px;
    }
    .group
    {
        margin-left: 30px;
    }
    .custom {
        margin-top: 40px;
        background-color: #4682b4;
        color: #ffffff;
        border: 2px solid #ffffff; 
        border-radius: 5px; 
        padding: 15px 80px; 
        font-size: 20px; 
        cursor: pointer;
    }
        .custom a {
            text-decoration: none;
            color: #ffffff;
        }

        .custom :hover {
            color: black;
        }
    .Sign {
        margin-top:10px;
        margin-left: 55px;
        background-color: #4682b4;
        color: #ffffff;
        border: 2px solid #ffffff;
        border-radius: 5px;
        padding: 15px 40px;
        font-size: 20px;
        cursor: pointer;
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
<<<<<<< HEAD
                        const response = await fetch('https://localhost:7049/api/auth/registraion', {
=======
                        const response = await fetch('https://localhost:7049/api/auth/registration', {
>>>>>>> 1e1f1eb2efe5ca201f6b7892b33ef65c3215383b
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

                        if (!response.ok) {
                            throw new Error('Sign up failed');
                        }

                        const data = await response.json();
                        console.log('SignUp successful:', data);
                        formData.errorMessage = 'Signing up Sucess!';
                    } catch (error) {
                        console.error("Error doing sign up", error);
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