import { createRouter, createWebHistory, type RouteRecordRaw } from 'vue-router';
import Login from './components/Login.vue';
import Registration from './components/Registration.vue'; 
import Home from './components/Index.vue';
import Posts from './components/Posts.vue'
import Create from './components/Create.vue';

const routes: RouteRecordRaw[] = [
    {
        path: '/',
        name: 'Dashboard',
        component: Home 
    },
    {
        path: '/create',
        component: Create
    },
    {
        path: '/login',
        component: Login
    },
    {
        path: '/sign',
        component: Registration
    },
    {
        path: '/posts/:postid',
        name: 'Posts',
        component: Posts
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
