import { Component, Inject, Input, OnInit } from "@angular/core";

import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ClientModel } from "../../../Models/Client/Client.model";
import { ClientCommand } from "../../../Models/Client/ClientCommand.model";
import { CommandType, CommandTypeString } from "../../../Models/Enum/commandType.enum";
import { ClientService } from "../../../Services/Client/Client.service";

@Component({
  selector: 'ClientDetail',
  templateUrl: 'ClientDetail.component.html',
  styleUrls: ['ClientDetail.component.css'],
})
export class ClientDetailComponent implements OnInit  {
  commandTypeString: Record<CommandType, string> = CommandTypeString;
  commandTypes: string[] = [];
  clientCommand: ClientCommand | Record<string, never> = {};

  constructor(public dialogRef: MatDialogRef<ClientDetailComponent>,
    @Inject(MAT_DIALOG_DATA) public data: ClientModel,
    private userService: ClientService) {
  }

  ngOnInit() {
    this.commandTypes = Object.values(this.commandTypeString);
  }

  parameterChanged(event: Event): void {
    this.clientCommand.parameter = (event.target as HTMLTextAreaElement).value;
  }

  onSelected(value: HTMLSelectElement): void {
    this.clientCommand.command = value.selectedIndex;
  }

  sendCommand(): void {
    this.clientCommand.clientModel = this.data;
    this.userService.SendCommand(this.clientCommand as ClientCommand);
  }
}
