<template>
<div>
    <button style="margin:0; paddingLeft: 0; listStyle: none; width:100px; height:100px;" className="square" @click="llamaPadre()">
      {{value}}
    </button>
</div>
</template>
<script>
export default{
    props:['value'],
    data(){
        return {
            
        }
    },
    
    methods:{
        llamaPadre(){
            this.$emit('search-in-wikipedia');
        }
    }
}
</script>