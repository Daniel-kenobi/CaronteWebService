import { Inject, Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class BackendUrl {
  private baseUrl: string

  constructor() {
    this.baseUrl = `https://localhost:7255/`;
  }

  GetUser(): string
  {
    return `${this.baseUrl}user/GetUsers`;
  }
}
