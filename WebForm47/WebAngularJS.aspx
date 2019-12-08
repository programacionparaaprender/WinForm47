<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebAngularJS.aspx.vb" Inherits="WebForm47.WebAngularJS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" ng-app='angularRoutingApp'>
<head>
    <title>AngularJS</title>
  <link rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css" />
    <style>
        #main
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
        .row
        {
            float:left;
            width:100%;
        }
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
</head>
<body ng-controller='mainController'>
  <header>
    <h1>Angular Routing</h1>
      <nav> 
        <ul> 
          <li><a href="#">Inicio</a></li>
          <li><a href="#acerca">Acerca de</a></li>
          <li><a href="#contacto">Contacto</a></li> 		

        </ul> 
      </nav>
    </header>

    <center>
        <div id="main">
        <div></div>
        <div class="row">
            <div class="col-30-px">
                <div class="row"><a class="boton" href="#">Main</a></div>
                <div class="row"><a class="boton" href="#acerca">Acerca de</a></div>
                <div class="row"><a class="boton" href="#contacto">Contacto</a></div>
                <div class="row"><a class="boton" href="#gato">Petición Get AngularJS</a></div>
                <div class="row"><a class="boton" href="#mvcget">Petición Get Asp.net MVC </a></div>
            </div>
            <div class="col-70-px">
                <!-- Aquí inyectamos las vistas -->
                <div style="width:100%; height:100%;" ng-view></div> 
            </div>
        </div>
      
    </div>
    </center>

    
    <script src="//cdnjs.cloudflare.com/ajax/libs/angular.js/1.2.7/angular.min.js"></script> 
    <script src="//cdnjs.cloudflare.com/ajax/libs/angular.js/1.2.3/angular-route.js"></script>
    <script type="text/javascript">
        // Creación del módulo
        var angularRoutingApp = angular.module('angularRoutingApp', ['ngRoute']);

        // Configuración de las rutas
        angularRoutingApp.config(function ($routeProvider) {

            $routeProvider
                .when('/', {
                    templateUrl: 'pages/home.html',
                    controller: 'mainController'
                })
                .when('/acerca', {
                    templateUrl: 'pages/acerca.html',
                    controller: 'aboutController'
                })
                .when('/contacto', {
                    templateUrl: 'pages/contacto.html',
                    controller: 'contactController'
                })
                .when('/gato', {
                    templateUrl: 'pages/gato.html',
                    controller: 'ControladorGatos'
                })
                .when('/mvcget', {
                    templateUrl: 'pages/mvcget.html',
                    controller: 'ControladorMVCGet'
                })
                .otherwise({
                    redirectTo: '/'
                });
        });



        angularRoutingApp.controller("ControladorMVCGet", ["$scope", "$http", function ($scope, $http) {
            $scope.respuesta = '';
            $scope.obtenerGatos = function () {
                $http({
                    method: "GET",
                    url: "/api/values"
                }).then(function correcto(respuesta) {
                    $scope.respuesta = respuesta.data;
                },
                    function error(respuesta) {
                        alert(respuesta.statusText);
                    });
            };
        }]);

        var urlServicio = "http://www.programandoconrupert.com/ws/servicio-gatos.php";


        angularRoutingApp.controller('mainController', function ($scope) {
            $scope.message = 'Hola, Mundo!';
        });

        angularRoutingApp.controller("ControladorGatos", ["$scope", "$http", function ($scope, $http) {
            $scope.gatos = [];
            $scope.obtenerGatos = function () {
                $http({
                    method: "GET",
                    url: urlServicio
                }).then(function correcto(respuesta) {
                    $scope.gatos = respuesta.data;
                },
                    function error(respuesta) {
                        alert(respuesta.statusText);
                    });
            };
        }]);

        angularRoutingApp.controller('aboutController', function ($scope) {
            $scope.message = 'Esta es la página "Acerca de"';
        });

        angularRoutingApp.controller('contactController', function ($scope) {
            $scope.message = 'Esta es la página de "Contacto", aquí podemos poner un formulario';
        });
    </script>
  </body>
  </html>
