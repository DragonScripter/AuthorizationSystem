import { createRouter, createWebHistory, type RouteRecordRaw } from 'vue-router';
import Login from './components/Login.vue';
import Registration from './components/Registration.vue'; 
import Home from './components/Index.vue'; 

const routes: RouteRecordRaw[] = [
    {
        path: '/',
        name: 'Home',
        component: Home 
    },
    {
        path: '/login',
        component: Login
    },
    {
        path: '/sign',
        component: Registration
    }
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
