<template>
<div>

              <a class="button" @click="searchInfoWikipedia()">
                <font-awesome-icon icon="wifi" /> Evento llama a padre
              </a>
<b-button variant="primary" @click="llamaPadre">llamapadre</b-button>
      </div>

</template>
<script>
  export default {
    props: ['dataFilm','noImage'],
    data () {
      return {
      }
    },
    methods: {
      llamaPadre(){
        this.$emit('evento_padre');
      },
      searchInfoWikipedia() {
          var title = '';
        this.$emit('search-in-wikipedia', title);
      }
    }
  }
</script>
<style>
.button
{
    font-family:Verdana, Geneva, Tahoma, sans-serif;
    font-size: 20;
    font-weight: bold;
    text-decoration:none;
    font-style: normal;
    width:200px;
    color:white !important;
    background-color: orangered;
    padding: 5px 10px 5px 10px;
    border-radius: 10px 10px 10px 10px;
    -moz-border-radius: 10px 10px 10px 10px;
    -webkit-border-radius: 10px 10px 10px 10px;
    border: 0px solid #000000;
    
}
.button:hover
{
    opacity:0.6;
}
</style>