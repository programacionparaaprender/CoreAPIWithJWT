import 'bootstrap'
import 'bootstrap/dist/css/bootstrap.min.css'

import Vuex from 'vuex';
import Vue from 'vue';
import App from './App.vue';
import VueRouter from 'vue-router';
import VueTree from 'vue-jstree';
import routes from './router/index';
//import Axios from 'axios';
import state from './store/index';
//import filter from './filters.js';
import VueBootstrap from 'bootstrap-vue';

import VueWorker from 'vue-worker'
Vue.use(VueWorker);

Vue.use(Vuex);
const store = new Vuex.Store(state);

Vue.config.productionTip = true;

//Vue.prototype.$http = Axios;

import axios from 'axios';
import VueAxios from 'vue-axios'; 
Vue.use(VueAxios, axios);

Vue.use(VueRouter);
Vue.use(VueTree);
Vue.use(VueBootstrap);

const router = new VueRouter({
    scrollBehavior(to, from, savedPosition){
        //hace que la pantalla suba después de seleccionar
        if(savedPosition){
            return savedPosition;
        }else{
            return {x:0,y:0};
        }
        
    },
    'routes': routes,
    mode: 'history'
    });
//mode: 'history' se encarga de que ya no aparezca la almoadilla

/* axios.interceptors.response.use(response=>{
//console.log(response);
     return response; 
}, error=>{
    //console.log(error.response);
     if(error.response.status === 401){
        router.push('/paginavueroute/404');
    } 
}); */

import VueGeolocation from 'vue-browser-geolocation';
Vue.use(VueGeolocation);

import * as VueGoogleMaps from 'vue2-google-maps'
Vue.use(VueGoogleMaps, {
    load: {
        key: 'AIzaSyDZktO_JnnvrY4BnD2IyZo8PqNXiDTWP1w'
    }
});

new Vue({
    router,
    'store': store,
    VueTree,
    render: h => h(App)
}).$mount('#app');