import { Component, OnInit } from "@angular/core";

import { MatDialog } from "@angular/material/dialog";
import { UserModel } from "../Models/User/User.model";
import { UserDetailComponent } from "./Detail/UserDetail.component";
import { UserService } from "./User.service";

@Component({
  selector: 'user',
  templateUrl: 'User.component.html',
  styleUrls: ['User.component.css']
})
export class UserComponent implements OnInit {
  displayedColumns: string[] = ['userId', 'username', 'oSVersion', 'lastActivicty'];
  users: UserModel[] = [];
   
  constructor(private userService: UserService, public dialog: MatDialog) {

  }

  ngOnInit() {
    this.FetchUser();
  }

  FetchUser(): void {
    this.userService.GetUser().subscribe((data: UserModel[]) => {
      this.users = data
    });
  }

  GetDetails(clickedRow: UserModel): void {
    const dialogRef = this.dialog.open(UserDetailComponent, {
      data: clickedRow,
    });
  }
}
