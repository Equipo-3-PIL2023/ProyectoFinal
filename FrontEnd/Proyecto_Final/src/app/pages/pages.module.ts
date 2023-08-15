import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './forms/login/login.component';
import { PortafolioComponent } from './portafolio/portafolio.component';
import { ComprarAccionesComponent } from './comprarAcciones/comprarAcciones.component';
import { RegistrerComponent } from './forms/registrer/registrer.component';
import { LandingComponent } from './landing/landing.component';
import { TablaCotizacionesComponent } from './tablaCotizaciones/tablaCotizaciones.component';



@NgModule({
  declarations: [
    LoginComponent,
    PortafolioComponent,
    ComprarAccionesComponent,
    RegistrerComponent,
    LandingComponent,
    TablaCotizacionesComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    LoginComponent,
    PortafolioComponent,
    ComprarAccionesComponent,
    RegistrerComponent,
    LandingComponent,
    TablaCotizacionesComponent
  ]
})
export class PagesModule { }
