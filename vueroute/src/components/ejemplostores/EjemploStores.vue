<template>
<div>
<h1>Ejemplo de stores</h1>
<h2>Ejemplo de stores básico</h2>
<h3>contador {{ counter }} </h3>
<div class="btn-group" role="group" aria-label="Basic example">
    <button
        @click="incrementar"
     class="btn btn-primary">
        incrementar
    </button>
    <button
        @click="decrementar"
     class="btn btn-warning">
        decrementar
    </button>
</div>
<h2>Ejemplo de stores avanzado</h2>
<div>
    <div class="form-group">
        <label>Ingrese texto</label>
        <input 
            v-model="texto" 
            id="iTexto" 
            name="nTexto" 
            class="form-control" 
            type="text"  />
    </div>
</div>
<div class="btn-group" role="group" aria-label="Basic example">
    <button
        @click="guardarTextos"
     class="btn btn-primary">
        guardar textos
    </button>
    <button
        @click="borrarTextos"
     class="btn btn-warning">
        borrar textos
    </button>
</div>
<ul class="list-group">
    <li 
        v-bind:key="index"
        v-for="(texto,index) in textos"
        class="list-group-item">
        texto
    </li>
</ul>
</div>  
</template>

<script>
export default {
    data(){
        return{
            texto:""
        }
    },
    computed:{
        textos(){
            return this.$store.state.textos;
        },
        counter(){
            return this.$store.state.count;
        }
    },
    methods:{
        borrarTextos(){
            this.$store.dispatch('BORRAR_TEXTOS');
        },
        guardarTextos(){
            this.$store.dispatch('GUARDAR_TEXTOS', {
                texto:this.texto
            });
        },
        incrementar(){
            this.$store.dispatch('INCREMENT')
        },
        decrementar(){
            this.$store.dispatch('DECREMENT')
        },
    }
}
</script>

<style>

</style>