<template>
  <div id="ball" :style="{
                            width: size + 'px',
                            height: size + 'px',
                            left: xPos + 'px',
                            top: yPos + 'px',
                          }"></div>
</template>

<script>
export default {
  name: 'Ball',
  data () {
    return {
      size: 20,
      xPos: 0,
      yPos: 0,
      xDir: '',
      yDir: '',
      speed: 0,
      interval: null
    }
  },
  methods: {
    move () {
      if (this.xDir === 'leftToRight') {
        this.xPos = this.xPos + this.speed
      } else {
        this.xPos = this.xPos - this.speed
      }
      if (this.yDir === 'bottomToTop') {
        this.yPos = this.yPos + this.speed
      } else {
        this.yPos = this.yPos - this.speed
      }
      this.checkForWall()
      this.checkIfScored()
    },
    reverseDirection (hitLeftPaddle, hitTopHalfOfPaddle) {
      if (hitLeftPaddle) {
        this.xDir = 'leftToRight'
      } else {
        this.xDir = 'rightToLeft'
      }
      if (hitTopHalfOfPaddle) {
        this.yDir = 'bottomToTop'
      } else {
        this.yDir = 'topToBottom'
      }
    },
    reset () {
      this.yPos = (this.$parent.$refs.game.clientHeight - this.size) / 2
      this.xPos = (this.$parent.$refs.game.clientWidth - this.size) / 2
    },
    accelerate (force) {
      this.speed = this.speed + force
    },
    startMoving () {
      const randomNumber1 = Math.random()
      const randomNumber2 = Math.random()
      this.speed = 10
      randomNumber1 < 0.5 ? this.xDir = 'leftToRight' : this.xDir = 'rightToLeft'
      randomNumber2 < 0.5 ? this.yDir = 'bottomToTop' : this.yDir = 'topToBottom'
      this.interval = setInterval(this.move, 100)
    },
    checkForWall () {
      if (this.yPos > this.$parent.$refs.game.clientHeight - this.size) {
        this.yDir = 'topToBottom'
      }
      if (this.yPos < this.size) {
        this.yDir = 'bottomToTop'
      }
    },
    checkIfScored () {
      if (this.xPos > this.$parent.$refs.game.clientWidth - (this.size * 1.5)) {
        this.$emit('goal', 'playerOne')
        this.countScoreAndReset()
      }
      if (this.xPos < this.size / 2) {
        this.$emit('goal', 'playerTwo')
        this.countScoreAndReset()
      }
    },
    countScoreAndReset () {
      clearInterval(this.interval)
      setTimeout(() => {
        this.reset()
        this.startMoving()
      }, 3000)
    }
  },
  mounted () {
    this.reset()
    this.startMoving()
  }
}
</script>

<style>
  #ball {
    color:red;
    background: white;
    position: absolute;
    border-radius: 100%;
    /* transition: all linear; */
  }
</style>