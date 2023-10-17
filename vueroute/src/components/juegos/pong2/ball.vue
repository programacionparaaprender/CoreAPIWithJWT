<template>
<div>
  <div id="ball" :style="{
                            width: size + 'px',
                            height: size + 'px',
                            left: xPos + 'px',
                            top: yPos + 'px',
                          }"></div>
</div>

</template>

<script>
export default {
  name: 'Ball',
  props:[
    'ventana',
    'raqueta1',
    'raqueta2',
    'pelota'
  ],
  data () {
    return {
      size: 40,
      xPos: 50,
      yPos: 50,
      xDir: '',
      yDir: '',
      speed: 0,
      interval: null
    }
  },
  methods: {
    
  },
  mounted () {
    console.log('Size');
    console.log(this.size);
  }
}
</script>

<style>
  #ball {
    color:black;
    background: white;
    position: absolute;
    border-radius: 100%;
    /* transition: all linear; */
  }
</style>