import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { NavbarComponent } from './Navbar/Navbar.component';
import { UserModule } from './Client/Client.module.';
import { ClientComponent } from './Client/Client.component'

const appRoutes: Routes = [
  { path: '', component: ClientComponent }, 
  { path: 'client', component: ClientComponent }, 
];

@NgModule({
  declarations: [
    AppComponent,
    ClientComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    UserModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
