<template>
    <div class="container">
        <h1>Main</h1>
        <div class="posts" v-for="post in posts" :key="post.id">
            <h2 class="post-title" @click="goToPost(post.id)">{{ post.title }}</h2>
            <p class="post-snippet">{{ post.snippet }}</p>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                posts: [
                    { id: 1, title: 'Post 1', snippet: 'This is a snippet of post 1.' },
                    { id: 2, title: 'Post 2', snippet: 'This is a snippet of post 2.' },
                ],
            };
        },
        methods: {
            goToPost(postId) {
                this.$router.push({ name: 'PostDetail', params: { postId } });
            },
        },
    };
</script>



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
