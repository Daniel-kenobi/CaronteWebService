import { Component, Inject, Input } from "@angular/core";

import { UserModel } from "../../Models/User/User.model";
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'UserDetail',
  templateUrl: 'UserDetail.component.html',
  styleUrls: ['UserDetail.component.css'],
})
export class UserDetailComponent  {

  constructor(public dialogRef: MatDialogRef<UserDetailComponent>, @Inject(MAT_DIALOG_DATA) public data: UserModel) {

  }
}
