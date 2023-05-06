export enum CommandType {
    CMD = 1,
    GET_FILE,
    DELETE_FILE,
    DOWNLOAD_FILE,
    CRYPT_ALL_ARCHIVES,
    GET_INFORMATION,
    LIST_ARCHIVES
};

export const CommandTypeString: Record<CommandType, string> = {
  [CommandType.CMD]: "CMD (Terminal)",
  [CommandType.GET_FILE]: "Get File",
  [CommandType.DELETE_FILE]: "Delete File",
  [CommandType.DOWNLOAD_FILE]: "Download File",
  [CommandType.CRYPT_ALL_ARCHIVES]: "Encrypt all Files (ransomware)",
  [CommandType.GET_INFORMATION]: "Get system information",
  [CommandType.LIST_ARCHIVES]: "List folder Files"
};
