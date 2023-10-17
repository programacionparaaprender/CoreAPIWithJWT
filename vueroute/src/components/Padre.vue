<template>
  <div>
    <header>
      <div class="title"></div>
      <div class="subtitle"></div>
    </header>
    <section class="container">

      <div class="box-result">
          <film-card 
        :data-film="dataFilm" 
        :no-image="noImage" 
        @search-in-wikipedia="searchInfoWikipedia">
        </film-card>
       <!--   
        <film-card 
        :data-film="dataFilm" 
        :no-image="noImage" 
        @search-in-wikipedia="searchInfoWikipedia">
        </film-card>
        -->
      </div>
    </section>
  </div>
</template>

<script>
/*
 * Importando un componente de forma local.
 * Solo lo usamos donde se importa
 */
//import { bus } from "@/main";
import FilmCard from './filmCard.vue'
export default {
  components: {
    FilmCard
  },
  data () {
    return {
      header: {
        title: 'OMDb API',
        subtitle: 'The Open Movie & TV Show Database'
      }
    }
  },
  mounted(){
    /* bus.on('evento_padre',function(){
      alert('evento padre');
    }); */
    this.$on('evento_padre',function(){
      alert('evento padre');
    });
  },
  methods: {
    searchInfoWikipedia (title) {
      alert("Funciona");
    }
  }
}
</script>
