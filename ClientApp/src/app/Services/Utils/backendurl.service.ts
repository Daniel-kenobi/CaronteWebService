import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class BackendUrl {
  private baseUrl: string

  constructor() {
    this.baseUrl = `https://localhost:7255/`;
  }

  GetClient(): string
  {
    return `${this.baseUrl}client/GetClient`;
  }

  SendCommand(): string
  {
    return `${this.baseUrl}client/SendCommand`;
  }

  GetUser(): string {
    return `${this.baseUrl}client/GetUser`;
  }
}
