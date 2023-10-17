<template>
  <div id="game" ref="game" >
    <div id="centerLine"></div>
    <Scoreboard :playerOneScore="playerOneScore" :playerTwoScore="playerTwoScore" />
    <Ball @goal="handleGoal" />
    <Paddle isLeftPaddle />
    <Paddle />
  </div>
</template>

<script>
import Scoreboard from './scoreboard.vue'
import Ball from './ball.vue'
import Paddle from './paddle.vue'
export default {
  name: 'Game',
  components: {
    Scoreboard,
    Ball,
    Paddle
  },
  data () {
    return {
      playerOneScore: 0,
      playerTwoScore: 0
    }
  },
  methods: {
    handleGoal (player) {
      if (player === 'playerOne') {
        this.playerOneScore++
      } else {
        this.playerTwoScore++
      }
    }
  }
}
</script>

<style>
  #game {
    width: 100%;
    height: 100%;
    background-color: black;
    position: relative;
    font-family: 'zig';
    border-top: 20px solid white;
    border-bottom: 20px solid white;
    overflow: hidden;
  }
  #centerLine {
    height: 100%;
    width: 18px;
    position: absolute;
    top: 0;
    left: 50%;
    transform: translateX(-50%);
    
  }
</style>