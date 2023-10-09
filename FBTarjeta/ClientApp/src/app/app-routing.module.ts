import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { LoginUsuariosComponent } from 'src/app/views/tio/login-usuarios/login-usuarios.component';
import { RegistrarUsuariosComponent } from 'src/app/views/tio/registrar-usuarios/registrar-usuarios.component';
import { TarjetaCreditoComponent } from './components/components/tarjeta-credito/tarjeta-credito.component';

const routes: Routes = [
  { path: '',  redirectTo: '/tarjeta', pathMatch: 'full' },
  {path: 'usuarios' , component: TarjetaCreditoComponent},
  {path: 'tarjeta' , component: TarjetaCreditoComponent},
  {path: 'login' , component: LoginUsuariosComponent},
  {path: 'registro' , component: RegistrarUsuariosComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
