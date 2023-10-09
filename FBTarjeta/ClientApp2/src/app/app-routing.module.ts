import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { TarjetaCreditoComponent } from './components/components/tarjeta-credito/tarjeta-credito.component';
const routes: Routes = [
  { path: '',  redirectTo: '/tarjeta', pathMatch: 'full' },
  {path: 'tarjeta' , component: TarjetaCreditoComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
