import { NgModule } from "@angular/core";
import { MatDialogModule } from "@angular/material/dialog";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatTableModule } from "@angular/material/table";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { UserComponent } from "./User.component";

@NgModule({
  declarations: [
    UserComponent
  ],
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
  ]
})
export class UserModule {

}
