import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'home' },
  { path: 'home', loadChildren: () => import('./Modules/Home/Home.module').then(x => x.HomeModule) },
  { path: 'client', loadChildren: () => import('./Modules/Client/Client.module').then(x => x.ClientModule) },
  { path: 'user', loadChildren: () => import('./Modules/User/User.module').then(x => x.UserModule) },
  { path: 'login', loadChildren: () => import('./Modules/Login/login.module').then(x => x.LoginModule) }
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
