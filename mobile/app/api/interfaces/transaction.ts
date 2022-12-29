import { IAccount } from './account';
import { ICategory } from './category';
interface ITransactionCreate {
  name: string;
  description?: string;
  amount: number;
  categoryId?: number;
  roomId: number;
}

export interface IIncomeTransaction extends ITransactionCreate {
  sender: string;
  destination: number;
}

export interface IExpendTransaction extends ITransactionCreate {
  sender: number;
  destination: string;
}

export interface IPersonTransaction extends ITransactionCreate {
  sender: number;
  destination: number;
}

export interface ITransaction {
  id: number;
  name: string;
  description: string;
  amount: number;
  transactionTypeId: number;
  category: ICategory;
  sender: IAccount;
  destination: IAccount;
  createDate: string;
}
