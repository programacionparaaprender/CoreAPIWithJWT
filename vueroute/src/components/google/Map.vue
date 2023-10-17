<template>
  <div class="row">
            <div class="col-lg-12">
                <div class="card card-default">
                    <div class="card-header">Mapas</div>
                    <div class="card-body">
                      <p class="card-header">
                        Mis coordenadas {{MyCoordinates.lat }} latitud - {{MyCoordinates.lng}} longitud
                      </p>
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
                          <GmapCircle
                            :center="{
                            lat:MyCoordinates.lat,
                            lng:MyCoordinates.lng
                          }"
                            :draggable="true"
                            :visible="true"
                            :radius="300"
                            :options="{
                              strokeColor:'red'
                            }"
                          />
                          <GmapMarker
                            :position="{
                            lat:MyCoordinates.lat,
                            lng:MyCoordinates.lng
                          }"
                            :clickable="true"
                            :draggable="true"
                            @click="clicCono"
                            @dragend="moverCono"
                          />
                          
                        </GmapMap>
                    </div>
                </div>
            </div>
        </div>
</template>

<script>
export default {
    data(){
        return{
          Coordinates:null, 
          zoom:14,
          map:null
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
      moverCono(coor){
        try{
          console.log(coor)
          this.Coordinates.lng = coor.latLng.lng();
          this.Coordinates.lat = coor.latLng.lat();
          /* this.map.setCenter({
                            lat:this.MyCoordinates.lat,
                            lng:this.MyCoordinates.lng
                          }); */
          //this.zoom = this.map.getZoom();
        }catch(error){
          console.log(error)
        }
       
      },
      clicMapa(coor){
        console.log(coor)
      },
      clicCono(coor){
        console.log(coor)
      },
      clicCirculo(coor){
        console.log(coor)
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