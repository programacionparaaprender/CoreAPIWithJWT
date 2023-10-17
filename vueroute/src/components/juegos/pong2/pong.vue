<template>
  <div>
    <div></div>
    <div id="pong">
      <Ball :ventana="ventana" :raqueta1="raqueta1" :raqueta2="raqueta2" :pelota="pelota" />
    </div>
  </div>
</template>
<script>
import Ball from './ball.vue'

const ventana = {
  x:0,
  y:0,
  width:500,
  height:500
};

var raqueta1 = {
  x:0,
  y:0,
  width:10,
  height:50
}

var raqueta2 = {
  x:100,
  y:0,
  width:10,
  height:50
}

var pelota = {
  x:100,
  y:100,
  size:20
};

export default{

    data(){
        return{
          raqueta1:raqueta1,
          raqueta2: raqueta2,
          pelota: pelota,
          ventana: ventana
        }
    },
    components:{
        Ball
    }
}
</script>
<style>
#pong{
    width:500px;
    height:500px;
    background-color:orangered;
    color:white;
}
</style>