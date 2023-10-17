<template>
<div class="container">
   <h1>Ejemplo de uso de workers en vuejs</h1>
   <button
    @click="btnUpdate">Prueba update</button>
</div>
</template>
<script>
import moment from 'moment'

export default{
    components:{

    },
    data(){
      return {
        website:'Ejemplo',
        variable1:1,
        variable2:2,
        progress:100,
        fechainicio:"",
        fechafin:""
      };
    },
    created() {
        console.log('this.progress: ' + this.progress);
    },
    updated: function () {
       // this.$nextTick(function () {

        if(this.progress != 100){
            this.fechafin =  f.getFullYear() + "-" + (f.getMonth() +1) + "-" + f.getDate() +
           " " + f.getHours() + ":" + f.getMinutes() + ":" + f.getSeconds();
            var fecha1 = moment(this.fechainicio);
            var fecha2 = moment("2016-10-03 07:30:00", "YYYY-MM-DD HH:mm:ss");
            var diff = fecha2.diff(fecha1, 'seconds'); // Diff in days
            this.progress = (diff * 100) / 100;
            
        }
        console.log('this.progress: ' + this.progress);
        //})
    },
    methods:{
        btnUpdate(){
            this.progress = 0;
            var f = new Date();
            this.fechainicio =  f.getFullYear() + "-" + (f.getMonth() +1) + "-" + f.getDate() +
            " " + f.getHours() + ":" + f.getMinutes() + ":" + f.getSeconds();   
        }
    },
    mounted(){
        const actions = [
            { message: 'func1', func: () => `Worker 1: Working on func1` },
            { message: 'func2', func: arg => `Worker 2: ${arg}` },
            { message: 'func3', func: arg => `Worker 3: ${arg}` },
            { message: 'func4', func: (arg = 'Working on func4') => `Worker 4: ${arg}` },
            { message: 'func5', func: (arg = this.variable1) => `Worker 5: ${arg}` }
        ]
 
        let worker = this.$worker.create(actions)    
         worker.postMessage('func1')
        .then(console.log) // logs 'Worker 1: Working on func1'
        .catch(console.error) // logs any possible error
        
        worker.postMessage('func1', ['Ignored', 'arguments'])
        .then(console.log) // logs 'Worker 1: Working on func1'
        .catch(console.error) // logs any possible error
        
        worker.postMessage('func2')
        .then(console.log) // logs 'Worker 2: undefined'
        .catch(console.error) // logs any possible error
        
        worker.postMessage('func3', ['Working on func3'])
        .then(console.log) // logs 'Worker 3: Working on func3'
        .catch(console.error) // logs any possible error
        
        worker.postMessage('func4')
        .then(console.log) // logs 'Worker 4: Working on func4'
        .catch(console.error) // logs any possible error
        
        worker.postMessage('func4', ['Overwrited argument'])
        .then(console.log) // logs 'Worker 4: Overwrited argument'
        .catch(console.error) // logs any possible error

        worker.postMessage('func5', [String(this.variable1)+','+String(this.variable2)])
        .then(response =>{
            console.log(response);
        }) 
        .catch(console.error) 

    },
}
</script>

