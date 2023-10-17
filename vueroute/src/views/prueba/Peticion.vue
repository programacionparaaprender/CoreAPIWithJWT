<template>
  <div>
        <ul class="list-group">
            <li 
                v-bind:key="index"
                v-for="(gato,index) in gatos"
                class="list-group-item">
                {{gato.nombre}}
            </li>
        </ul>
  </div>
</template>

<script>
var urlServicio = "http://www.programandoconrupert.com/ws/servicio-gatos.php";
export default{
    data(){
        return{
            gatos:[]
        }
    },
    async mounted(){
        this.gatos = await this.getGatosAsync();
        console.log('gatos: '+JSON.stringify(this.gatos));
        
    },  
    methods:{
        async getGatosAsync() 
        {
            let response = await fetch(urlServicio);
            let data = await response.json()
            return data;
        },
        async getUserAsync(name) 
        {
            let response = await fetch(`https://api.github.com/users/${name}`);
            let data = await response.json()
            return data;
        }
    }
}
</script>

<style>

</style>