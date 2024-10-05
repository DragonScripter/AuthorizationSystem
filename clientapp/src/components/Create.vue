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
                       placeholder="Enter a description"
                       class="input-box"
                       required />
                <button type="submit" class="btn btn-primary custom">Post</button>
            </div>
        </form>
    </div>
</template>

<script>

</script>

<style>

</style>