<template>
  <div>
      <div></div>
      <div></div>
      <div></div>
      <div></div>
  </div>
</template>
<script>
export default{
    data(){
        return{

        }
    },
    mounted(){
        const date = new Date();
        const ultimoDia = new Date(date.getFullYear(), date.getMonth() + 1, 0);
        console.log('días que tiene el mes: ' + ultimoDia.getDate());
    }
}
</script>