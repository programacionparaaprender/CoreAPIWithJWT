<template>
<div>
    <div></div>
    <div class="row cover">
        <div class="col-md-12">
            <h3 class="text-center">
                Create Product
            </h3>
        </div>
        <div class="col-md-3"></div>
        <div class="col-md-6">
            <form @submit.prevent>
                <div class="form-group">
                    <label for="title">
                        Product Title
                    </label>
                    <input v-model="product.title" type="text" id="title" class="form-control" />
                </div>

                <div class="form-group">
                    <label for="title">
                        Product Description
                    </label>
                    <textarea  v-model="product.description" id="description" class="form-control" rows="3">
                    </textarea>
                </div>
                
                <div class="form-group">
                    <label for="quantity">
                        Product Quantity
                    </label>
                    <input  v-model="product.quantity" type="text" id="quantity" class="form-control" />
                </div>
                <button type="submit" class="btn btn-primary" @click="create">Submit</button> 
            </form>
        </div>
    </div>
</div>
</template>
<script>
 export default{
     data(){
         return {
             product:{
                 title: "",
                 description: "",
                 quantity: 0
             },
             status:false
         }
     },
     methods:{
         create(){
            this.$http.post('https://vue-http-6a741.firebaseio.com/products.json',{
                data:this.product
            }).then(
            response=>{
                this.product = response.data;
                console.log(this.product);
            }
        ).catch(e=>{
                console.log(e);
            });;            
         }
     },
     watch:{
         '$data':{
             handler(newVal, oldVal){
                 console.log(newVal);
                 console.log(oldVal);
             },deep:true
         }
     }
 }
</script>