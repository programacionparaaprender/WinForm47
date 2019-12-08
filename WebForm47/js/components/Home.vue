<template>
    <div class="row jumbotron text-center">
        <div class="row">
            <h1>Página Principal</h1>
            <div class="w-100"></div>
            <input class="botonNuevo" type="button" value="Boton" v-on:click="boton()" />
        </div>
    </div>
</template>
<style>
.botonNuevo
{
    color:white;
    background-color:orangered;
    padding: 10px 20px 10px 20px;
    -webkit-border-radius: 10px 10px 10px 10px;
    border-radius: 10px 10px 10px 10px;
}
.botonNuevo:hover
{
    opacity:0.6;
}
</style>
<script>
import Vue from 'vue';
import axios from 'axios';
import VueAxios from 'vue-axios';
 
Vue.use(VueAxios, axios);
var api = "http://www.programandoconrupert.com/ws/servicio-gatos.php";
export default {
    methods:{
        boton:function(){
            Vue.axios.get(api).then((response) => {
                var json = JSON.stringify(response.data);
            console.log(json);
            })
            
            this.axios.get(api).then((response) => {
            console.log(response.data);
            })
            
            this.$http.get(api).then((response) => {
            console.log(response.data);
            })
        }
    }
}
</script>