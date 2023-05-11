import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const appRoutes: Routes = [
  { path: '', redirectTo: 'client', pathMatch: 'full' },
  { path: 'client', loadChildren: () => import('./Client/Client.module').then(x => x.ClientModule) },
  { path: 'user', loadChildren: () => import('./User/User.module').then(x => x.UserModule) }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(appRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
