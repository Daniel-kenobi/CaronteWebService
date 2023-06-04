import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { ClientComponent } from "./Client.component";

const routes: Routes = [
  { path: '', component: ClientComponent }
]

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class ClientRoutingModule { }
