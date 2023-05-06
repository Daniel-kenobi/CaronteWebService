import { CommandType } from "../Enum/commandType.enum"
import { UserModel } from "./User.model";

export interface UserCommand {
  userModel: UserModel;
  command: CommandType;
  parameter: string;
}
