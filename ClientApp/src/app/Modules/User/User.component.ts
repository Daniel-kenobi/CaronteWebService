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
  error: boolean = false;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
    this.FetchUsers();
  }

  FetchUsers() {
    this.userService.GetUser().subscribe(data => { this.users = data },
      error => {
       console.log(error), 
       this.error = true;
      });
  }

  Spin(): boolean {
    return this.error == false && this.users.length <= 0
  }
}
