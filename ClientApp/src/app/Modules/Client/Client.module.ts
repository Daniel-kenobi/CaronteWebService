import { NgModule } from "@angular/core";
import { MatDialogModule } from "@angular/material/dialog";

import { MatTableModule } from '@angular/material/table';
import { ClientDetailComponent } from "./Detail/ClientDetail.component";
import { ClientService } from "../../Services/Client/Client.service";
import { ClientComponent } from "./Client.component";
import { ClientRoutingModule } from "./Client-routing.module";
import { CommonModule } from "@angular/common";
import { CustomSpinnerModule } from "../../CommonComponents/CustomSpinner/custom-spinner.module";

@NgModule({
  declarations: [
    ClientDetailComponent,
    ClientComponent,
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatDialogModule,
    ClientRoutingModule,
    CustomSpinnerModule
  ],
  providers: [
    ClientService
  ]
})
export class ClientModule { }
