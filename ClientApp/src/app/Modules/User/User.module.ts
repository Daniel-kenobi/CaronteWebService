import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { MatDialogModule } from "@angular/material/dialog";
import { MatProgressSpinnerModule } from "@angular/material/progress-spinner";
import { MatTableModule } from "@angular/material/table";
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
    MatProgressSpinnerModule,
    CommonModule
  ],
  providers: [
    UserService
  ]
})
export class UserModule {

}
