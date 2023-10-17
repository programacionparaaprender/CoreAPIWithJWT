<template>
    <div style="width:600px;">
        <h1>This is about page</h1>
        <p>Tittle description of about page</p>
        <time-picker v-model="tiempo1" format="HH:mm"></time-picker>
        <time-picker v-model="tiempo2" format="HH:mm"></time-picker>
        <v-client-table :data="entries" :columns="columns" :options="options">
            <button slot="p0000" slot-scope="props" class="cubo" :style="props.row.p0000">
            </button>
            <button slot="edit" slot-scope="props" class="cubo"
            @click="edit(props.row.id)">
                
            </button>
        </v-client-table>
        <b-modal id="modal-1" title="BootstrapVue" hide-footer>
            <template v-slot:modal-title>
                Using <code>$bvModal</code> Methods
            </template>
            <photoshop-picker 
            
            v-model="colors" 
            @input="updateValue" />
            <b-button class="mt-3" block @click="$bvModal.hide('modal-1')">Close Me</b-button>
        </b-modal>
    </div>
</template>
<style>
.cubo{
    display:block;
    height:20px;
    width:100%;
    border: 1px #ccc solid;
}
</style>
<script src="metodos.js"></script>
<script src="variables.js"></script>
<script>
import { Photoshop } from 'vue-color'
import Vue from 'vue';
import TimePicker from 'vuejs-timepicker'
import {ServerTable, ClientTable, Event} from 'vue-tables-2';
Vue.use(ClientTable);
//Vue.use(Pintura);
export default{
    name:"Sheduler",
    components:{
        ClientTable,
        TimePicker,
        'photoshop-picker': Photoshop
    },
    data(){
        return {
            colors:{
            hex:'#fffff'
            },
            tiempo1:{
                HH:'00',
                mm:'00',
                ss:'00'
            },
            tiempo2:{
                HH:'00',
                mm:'00',
                ss:'00'
            },
            columns:[
                'edit',
                'p0000', 'p0030', 'p0100', 'p0130', 'p0200', 'p0230', 'p0300', 'p0330', 'p0400', 'p0430', 'p0500', 'p0530', 'p0600', 'p0630', 'p0700', 'p0730', 'p0800', 'p0830', 'p0900', 'p0930', 'p1000', 'p1030', 'p1100', 'p1130', 'p1200', 'p1230', 'p1300', 'p1330', 'p1400', 'p1430', 'p1500', 'p1530', 'p1600', 'p1630', 'p1700', 'p1730', 'p1800', 'p1830', 'p1900', 'p1930', 'p2000', 'p2030', 'p2100', 'p2130', 'p2200', 'p2230', 'p2300', 'p2330'],
            entries:[
                {id:1,'p0000':'background-color:black;'},
                {id:2,'p0000':'background-color:black;'},
                {id:3,'p0000':'background-color:black;'},
                {id:4,'p0000':'background-color:black;'},
                {id:5,'p0000':'background-color:black;'},
                {id:6,'p0000':'background-color:black;'}
            ],
            options:{
                headings:{
    'p0000':'00:00',
    'p0030':'00:30',
    'p0100':'01:00',
    'p0130':'01:30',
    'p0200':'02:00',
    'p0230':'02:30',
    'p0300':'03:00',
    'p0330':'03:30',
    'p0400':'04:00',
    'p0430':'04:30',
    'p0500':'05:00',
    'p0530':'05:30',
    'p0600':'06:00',
    'p0630':'06:30',
    'p0700':'07:00',
    'p0730':'07:30',
    'p0800':'08:00',
    'p0830':'08:30',
    'p0900':'09:00',
    'p0930':'09:30',
    'p1000':'10:00',
    'p1030':'10:30',
    'p1100':'11:00',
    'p1130':'11:30',
    'p1200':'12:00',
    'p1230':'12:30',
    'p1300':'13:00',
    'p1330':'13:30',
    'p1400':'14:00',
    'p1430':'14:30',
    'p1500':'15:00',
    'p1530':'15:30',
    'p1600':'16:00',
    'p1630':'16:30',
    'p1700':'17:00',
    'p1730':'17:30',
    'p1800':'18:00',
    'p1830':'18:30',
    'p1900':'19:00',
    'p1930':'19:30',
    'p2000':'20:00',
    'p2030':'20:30',
    'p2100':'21:00',
    'p2130':'21:30',
    'p2200':'22:00',
    'p2230':'22:30',
    'p2300':'23:00',
    'p2330':'23:30'
    
},
                rowClassCallback(){
                    return 'bg-warning';
                },
                sortable: ['p0000'],
                filterable: ['p0000'],
                perPage:5,
                perPageValues: [10,25,50,100,500,1000],
                pagination: { chunk:10, dropdown: false }
            },
            id:0
        }
    },
    methods:{
        updateValue(){
            const idnew = this.id;
            const color = this.colors.hex;
            this.entries.forEach(function(element) {
                //console.log(element);
                if(element.id == idnew){
                    element.p0000 = "background-color:"+color
                    
                }
            });
            this.$bvModal.hide('modal-1');
        },
        edit(id){
            var idnew = 0;
            this.entries.forEach(function(element) {
                //console.log(element);
                if(element.id == id){
                    idnew = id;
                }
            });
            this.id = idnew;
            this.$bvModal.show('modal-1');
        },
        agregarSheduler(h1, h2, color){
            var r = {};
            const hora1 = parseInt(h1.HH);
            const minuto1 = parseInt(h1.mm);
            const hora2 = parseInt(h2.HH);
            const minuto2 = parseInt(h2.mm);
            switch(hora1){
                case 0:
                    switch(hora2){
                        case 0:
                            this.asignador0(r, minuto1, minuto2);
                            break;
                        case 1:
                            this.asignador1(r, minuto1, minuto2);
                        case 2:
                            this.asignador2(r, minuto1, minuto2);
                            break;
                        case 3:
                            this.asignador3(r, minuto1, minuto2);
                        case 4:
                            this.asignador4(r, minuto1, minuto2);
                        case 5:
                            this.asignador5(r, minuto1, minuto2);
                            break;
                        case 6:
                            this.asignador6(r, minuto1, minuto2);
                            break;
                        case 7:
                            this.asignador7(r, minuto1, minuto2);
                            break;
                        case 8:
                            this.asignador8(r, minuto1, minuto2);
                            break;
                        case 9:
                            this.asignador9(r, minuto1, minuto2);
                            break;
                        case 10:
                            break;
                        case 11:
                            break;
                        case 12:
                            break;
                        case 13:
                            break;
                        case 14:
                            break;
                        case 15:
                            break;
                        case 16:
                            break;
                        case 17:
                            break;
                        case 18:
                            break;
                        case 19:
                            break;
                        case 20:
                            break;
                        case 21:
                            break;
                        case 22:
                            break;
                        case 23:
                            break;                
                    }
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
                case 9:
                    break;
                case 10:
                    break;
                case 11:
                    break;
                case 12:
                    break;
                case 13:
                    break;
                case 14:
                    break;
                case 15:
                    break;
                case 16:
                    break;
                case 17:
                    break;
                case 18:
                    break;
                case 19:
                    break;
                case 20:
                    break;
                case 21:
                    break;
                case 22:
                    break;
                case 23:
                    break;                
            }
        },
        asignador0(r, minuto1, minuto2){
            const min1 = (minuto1 < 31) ? 0:30;
            const min2 = (minuto2 < 31) ? 0:30;
            if(min1 == 0 && min2 == 0){
                r.p0000 = color;
            }
            if(min1 == 0 && min2 > 0){
                r.p0000 = color;
                r.p0030 = color;
            }
            if(min1 > 0 && min2 > 0){
                r.p0030 = color;
            }
        },
        asignador1(r, minuto1, minuto2){
            r.p0000 = color;
            r.p0030 = color;
            const min1 = (minuto1 < 31) ? 0:30;
            const min2 = (minuto2 < 31) ? 0:30;
            if(min1 == 0 && min2 == 0){
                r.p0100 = color;
            }
            if(min1 == 0 && min2 > 0){
                r.p0100 = color;
                r.p0130 = color;
            }
            if(min1 > 0 && min2 > 0){
                r.p0130 = color;
            }
        },
        asignador2(r, minuto1, minuto2){
            r.p0000 = color;
            r.p0030 = color;
            r.p0100 = color;
            r.p0130 = color;
            const min1 = (minuto1 < 31) ? 0:30;
            const min2 = (minuto2 < 31) ? 0:30;
            if(min1 == 0 && min2 == 0){
                r.p0200 = color;
            }
            if(min1 == 0 && min2 > 0){
                r.p0200 = color;
                r.p0230 = color;
            }
            if(min1 > 0 && min2 > 0){
                r.p0230 = color;
            }
        },
        asignador3(r, minuto1, minuto2){
            r.p0000 = color;
            r.p0030 = color;
            r.p0100 = color;
            r.p0130 = color;
            r.p0200 = color;
            r.p0230 = color;
            const min1 = (minuto1 < 31) ? 0:30;
            const min2 = (minuto2 < 31) ? 0:30;
            if(min1 == 0 && min2 == 0){
                r.p0300 = color;
            }
            if(min1 == 0 && min2 > 0){
                r.p0300 = color;
                r.p0330 = color;
            }
            if(min1 > 0 && min2 > 0){
                r.p0330 = color;
            }
        },
        asignador4(r, minuto1, minuto2){
            r.p0000 = color;
            r.p0030 = color;
            r.p0100 = color;
            r.p0130 = color;
            r.p0200 = color;
            r.p0230 = color;
            r.p0300 = color;
            r.p0330 = color;
            const min1 = (minuto1 < 31) ? 0:30;
            const min2 = (minuto2 < 31) ? 0:30;
            if(min1 == 0 && min2 == 0){
                r.p0400 = color;
            }
            if(min1 == 0 && min2 > 0){
                r.p0400 = color;
                r.p0430 = color;
            }
            if(min1 > 0 && min2 > 0){
                r.p0430 = color;
            }
        },
        asignador5(r, minuto1, minuto2){
            r.p0000 = color;
            r.p0030 = color;
            r.p0100 = color;
            r.p0130 = color;
            r.p0200 = color;
            r.p0230 = color;
            r.p0300 = color;
            r.p0330 = color;
            r.p0400 = color;
            r.p0430 = color;
            const min1 = (minuto1 < 31) ? 0:30;
            const min2 = (minuto2 < 31) ? 0:30;
            if(min1 == 0 && min2 == 0){
                r.p0500 = color;
            }
            if(min1 == 0 && min2 > 0){
                r.p0500 = color;
                r.p0530 = color;
            }
            if(min1 > 0 && min2 > 0){
                r.p0530 = color;
            }
        },
        asignador6(r, minuto1, minuto2){
            r.p0000 = color;
            r.p0030 = color;
            r.p0100 = color;
            r.p0130 = color;
            r.p0200 = color;
            r.p0230 = color;
            r.p0300 = color;
            r.p0330 = color;
            r.p0400 = color;
            r.p0430 = color;
            r.p0500 = color;
            r.p0530 = color;
            const min1 = (minuto1 < 31) ? 0:30;
            const min2 = (minuto2 < 31) ? 0:30;
            if(min1 == 0 && min2 == 0){
                r.p0600 = color;
            }
            if(min1 == 0 && min2 > 0){
                r.p0600 = color;
                r.p0630 = color;
            }
            if(min1 > 0 && min2 > 0){
                r.p0630 = color;
            }
        },
        asignador7(r, minuto1, minuto2){
            r.p0000 = color;
            r.p0030 = color;
            r.p0100 = color;
            r.p0130 = color;
            r.p0200 = color;
            r.p0230 = color;
            r.p0300 = color;
            r.p0330 = color;
            r.p0400 = color;
            r.p0430 = color;
            r.p0500 = color;
            r.p0530 = color;
            r.p0600 = color;
            r.p0630 = color;
            const min1 = (minuto1 < 31) ? 0:30;
            const min2 = (minuto2 < 31) ? 0:30;
            if(min1 == 0 && min2 == 0){
                r.p0700 = color;
            }
            if(min1 == 0 && min2 > 0){
                r.p0700 = color;
                r.p0730 = color;
            }
            if(min1 > 0 && min2 > 0){
                r.p0730 = color;
            }
        },
        asignador8(r, minuto1, minuto2){
            r.p0000 = color;
            r.p0030 = color;
            r.p0100 = color;
            r.p0130 = color;
            r.p0200 = color;
            r.p0230 = color;
            r.p0300 = color;
            r.p0330 = color;
            r.p0400 = color;
            r.p0430 = color;
            r.p0500 = color;
            r.p0530 = color;
            r.p0600 = color;
            r.p0630 = color;
            r.p0700 = color;
            r.p0730 = color;
            const min1 = (minuto1 < 31) ? 0:30;
            const min2 = (minuto2 < 31) ? 0:30;
            if(min1 == 0 && min2 == 0){
                r.p0800 = color;
            }
            if(min1 == 0 && min2 > 0){
                r.p0800 = color;
                r.p0830 = color;
            }
            if(min1 > 0 && min2 > 0){
                r.p0830 = color;
            }
        },
        asignador9(r, minuto1, minuto2){
            r.p0000 = color;
            r.p0030 = color;
            r.p0100 = color;
            r.p0130 = color;
            r.p0200 = color;
            r.p0230 = color;
            r.p0300 = color;
            r.p0330 = color;
            r.p0400 = color;
            r.p0430 = color;
            r.p0500 = color;
            r.p0530 = color;
            r.p0600 = color;
            r.p0630 = color;
            r.p0700 = color;
            r.p0730 = color;
            r.p0800 = color;
            r.p0830 = color;
            const min1 = (minuto1 < 31) ? 0:30;
            const min2 = (minuto2 < 31) ? 0:30;
            if(min1 == 0 && min2 == 0){
                r.p0900 = color;
            }
            if(min1 == 0 && min2 > 0){
                r.p0900 = color;
                r.p0930 = color;
            }
            if(min1 > 0 && min2 > 0){
                r.p0930 = color;
            }
        }

    }
}
  </script>
