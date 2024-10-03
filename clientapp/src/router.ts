import { createRouter, createWebHistory, type RouteRecordRaw } from 'vue-router';
import Login from './components/Login.vue';
import Registration from './components/Registration.vue'; 
import Home from './components/Index.vue';
import Posts from './components/Posts.vue'

const routes: RouteRecordRaw[] = [
    {
        path: '/dashboard',
        name: 'Dashboard',
        component: Home 
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
        path: '/',
        name: 'Home',
        component: Posts
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
