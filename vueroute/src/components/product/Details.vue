<template>
<div>
    <div></div>
	<div class="cover">
        <div  class="col-md-12">
            <div class="text-center">
                Products {{ id }}
            </div>
        </div>
        <div class="row">
            <div class="col-md-8" style="margin:auto;">
                <div v-if="errors.length!=0" class="alert alert-danger">
                    <ul>
                        <li v-for="error in errors">
                            {{error}}
                        </li>
                    </ul>    
                </div>
                <div class="col-md-12 img-section">
                    <img src="http://placehold.it/200x100/000" />
                </div>
                <div class="col-md-12">
                    <h4>{{product.title | uppercase}}</h4>
                    <p>{{product.description | uppercase | readmore(10, '...')}}</p>
                    <p><em>{{product.quantity | dollar}}</em></p> 
                    <a href="#" class="btn btn-success btn-sm"> ADD TO CART</a>
                </div>
                <div class="alert alert-info">
                    <button class="btn btn-success" @click="like++">Like</button>
                    <button class="btn btn-success" @click="dislike++">Dislike</button>
                    <p>Like: {{likeValue}}</p>
                    <p>Dislike: {{disLikeValue}}</p>
                </div>
            </div>
        </div>
        
    </div>
</div>
</template>
<script>
export default{
    data(){
        return{
            id:this.$route.params.id,
            product:[],
            errors:[],
            status:false,
            like:0,
            dislike:0
        }
    },
    /* filters:{
        uppercase(value){
            return value.toUpperCase();
        },
        lowercase(value){
            return value.toLowerCase();
        },
        dollar(value){
            return '$'+value;
        }
    }, */
    computed:{
        //se deben utilizar sin parentesis para que funcionen en el computed
        likeValue(){
            return this.like;
        },
        disLikeValue(){
            return this.dislike;
        }
    },
    methods:{
        
        updateProduct(){
            this.$http.get('https://vue-http-6a741.firebaseio.com/products.json',{
            params:{
                data: this.id
            }
        }).then(
            response=>{
                //var data = JSON.stringify(response.data[this.id]['data']);
                //this.product = Object.values(response.data);
                var data = response.data[this.id]['data'];
                this.product = data;
                //console.log(this.product);
                this.status = true;
            }
        ).catch(e=>{
            this.errors = e.response.data;
                //console.log(e);
            });         
        }
    },
    created: function()
    {
        this.updateProduct();   
            
        /* axios.get('https://jsonplaceholder.typicode.com/users').then((response) => {
            console.log(response.data);
            }); */
        /* this.$http.get('https://vue-http-6a741.firebaseio.com/products.json'+this.id+'.json').then(
            response=>{
                this.product = response.data;
                console.log(this.product);
            }
        ).catch(e=>{
                console.log(e);
            });             */

    },
    watch:{
        //se activa cuando se da en el boton view de alguno de los productos
        '$route'(to, from){
            this.id = to.params.id;

            this.updateProduct();

        },
        '$data':{
             handler(newVal, oldVal){
                 console.log(newVal);
                 console.log(oldVal);
             },deep:true
         },
        /* status: function(){
            console.log('Status has changed');
        },
        "product.title"(newData, oldData){
            console.log(newData);
            console.log(oldData);
        } */
    }
}
</script>

<style>
.text-center
{
    text-align:center;
}
.cover
{
    padding:20px;
    margin:40px 2px;
    border:1px solid #D2E0E6;
}	
.img-section img
{
    width:100%;
}
</style>