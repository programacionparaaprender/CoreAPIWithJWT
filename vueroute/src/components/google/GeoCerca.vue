<template>
  <div>
      <button 
        @click="limpiar()"
        type="button" 
        class="btn btn-success">
          Limpiar
      </button>
      <GmapMap
                          :center="{
                            lat:MyCoordinates.lat,
                            lng:MyCoordinates.lng
                          }"
                          :zoom="zoom"
                          map-type-id="terrain"
                          style="width:630px;height:360px;"
                          @click="clicMapa"
                          class="gmap"
                          ref="mapaRef">
                          <GmapMarker
                          :key="index"
                          v-for="(m,index) in markers"
                            :position="m.position"
                            :clickable="true"
                            :draggable="true"
                          />
                          <GmapPolygon
                          :path="geocerca"
                            :clickable="false"
                            :draggable="false"
                          />
                        </GmapMap>
  </div>
</template>

<script>
//{lat:MyCoordinates.lat,lng:MyCoordinates.lng}
export default {
    data(){
        return{
            Coordinates:null, 
            zoom:14,
            map:null,
            markers:[],
            geocerca:[]
        }
    },
    mounted(){
      this.actualizar();
    },
    computed:{
      MyCoordinates(){
        if(!this.Coordinates)
        return {
            lat:0,
            lng:0
        };
        return this.Coordinates;
      }
    },
    methods:{
        clicMapa(coor){
            //alert(JSON.stringify(coor));
            var position = {}
            var lng = coor.latLng.lng();
            var lat = coor.latLng.lat();
            position.lng = lng;
            position.lat = lat;
            var position2 = {}
            position2.position = position
            this.markers.push(position2);
            this.geocerca.push(position);
        },
        limpiar(){
            this.markers = [];
            this.geocerca = [];
        },
        actualizar(){
            this.$getLocation()
            .then(coordinates => {
            //console.log(coordinates);
            this.Coordinates = coordinates;
            }).catch(error =>
                console.log(error)
            );
            this.$refs.mapaRef.$mapPromise.then(map => this.map = map);
        }
    }
}
</script>

<style>

</style>