//import Home from './components/Home.vue';
//import Register from './components/Register.vue';
//import Login from './components/Login.vue';
const Home = {
    template: '<div class= "row jumbotron text-center" style="color:black;"><div class="row"><h1>Página Principal</h1><div class="w-100"></div><input class="botonNuevo" type="button" value="Boton" v-on:click="boton()" /></div></div>'
};


const Register = { templateURL: './components/Register.vue' };


const Login = { templateURL: './components/Login.vue' };

const component1 = Vue.component('my-checkbox', {
    template: '#checkbox-template',
    data() {
        return {
            checked: false,
            title: 'Check me'
        }
    },
    methods: {
        check() {
            this.checked = !this.checked;
        }
    }
});


// { template:
const routes = [
    { path: '/', component: Home },
    { path: '/register', component: Register },
    { path: '/login', component: Login },
    { path: '/component', conponent: component1}
];

//export default routes;