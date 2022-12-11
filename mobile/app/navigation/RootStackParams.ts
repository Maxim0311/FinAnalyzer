import { ICategory } from '../api/interfaces/category';

export type RootStackParamList = {
  Home: undefined;
  Auth: undefined;
  Registration: undefined;
  Profile: undefined;
  RoomCreate: undefined;
  Room: undefined;
  RoomMain: undefined;
  Transactions: undefined;
  Settings: undefined;
  Accounts: undefined;
  Categories: undefined;
  CategoriesMain: undefined;
  CategoryCreate: undefined;
  CategoryUpdate: ICategory;
};
