import { Component, OnInit } from "@angular/core";
import { UserModel } from "../Models/User/User.model";
import { UserService } from "./User.service";


@Component({
  selector: 'user',
  templateUrl: 'User.component.html',
  styleUrls: ['User.component.css']
})
export class UserComponent implements OnInit {
  users: UserModel[] = [];
  displayedColumns: string[] = ['userId', 'username', 'oSVersion', 'lastActivicty'];

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
}
