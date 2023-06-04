import { Component, OnInit } from "@angular/core";
import { UserModel } from "../../Models/User/User.Model";
import { UserService } from "../../Services/User/User.service";

@Component({
  selector: 'user',
  templateUrl: 'User.component.html',
  styleUrls: ['User.component.css']
})
export class UserComponent implements OnInit {
  users: UserModel[] = [];
  displayedColumns: string[] = [];

  constructor(private userService: UserService) {

  }

  ngOnInit(): void {
    this.userService.GetUser().subscribe(data => { this.users = data });
  }
}
