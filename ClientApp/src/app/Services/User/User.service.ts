import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { UserModel } from "../../Models/User/User.Model";
import { UserLoginModel } from "../../Models/User/UserLogin.model";
import { BackendUrl } from "../Utils/backendurl.service";

@Injectable()
export class UserService {

  constructor(private http: HttpClient, private backendUrlService: BackendUrl) {

  }

  GetUser(): Observable<UserModel[]> {
    return this.http.post<UserModel[]>(this.backendUrlService.GetUser(), {});
  }

  Login(userLoginModel: UserLoginModel): Observable<unknown> {
    return this.http.post(this.backendUrlService.Login(), userLoginModel);
  }
}
