import { Component, OnInit } from "@angular/core";

import { UserModel } from "../Models/User/User.model";
import { UserService } from "./User.service";


@Component({
  selector: 'user',
  templateUrl: 'User.component.html',
  styleUrls: ['User.component.css']
})
export class UserComponent implements OnInit {
  displayedColumns: string[] = ['userId', 'username', 'oSVersion', 'lastActivicty'];

  users: UserModel[] = [];
  clickedRow: UserModel | null = null;

  constructor(private userService: UserService) {
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
    this.clickedRow = clickedRow;
  }
}
