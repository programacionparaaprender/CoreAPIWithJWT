//import Home from '@/components/Home.vue';
import Register from '@/components/Register.vue';
//import Login from '@/components/auth/Login.vue';
import About from '@/components/About.vue';
import Contact from '@/components/Contact.vue';
import Index from '@/components/Index.vue';
//import Signup from '@/components/auth/Signup.vue';
//import Tree from '@/components/Tree.vue';
//import Padre from '@/components/Padre.vue';
//import Products from './components/product/Index.vue';
//import Details from './components/product/Details.vue';
import Error from '@/components/layouts/Error.vue';
//import Webcam from '@/components/extras/WebCam.vue';

//import Create from '@/components/product/Create.vue';

/* const Products = r => require.ensure([],()=>{  r(require('@/components/product/Index.vue'))}, 'product')

const Details = r =>require.ensure([],()=>{ r(require('@/components/product/Details.vue'))}, 'product') */

import Vieja from '@/components/juegos/vieja/vieja.vue';
import Pong from '@/components/juegos/pong2/pong.vue';
import Sheduler from '@/components/tablas/Sheduler.vue';
import ProgressVar from '@/components/progress/ProgressVar.vue';
import ScrollspyMio from '@/components/bootstrapvue/ScrollspyMio.vue';
import HorariosUsuario from '@/components/tablas/HorariosUsuario.vue';
//import EjemploWorker from '@/components/EjemploWorker.vue';
import GoogleMap from '@/components/google/GoogleMap.vue';
//import Padre from './components/Padre.vue';
import EjemploStores from '@/components/ejemplostores/EjemploStores.vue';

import Peticion from '@/views/prueba/Peticion.vue';

import Geocerca from '@/components/google/GeoCerca.vue';

const routes = [
    { path: '/peticion', component: Peticion},
    { path: '/ejemplostore', component: EjemploStores},
    { path: '/maps', component: GoogleMap},
    { path: '/geocerca', component: Geocerca},
    //{ path: '/ejemploworker', component: EjemploWorker},
    //{ path: '/padre', component: Padre},
    { path: '/scrollpane', component: ScrollspyMio },
    { path: '/progress', component: ProgressVar },
    { path: '/pong', component: Pong },
    { path: '/vieja', component: Vieja },
    { path: '/', component: Index },
    { path: '/register', component: Register },
    //{ path: '/login', component: Login },
    { path: '/about', component: About },
    { path: '/contact', component: Contact },
    //{ path: '/signup', component: Signup },
    //{ path: '/webcam', component: Webcam },
    { path: '/horariosusuario', component: HorariosUsuario },
    { path: '/register-now', redirect:'/signup' },
    /*  { path: '/products', component: Products,children:[
        { path: 'create', component: Create,name:'create-product' },
        { path: ':id', component: Details,name:'product' },
    ] },  */
    { path: '/404', component: Error },
    { path: '*', redirect:'/404' },
     
    /* { path: '/products/', component: Products },
    { path: '/products/create', component: Create,name:'create-product' },
    { path: '/products/product-detail/:id', component: Details,name:'product' }, */
    
    { path: '/tablas/Sheduler', component: Sheduler }
    /*
    { path: '/tree', component: Tree },
    { path: '/padre', component: Padre },
    */
];


export default routes;