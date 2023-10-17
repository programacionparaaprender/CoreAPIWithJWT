<template lang="">
    <header class="container-fluid" style="font-style: italic;">
  <!-- nav siga a la pantalla fixed-top  -->
  <nav 
    class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
    <div class="container-fluid">
      <a class="navbar-brand" href="/">
        <img src="./assets/images/principal.jpg" width="50" height="50" alt="">
      </a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
          <li class="nav-item">
            <router-link to="/" tag="a" class="nav-link" exact>Inicio</router-link>
          </li>
          <!--
          <div class="collapse navbar-collapse" id="navbarNavDarkDropdown">
            <ul class="navbar-nav">
              <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navbarDarkDropdownMenuLink" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                  Exercises
                </a>
                <ul class="dropdown-menu dropdown-menu-dark" aria-labelledby="navbarDarkDropdownMenuLink">
                  <a class="dropdown-item" [routerLink]="'/legs'">Legs</a>
                  <div class="dropdown-divider"></div>
                  <a class="dropdown-item" href="#">Ankles</a>
                  <div class="dropdown-divider"></div>
                  <a class="dropdown-item" [routerLink]="'/arms'">Arms</a>
                </ul>
              </li>
            </ul>
          </div>
        -->
 
        <li class="nav-item">
            <router-link to="/usuarios" tag="a" class="nav-link">Usuarios</router-link>
        </li>
        <li class="nav-item">
            <router-link to="/tarjeta" tag="a" class="nav-link">Tarjeta</router-link>
        </li>
        </ul>
        <!--
        <form class="d-flex fst-italic">
          <input 
            id="iBuscar"
            name="nBuscar"
            class="form-control me-2 fst-italic" 
            type="search" 
            placeholder="Buscar" 
            aria-label="Search">
          <button 
            class="btn btn-outline-secondary fst-italic" 
            type="submit">
              Buscar
          </button>
        </form>
      -->
      <ul class="nav navbar-nav navbar-right" *ngIf="login != null">
        <li class="nav-item" *ngIf="login.nombre=='error'">
          <router-link to="/login" tag="a" class="nav-link">Login</router-link>
        </li>
        <li class="nav-item" *ngIf="login.nombre=='error'">
          <router-link to="/registro" tag="a" class="nav-link">Registrar</router-link>
        </li>
        <li class="nav-item" *ngIf="login.nombre!='error'">
          <a class="nav-link" @click="logout()">Logout</a>
        </li>
    </ul>
    <ul class="nav navbar-nav navbar-right" *ngIf="login == null">
      <li class="nav-item">
        <router-link to="/login" tag="a" class="nav-link">Login</router-link>
      </li>
      <li class="nav-item">
        <router-link to="/registro" tag="a" class="nav-link">Registrar</router-link>
      </li>
    </ul>
      </div>
    </div>
  </nav>

</header>

</template>
<script>
export default {
    name:"MenuView",
    methods:{
        logout(){
            const usuario = {
                id: 1,
                token:"",
                nombre: "error",
                email: "error@gmail.com",
                role:"",
                status: 404
            }
            //this.usuariologeado = false;
            //this.router.navigate(['/login']);
            //this.tokenService.setUser(usuario);
            //this.tokenService.logout();
        }
    }
}
</script>
<style lang="">
    
</style>