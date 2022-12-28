export interface IAccount {
  id: number;
  name: string;
  balance: number;
  accountType: IAccountType;
  roomId: number;
  personName?: string;
}

export interface IAccountCreate {
  name: string;
  accountType: number;
}

export interface IAccountType {
  id: number;
  title: string;
}
