<template>
<div>

<div class="header clearfix">
        <nav>
          <ul class="nav nav-pills float-right">
            <router-link to='/' tag="a" class="nav-item nav-link" exact>Home</router-link> 
            <router-link to='/peticion' tag="a" class="nav-item nav-link">Petición</router-link>
            <router-link to='/geocerca' tag="a" class="nav-item nav-link">Geocerca</router-link>
            <router-link to='/maps' tag="a" class="nav-item nav-link">Google Maps</router-link>
            <router-link to='/ejemplostore' tag="a" class="nav-item nav-link" exact>Ejemplo de store</router-link>
            <!-- <router-link to='/ejemploworker' tag="a" class="nav-item nav-link" exact>Worker</router-link>     
            <router-link to='/progress' tag="a" class="nav-item nav-link">Progress</router-link>       
            <router-link to='/about' tag="a" class="nav-item nav-link">About</router-link>
            <router-link to='/contact' tag="a" class="nav-item nav-link">Contact</router-link>
            <router-link to='/login' tag="a" class="nav-item nav-link">Login</router-link>
            <router-link to='/products' tag="a" class="nav-item nav-link">Products</router-link> -->
            <!--  <router-link to='/tablas/Sheduler' tag="a" class="nav-item nav-link">Sheduler</router-link> -->
             <router-link to='/vieja' tag="a" class="nav-item nav-link">Vieja</router-link>
            <!--
              <router-link to='/webcam' tag="a" class="nav-item nav-link">Webcam</router-link>
              <router-link to='/signup' tag="a" class="nav-item nav-link">Signup</router-link>
            <router-link to='/tree' tag="a" class="nav-item nav-link">Tree</router-link>
            <router-link to='/padre' tag="a" class="nav-item nav-link">Padre</router-link>
            -->
          </ul>
        </nav>
        <h3 class="text-muted">{{webtitle}}</h3>
      </div>

</div>
</template>
<style>

</style>
<script>
export default{
  props:[
    'webtitle'
  ]
}
</script>