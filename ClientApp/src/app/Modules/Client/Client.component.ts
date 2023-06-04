import { Component, OnInit } from "@angular/core";

import { MatDialog } from "@angular/material/dialog";
import { ClientModel } from "../../Models/Client/Client.model";
import { ClientService } from "../../Services/Client/Client.service";
import { ClientDetailComponent } from "./Detail/ClientDetail.component";

@Component({
  selector: 'client',
  templateUrl: 'Client.component.html',
  styleUrls: ['Client.component.css']
})
export class ClientComponent implements OnInit {
  displayedColumns: string[] = ['clientId', 'clientName', 'processorIdentifier', 'lastActivicty', 'timeZone'];
  clients: ClientModel[] = [];
  error: boolean = true;

  constructor(private clientService: ClientService, public dialog: MatDialog) { }

  ngOnInit() {
    this.FetchClient();
  }

  FetchClient(): void {
      this.clientService.GetClient().subscribe((data: ClientModel[]) => {
        this.clients = data
      }, error => {
        console.log(error)
        this.error = true;
      });
  }

  GetDetails(clickedRow: ClientModel): void {
    this.dialog.open(ClientDetailComponent, {
      data: clickedRow,
    });
  }

  Spin(): boolean {
    return this.error == false && this.clients.length <= 0
  }
}
