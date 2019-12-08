<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebVueJS.aspx.vb" Inherits="WebForm47.WebVueJS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="es">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>TODO supply a title</title>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        
    <!-- Latest compiled and minified CSS -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">

<!-- Optional theme -->
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">

<!-- Latest compiled and minified JavaScript -->
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>
 <style>
/*<div class="row"></div>*/
#app
        {
            width:800px;
            height:300px;
            background-color:azure;
        }
        .boton
        {
            float:left;
            height:40px;
            width:100%;
            background-color:olive;
            font-size:14px;
            font-style:normal;
            font-family:Verdana, Geneva, Tahoma, sans-serif;
            text-align:center;
            text-decoration:none;
            padding: 10px 20px 10px 20px;
            color:white;
        }
        .boton:hover
        {
            text-decoration:none;
            color:white;
            background-color:blue;
        }
        /*
        .row
        {
            float:left;
            width:100%;
        }
        */
        .col-20-px
        {
            float:left;
            width:20%;
        }
        .col-30-px
        {
            float:left;
            width:30%;
        }
        .col-70-px
        {
            float:left;
            width:70%;
        }
        .col-80-px
        {
            float:left;
            width:80%;
        }
</style>
   
    
        <script src="https://unpkg.com/vue"></script>
        <script src="https://cdn.jsdelivr.net/vue.resource/1.0.3/vue-resource.min.js"></script>
        <script src="https://unpkg.com/vue-router/dist/vue-router.js"></script>
    <script type="text/x-template" id="checkbox-template">
        <div class="checkbox-wrapper">
            <h1> Practica</div>
            <div class="title"></div>
         </div>

    </script>    
    <script src="js/routes.js"></script>
    </head>
        <body>
        <div class="container-fluid" id="app">
            <div></div>
            <div class="row marketing">
              <div class="col-lg-3">

              <div class="row"><router-link class="boton" to='/'>Home</router-link></div>
              <div class="row"><router-link class="boton" to='/register'>Register</router-link></div>
              <div class="row"><router-link class="boton" to='/login'>Login</router-link></div>
              <div class="row"><router-link class="boton" to='/component'>Componente Nuevo</router-link></div>
            </div>
            <div class="col-lg-9">
                <router-view />
            </div>

            </div>
            
            <select
                v-model="selectedDestino"
                class="selectDestino require-error borde-select texto-blanco"
                data-live-search="true"
                title="Destino, Cuidad, Localidad..."
                v-on:change="destino()"
                v-on:click="destinoSeleccionado"
                required="required">
                <optgroup label="Destino">
                    <option 
                        value="todos" 
                        selected>
                      Seleccione un destino
                    </option>
                    <option 
                        v-for="destino in destinos" 
                        v-bind:value="destino.idDestino+'-destino'">
                        {{ destino.ciudad }}
                    </option>
                </optgroup>
            </select>
            <select
                v-model="selectedHotel"
                class="selectHotel require-error borde-select"
                data-live-search="true"
                title="Nombre del Hotel"
                v-on:change="hotel()"
                v-on:click="hotelSeleccionado"
                required="required">
                <optgroup label="Hotel">
                    <option selected>
                      Seleccione un Hotel
                    </option>
                    <option
                        v-for="hotel in hoteles"
                        v-bind:value="hotel.idHotel+'-hotel'">
                        {{ hotel.nombre }}
                    </option>
                </optgroup>
                <optgroup label="Hoteles">
                    <option
                      value="todos">
                      Mostrar Todos los Hoteles
                    </option>
                </optgroup>
            </select>

            <div class="row jumbotron text-center">
            <div>
        <div>Pulsa el botón para recuperar el listado de gatos:</div>
        <div>
            <button v-on:click="get_gatos()">Obtener listado</button>
        </div>
        <div>
            <ul>
                <li v-for="gato in gatos">
                    <strong>{{gato.nombre}}</strong> - {{ gato.edad }} años ({{ gato.sexo }})
                </li>
            </ul>
        </div>
            </div>
            </div>

            <span> Selected: {{selectedDestino}}</span>
            <span> Selected: {{selectedHotel}}</span>
        </div>
        <!--<script src="https://unpkg.com/vue@2.1.10/dist/vue.js"></script> -->
        <!-- <script src="https://unpkg.com/vue"></script> -->
        <!--<script src="js/footer.js"></script>-->
        <!--<script src="js/vue.js"></script>-->
        
        <script type="text/javascript">
            var destinosjs = [
                {
                    idDestino: 1, 
                    ciudad: "Varadero"
                },
                {
                    idDestino: 2, 
                    ciudad: "Habana"
                }
            ];
        var hotelesjs = [
            {
                idHotel: 1, 
                idDestino: 1, 
                nombre : 'Hotel Varadero 1',
                categoria:'hotel'
                
            },
            {
                idHotel: 2, 
                idDestino: 1, 
                nombre: 'Hotel Varadero 2',
                categoria:'hotel'
                
            },
            {
                idHotel: 3, 
                idDestino: 1, 
                nombre: 'Hotel Varadero 3',
                categoria:'hotel'
            },
            {
                idHotel: 4, 
                idDestino: 2, 
                nombre: 'Hotel Habata 1',
                categoria:'hotel'
            },
            {
                idHotel: 5, 
                idDestino: 2, 
                nombre: 'Hotel Habana 2',
                categoria:'hotel'
             }, 
            {    
                idHotel: 6, 
                idDestino: 2, 
                nombre: 'Hotel Habana 3',
                categoria:'hotel'
            }
            ];

            var hotelesViejojs = hotelesjs;
            var urlServicio = "http://www.programandoconrupert.com/ws/servicio-gatos.php";

            const router = new VueRouter({
                routes // short for `routes: routes`
            });

            var example1 = new Vue({
                el: '#app',
                router,
                data: {
                    selectedDestino: "",
                    selectedHotel: "",
                    seleccionado: 0,
                    destinos: destinosjs,
                    hoteles: hotelesjs,
                    hotelesViejo: hotelesViejojs,
                    gatos: [],
                },
                methods: {
                    get_gatos: function () {
                        alert('Funciona');

                        this.$http({
                            root: urlServicio,
                            method: 'GET'
                            
                        }).then(function (response) {
                            console.log(response.data);
                            this.gatos = response.data;
                            //vm.cities = response;
                        }, function (error) {
                            console.log('error in .js:');
                            console.log(error);
                        });

                        //this.$http.get(urlServicio, function (data, status, request) {
                            
                        //    //if (status == 200) {
                        //        this.weather = data;
                        //        console.log(this.weather);
                        //    //}
                        //});

                        //this.$http.get(urlServicio, function (brand) {
                        //    this.gatos = brand;

                        //}.bind(this));

                        //this.http.get(urlServicio, function (recipes) {

                        //    this.gatos = recipes;

                        //});
                        //Vue.http.options.root = '/your-root-path';

                        //var gatos2 = [];

                        //this.$http.get(urlServicio, function (recipes) {

                        //    gatos2 = recipes;

                        //});
                        //this.gatos = gatos2;
                    },
                    destino: function () {
                        var idDestino;
                        var arr = this.selectedDestino.split("-");
                        var idDestino = arr[0];
                        var nuevos_hoteles = [];
                        for (i = 0; i < this.hotelesViejo.length; i++) {
                            if (idDestino == this.hotelesViejo[i].idDestino) {
                                nuevos_hoteles.push(this.hotelesViejo[i]);
                            }
                        }
                        this.hoteles = nuevos_hoteles;

                    },
                    hotelSeleccionado: function () {
                        //seleccion de hotel
                        this.seleccionado = 2;
                    },
                    destinoSeleccionado: function () {
                        //seleccion de destino
                        this.seleccionado = 1;
                    },
                    evento_boton: function () {
                    },
                    hotel: function () {
                        if (this.selectedHotel === 'todos') {
                            console.log('detecto selección de todos los hoteles');
                            this.hoteles = this.hotelesViejo;
                        }
                    }
                }
            });
        </script>
    </body>
</html>
