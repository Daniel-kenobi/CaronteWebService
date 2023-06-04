import { NgModule } from "@angular/core";
import { MatDialogModule } from "@angular/material/dialog";

import { MatTableModule } from '@angular/material/table';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ClientDetailComponent } from "./Detail/ClientDetail.component";
import { ClientService } from "../../Services/Client/Client.service";
import { ClientComponent } from "./Client.component";
import { ClientRoutingModule } from "./Client-routing.module";
import { CommonModule } from "@angular/common";

@NgModule({
  declarations: [
    ClientDetailComponent,
    ClientComponent,
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatDialogModule,
    MatProgressSpinnerModule,
    ClientRoutingModule,
  ],
  providers: [
    ClientService
  ]
})
export class ClientModule { }
