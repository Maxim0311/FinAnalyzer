import { ICategoryUpdate } from "../api/interfaces/category";

export type RootStackParamList = {
  Home: undefined;
  Auth: undefined;
  Registration: undefined;
  Profile: undefined;
  RoomCreate: undefined;
  Room: undefined;
  RoomMain: undefined;
  RoomMainMain: undefined;
  RequestToJoin: undefined;
  Transactions: undefined;
  TransactionsMain: undefined;
  TransactionsCreate: undefined;
  IncomeTransactionsCreate: undefined;
  ExpendTransactionsCreate: undefined;
  PersonTransactionsCreate: undefined;
  Settings: undefined;
  Accounts: undefined;
  AccountsCreate: undefined;
  AccountsMain: undefined;
  Categories: undefined;
  CategoriesMain: undefined;
  CategoryCreate: undefined;
  CategoryUpdate: ICategoryUpdate;
};
