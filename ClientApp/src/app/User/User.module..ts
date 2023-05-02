import { NgModule } from "@angular/core";
import { MatDialogModule } from "@angular/material/dialog";

import { MatTableModule } from '@angular/material/table';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { UserDetailComponent } from "./Detail/UserDetail.component";
import { UserService } from "./User.service";

@NgModule({
  imports: [
    MatTableModule,
    MatDialogModule,
    BrowserAnimationsModule  
  ],
  exports: [
    MatTableModule,
    MatDialogModule,
    BrowserAnimationsModule
  ],
  providers: [
    UserService
  ],
  declarations: [
    UserDetailComponent
  ]
})
export class UserModule { }
