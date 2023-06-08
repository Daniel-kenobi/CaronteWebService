import { Component, OnInit } from '@angular/core';
import { UserLoginModel } from '../../Models/User/UserLogin.model';
import { UserService } from '../../Services/User/User.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  wrongCredentials: boolean = false;

  email: string = '';
  password: string = '';

  constructor(private userService: UserService) {

  }

  ngOnInit(): void {

  }

  Login(userLoginModel: UserLoginModel): void {
    var response = this.userService.Login(userLoginModel).subscribe((data: any) => {
    },
      (error: Error) => {
        this.wrongCredentials = true;
      }
    )
  }

  Enter(): void {
    const userLoginModel: UserLoginModel = {
      userName: this.email,
      password: this.password
    };

    this.Login(userLoginModel);
  }
}
