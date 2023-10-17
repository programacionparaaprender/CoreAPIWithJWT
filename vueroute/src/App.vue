<template>
<div class="container">
      
<div></div>

    <header-nav :webtitle="website"></header-nav>
    
      <!--  <contents></contents> 
      <div class="row"><router-link class="boton" to='/'>Home</router-link></div>
              <div class="row"><router-link class="boton" to='/register'>Register</router-link></div>
              <div class="row"><router-link class="boton" to='/login'>Login</router-link></div>
      -->

            <div>
                <router-view />
            </div>

            

      <footer-nav></footer-nav>

    </div>
</template>
<script>

import Header from './components/layouts/Header.vue';
import Footer from './components/layouts/Footer.vue';
//import Contents from './components/Contents.vue';
//import store from './store.js';
//import axios from 'axios';


export default{
    components:{
      'header-nav':Header,
      'footer-nav':Footer,
      //'contents':Contents
    },
    data(){
      return {
        website:''
      };
    },
    mounted(){
        this.$store.dispatch('INCREMENT');
        console.log('contador');
        console.log(this.$store.state.count);
        
        /* this.$http.get('https://localhost:44314/api/values').then(
            response=>{
                console.log('cors asp.net');
                const data = response.data;
                console.log(data);
            }
        ).catch(e=>{
                console.log(e);
            });      */       
         
    },
}
</script>

<style>
/*<div class="row"></div>*/
#app
        {
            width:800px;
            height:300px;
            background-color:azure;
        }
        .boton
        {
            float:left;
            height:40px;
            width:100%;
            background-color:olive;
            font-size:14px;
            font-style:normal;
            font-family:Verdana, Geneva, Tahoma, sans-serif;
            text-align:center;
            text-decoration:none;
            padding: 10px 20px 10px 20px;
            color:white;
        }
        .boton:hover
        {
            text-decoration:none;
            color:white;
            background-color:blue;
        }
        /*
        .row
        {
            float:left;
            width:100%;
        }
        */
        .col-20-px
        {
            float:left;
            width:20%;
        }
        .col-30-px
        {
            float:left;
            width:30%;
        }
        .col-70-px
        {
            float:left;
            width:70%;
        }
        .col-80-px
        {
            float:left;
            width:80%;
        }
</style>
