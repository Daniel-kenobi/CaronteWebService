import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { ClientModel } from "../../Models/Client/Client.model";
import { ClientCommand } from "../../Models/Client/ClientCommand.model";
import { BackendUrl } from "../Utils/backendurl.service";


@Injectable()
export class ClientService {
  constructor(private http: HttpClient, private backendUrlService: BackendUrl) {
  }

  GetClient(): Observable<ClientModel[]> {
    return this.http.post<ClientModel[]>(this.backendUrlService.GetClient(), {});
  }

  SendCommand(clientCommand: ClientCommand): Observable<unknown> {
    return this.http.post(this.backendUrlService.SendCommand(), clientCommand);
  }
}
