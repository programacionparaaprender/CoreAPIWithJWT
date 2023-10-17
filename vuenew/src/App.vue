<template>
  <div class="grid-container">
    <div class="item1">
      <nav>
        <ul class="nav nav-pills float-right">
          <router-link to='/' tag="a" class="nav-item nav-link" exact>Home</router-link> 
          <router-link to="/about" tag="a" class="nav-item nav-link">About</router-link>
        </ul>
      </nav>
    </div>
    <div class="item2"><Slide /></div>
    <div class="item3"><router-view/></div>
  </div>
</template>
<script>
import Slide from '@/views/Slide.vue'
export default{
  components:{
    Slide
  },
  name:"App"
}
</script>

<style lang="scss">
.item1 { grid-area: header; }
.item2 { grid-area: menu; }
.item3 { grid-area: main; }
.item4 { grid-area: footer; }

.grid-container {
  display: grid;
  grid-template-areas:
    'header header header'
    'menu main main'
    'menu footer footer';
  gap: 10px;
  background-color: #2196F3;
  padding: 10px;
}
</style>
