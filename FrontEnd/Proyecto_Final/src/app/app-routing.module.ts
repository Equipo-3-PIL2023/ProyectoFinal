import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SharedDirective } from './shared.directive';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
   declarations: [
    "SharedDirective"
  ]
})
export class AppRoutingModule { }
