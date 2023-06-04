import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'client' },
  { path: 'client', loadChildren: () => import('./Modules/Client/Client.module').then(x => x.ClientModule) },
  { path: 'user', loadChildren: () => import('./Modules/User/User.module').then(x => x.UserModule) }
]

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
