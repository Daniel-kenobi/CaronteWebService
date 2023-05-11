import { NgModule } from "@angular/core";
import { MatDialogModule } from "@angular/material/dialog";

import { MatTableModule } from '@angular/material/table';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { ClientDetailComponent } from "./Detail/ClientDetail.component";
import { ClientService } from "../Services/Client/Client.service";

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
    ClientService
  ],
  declarations: [
    ClientDetailComponent
  ]
})
export class ClientModule { }
