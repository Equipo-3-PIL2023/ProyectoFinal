import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './pages/forms/login/login.component';
import { PortafolioComponent } from './pages/portafolio/portafolio.component';
import { LandingComponent } from './pages/landing/landing.component';
import { RegistrerComponent } from './pages/forms/registrer/registrer.component';
import { ComprarAccionesComponent } from './pages/comprarAcciones/comprarAcciones.component';


const routes: Routes = [
  {path:"", redirectTo:"/landing", pathMatch:"full"},
  {path:"", redirectTo:"", pathMatch:"full"},
  {path: 'landing', component: LandingComponent },
  {path: '', component: LandingComponent },
  {path: 'login' , component: LoginComponent},
  {path: 'portafolio', component:PortafolioComponent},
  {path: 'home', component: LandingComponent},
  {path: 'register', component: RegistrerComponent},
  {path: 'comprar', component: ComprarAccionesComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
   declarations: [
   
  ]
})
export class AppRoutingModule { }
