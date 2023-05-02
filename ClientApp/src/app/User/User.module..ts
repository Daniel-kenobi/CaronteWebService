import { NgModule } from "@angular/core";

import { MatTableModule } from '@angular/material/table';
import { UserService } from "./User.service";

@NgModule({
  imports: [
    MatTableModule,
  ],
  exports: [
    MatTableModule,
  ],
  providers: [
    UserService
  ]
})
export class UserModule { }
