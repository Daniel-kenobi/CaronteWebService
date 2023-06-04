import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { MatDialogModule } from "@angular/material/dialog";
import { MatTableModule } from "@angular/material/table";
import { CustomSpinnerModule } from "../../CommonComponents/CustomSpinner/custom-spinner.module";
import { UserService } from "../../Services/User/User.service";
import { UserRoutingModule } from "./User-routing.module";
import { UserComponent } from "./User.component";

@NgModule({
  declarations: [
    UserComponent,
  ],
  imports: [
    UserRoutingModule,
    MatTableModule,
    MatDialogModule,
    CommonModule,
    CustomSpinnerModule
  ],
  providers: [
    UserService
  ]
})
export class UserModule {

}
