<template>
<div>
<div style="float: left;width: 300px;display:block;">
        <div style="float:left;width:100%;" className="board-row">
            <div v-bind:key="index" style="float: left;width: 33.33%;" v-for="(square, index) in squares">
                <Square :value="square" @search-in-wikipedia="searchInfoWikipedia(index)"></Square></div>
            </div>
</div>

<!-- <div style="float:left;width:100%;" className="board-row">
        <div  style="float: left;width: 33.33%;" >
            <Square :value="squares[0]" @search-in-wikipedia="searchInfoWikipedia(0)"></Square></div>
        <div style="float: left;width: 33.33%;">
            <Square :value="squares[1]"  @search-in-wikipedia="searchInfoWikipedia(1)"></Square></div>
        <div style="float: left;width: 33.33%;">
            <Square :value="squares[2]"  @search-in-wikipedia="searchInfoWikipedia(2)"></Square></div>
        </div>
        <div style="float:left;width:100%;" className="board-row">
          <div style="float: left;width: 33.33%;">
              <Square :value="squares[3]"  @search-in-wikipedia="searchInfoWikipedia(3)"></Square></div>
          <div style="float: left;width: 33.33%;">
              <Square :value="squares[4]"  @search-in-wikipedia="searchInfoWikipedia(4)"></Square></div>
          <div style="float: left;width: 33.33%;">
              <Square :value="squares[5]"  @search-in-wikipedia="searchInfoWikipedia(5)"></Square></div>
            
        </div>

        <div style="float:left;width:100%;" className="board-row">
        <div style="float: left;width: 33.33%;">
            <Square :value="squares[6]" @search-in-wikipedia="searchInfoWikipedia(6)">
            </Square>
            </div>
        <div style="float: left;width: 33.33%;">
            <Square :value="squares[7]" @search-in-wikipedia="searchInfoWikipedia(7)">

            </Square>
            </div>
        <div style="float: left;width: 33.33%;">
            <Square :value="squares[8]" @search-in-wikipedia="searchInfoWikipedia(8)">
            </Square>
        </div>   
        </div>
        
      </div> -->
</div>
</template>
<script>
import square from './square.vue'
export default{
    props:['squares'],
    components:{
        'Square':square
    },
    data(){
    return{
          
    }
        
    },
    mounted() {
        /* setTimeout(this.$forceUpdate(), 500) */
  },
  computed:{
      /* squares(){
        return this.$store.state.squares;
      } */
  },
    methods:{
        searchInfoWikipedia (value) {
            this.$emit('handle-Click', value);
            
        }
    }
}
</script>