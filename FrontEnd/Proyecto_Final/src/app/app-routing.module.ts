import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/forms/login/login.component';
import { PortafolioComponent } from './pages/portafolio/portafolio.component';

const routes: Routes = [
  {path: 'login' , component: LoginComponent},
  {path: 'portafolio', component:PortafolioComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
   declarations: [
   
  ]
})
export class AppRoutingModule { }
