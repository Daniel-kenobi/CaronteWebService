import { NgModule } from "@angular/core";
import { MatDialogModule } from "@angular/material/dialog";

import { MatTableModule } from '@angular/material/table';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { UserDetailComponent } from "./Detail/UserDetail.component";
import { UserService } from "./User.service";
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@NgModule({
  imports: [
    MatTableModule,
    MatDialogModule,
    BrowserAnimationsModule,
    MatProgressSpinnerModule
  ],
  exports: [
    MatTableModule,
    MatDialogModule,
    BrowserAnimationsModule,
    MatProgressSpinnerModule
  ],
  providers: [
    UserService
  ],
  declarations: [
    UserDetailComponent
  ]
})
export class UserModule { }
