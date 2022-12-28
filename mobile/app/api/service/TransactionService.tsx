import { View, Text } from 'react-native';
import React, {
  createContext,
  FC,
  PropsWithChildren,
  useContext,
  useEffect,
  useMemo,
  useState,
} from 'react';
import {
  IExpendTransaction,
  IIncomeTransaction,
  IPersonTransaction,
} from '../interfaces/transaction';
import { useAuth } from '../../hooks/useAuth';
import { useRoom } from '../../providers/RoomProvider';
import axios from 'axios';
import { API_URL } from '../../api';
import { IOperationResult } from '../interfaces/operationResult';

interface IContext {
  isLoading: boolean;
  error: string | null | undefined;
  //   accounts: IAccount[];
  clearError: () => void;
  //   getAllAccounts: () => Promise<boolean>;
  makeIncomeTransaction: (transaction: IIncomeTransaction) => Promise<boolean>;
  makeExpendTransaction: (transaction: IExpendTransaction) => Promise<boolean>;
  makePersonTransaction: (transaction: IPersonTransaction) => Promise<boolean>;
}

const TransactionServiceContext = createContext<IContext>({} as IContext);

export const TransactionServiceProvider: FC = ({ children }) => {
  const { getToken, user } = useAuth();
  const { roomId } = useRoom();

  const [token, setToken] = useState<string | null>();

  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>();

  //   const [accounts, setAccounts] = useState<IAccount[]>(null);

  const clearError = () => setError(null);

  useEffect(() => {
    getToken().then(jwt => setToken(jwt));
  }, []);

  const makeIncomeTransaction = async (transaction: IIncomeTransaction) => {
    try {
      setIsLoading(true);

      const { data } = await axios.post<IOperationResult<any>>(
        `${API_URL}/transaction/make-income-transaction`,
        transaction,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      if (data.success) {
        return true;
      } else {
        setError(data.message);
        return false;
      }
    } catch (e: any) {
      if (e.response?.status === 403) {
        setError('У вас недостаточно прав');
      } else {
        setError(e.response?.data?.message);
      }
      return false;
    } finally {
      setIsLoading(false);
    }
  };

  const makeExpendTransaction = async (transaction: IExpendTransaction) => {
    try {
      setIsLoading(true);

      const { data } = await axios.post<IOperationResult<any>>(
        `${API_URL}/transaction/make-expend-transaction`,
        transaction,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      if (data.success) {
        return true;
      } else {
        setError(data.message);
        return false;
      }
    } catch (e: any) {
      if (e.response?.status === 403) {
        setError('У вас недостаточно прав');
      } else {
        setError(e.response?.data?.message);
      }
      return false;
    } finally {
      setIsLoading(false);
    }
  };

  const makePersonTransaction = async (transaction: IPersonTransaction) => {
    try {
      setIsLoading(true);

      const { data } = await axios.post<IOperationResult<any>>(
        `${API_URL}/transaction/make-person-transaction`,
        transaction,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      if (data.success) {
        return true;
      } else {
        setError(data.message);
        return false;
      }
    } catch (e: any) {
      if (e.response?.status === 403) {
        setError('У вас недостаточно прав');
      } else {
        setError(e.response?.data?.message);
      }
      return false;
    } finally {
      setIsLoading(false);
    }
  };

  const value = useMemo(
    () => ({
      isLoading,
      error,
      setError,
      clearError,
      makeIncomeTransaction,
      makeExpendTransaction,
      makePersonTransaction,
    }),
    [isLoading, error]
  );

  return (
    <TransactionServiceContext.Provider value={value}>
      {children}
    </TransactionServiceContext.Provider>
  );
};

export const useTransactionService = () =>
  useContext(TransactionServiceContext);
