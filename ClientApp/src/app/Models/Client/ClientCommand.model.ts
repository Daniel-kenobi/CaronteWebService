import { CommandType } from "../Enum/commandType.enum"
import { ClientModel } from "./Client.model";

export interface ClientCommand {
  clientModel: ClientModel;
  command: CommandType;
  parameter: any;
}
