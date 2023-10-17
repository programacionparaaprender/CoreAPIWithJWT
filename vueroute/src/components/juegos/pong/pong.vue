<template>
  <div id="pong">
    <Game/>
  </div>
</template>

<script>
import Game from './Game'
export default {
  //name: 'Pong',
  components: {
    Game
  }
}
</script>

<style>
  #pong {
    height: 500px;
    width:500px;
    display:block;
    background-color: blueviolet;
  }
  
</style>