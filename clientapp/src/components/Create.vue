<template>
    <div class="container">
        <div class="content">
            <h1>Create post</h1>
        </div>
        <form @submit.prevent="handleSubmit">
            <div class="group">
                <label for="title"><strong>Title</strong></label>
                <input type="text"
                       v-model="formData.title"
                       id="title"
                       placeholder="Enter a title"
                       class="input-box"
                       required />
            </div>
            <div class="group">
                <label for="body"><strong>Body</strong></label>
                <input type="text"
                       v-model="formData.body"
                       id="body"
                       placeholder="Body"
                       class="input-box"
                       required />
            </div>
            <div class="group">
                <label for="summary"><strong>Summary</strong></label>
                <input type="text"
                       v-model="formData.description"
                       id="body"
                       placeholder="Enter a description"
                       class="input-box"
                       required />
                <button type="submit" class="btn btn-primary custom">Post</button>
            </div>
            <div v-if="formData.errorMessage" class="error">
                {{ formData.errorMessage }}
            </div>
        </form>
    </div>
</template>

<script lang="ts">
    import { defineComponent, reactive } from 'vue'

    export default defineComponent({
        setup() {
            const formData = reactive({
                title: '',
                body: '',
                description: '',
                errorMessage: ''
            });

            const handleSubmit = async () => {
                if (formData.title === '' || formData.body === '' || formData.description === '')
                {
                    formData.errorMessage = 'Please fill in all the fields.';
                }
                else
                {
                    const token = sessionStorage.getItem('token');
                    try
                    {
                        const response = await fetch('https://localhost:7049/api/auth/create', {
                            method: 'POST',
                            headers: {
                                'Content-Type': 'application/json',
                                'Authorization': `Bearer ${token}`,
                            },
                            body: JSON.stringify({
                                title: formData.title,
                                body: formData.body,
                                description: formData.description
                            }),
                        });
                        if (!response.ok) {
                            throw new Error('Create failed');
                        }

                        const data = await response.json();
                        console.log('Create sucess!', data);
                    }
                    catch(error)
                    {
                        formData.errorMessage = 'Create failed';
                        console.log(error);
                    }
                }
            }
            return {
                formData,
                handleSubmit,
            };
        },
    });

</script>

<style>

</style>