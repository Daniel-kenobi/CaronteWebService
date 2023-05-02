import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { UserModel } from "../Models/User/User.model";
import { BackendUrl } from "../Services/backendurl.service";

@Injectable()
export class UserService {
  constructor(private http: HttpClient, private backendUrlService: BackendUrl) {
  }

  GetUser(): Observable<UserModel[]> {
    return this.http.post<UserModel[]>(this.backendUrlService.GetUser(), {});
  }
}