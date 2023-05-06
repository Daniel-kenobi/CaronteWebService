import { Component, Inject, Input, OnInit } from "@angular/core";

import { UserModel } from "../../Models/User/User.model";
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CommandType, CommandTypeString } from "../../Models/Enum/commandType.enum";
import { UserCommand } from "../../Models/User/UserCommand.model";
import { FormControl } from "@angular/forms";

@Component({
  selector: 'UserDetail',
  templateUrl: 'UserDetail.component.html',
  styleUrls: ['UserDetail.component.css'],
})
export class UserDetailComponent implements OnInit {
  commandTypeString: Record<CommandType, string> = CommandTypeString;
  commandTypes: string[] = [];
  userCommand: UserCommand | Record<string, never> = {};

  constructor(public dialogRef: MatDialogRef<UserDetailComponent>, @Inject(MAT_DIALOG_DATA) public data: UserModel) {
  }

  ngOnInit() {
    this.commandTypes = Object.values(this.commandTypeString);
  }

  parameterChanged(event: Event): void {
    this.userCommand.parameter = (event.target as HTMLTextAreaElement).value;
  }

  SendCommand(): void {
    this.userCommand.userModel = this.data;
  }
}
