import { createRouter, createWebHistory } from 'vue-router';
import Login from './components/Login.vue';
import Registration from './components/Registration.vue'; 

const routes = [
    { path: '/login', component: Login },
    { path: '/sign', component: Registration },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;
