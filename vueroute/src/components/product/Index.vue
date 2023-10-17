<template>
<div>
    <router-view></router-view>           
    <div></div>
	<div class="cover">
        <div  class="col-md-12">
            Products
        </div>
        <div class="row">
        <div v-bind:key="{id:key}" class="col-md-3" v-for="(product,key) in products">
            <div class="col-md-12">
                <img src="http://placehold.it/200x100/000" />
            </div>
            <div class="col-md-12">
                <h4>{{product.data.title | uppercase}}</h4>
                <p>{{product.data.description | lowercase}}</p>
                
                <router-link :to="{name: 'product', params:{id:key}}" class="btn btn-success">View</router-link>
            </div>
        </div>
        </div>
        
    </div>
</div>
</template>
<script>
//import axios from 'axios';
export default{
    data(){
        return{
            products:[],
        }
    },
    mounted()
    {
        /* axios.get('https://jsonplaceholder.typicode.com/users').then((response) => {
            console.log(response.data);
            }); */
        this.$http.get('https://vue-http-6a741.firebaseio.com/products.json').then(
            response=>{
                this.products = response.data;
                //console.log(this.products);
            }
        ).catch(e=>{
                console.log(e);
            });            
         }
}
</script>
<style>
.cover
{
    padding:20px;
    margin:40px 2px;
    border:1px solid #D2E0E6;
}	
</style>