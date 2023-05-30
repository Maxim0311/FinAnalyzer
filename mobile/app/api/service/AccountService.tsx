import React, {
  createContext,
  FC,
  useContext,
  useEffect,
  useMemo,
  useState,
} from "react";
import { useAuth } from "../../hooks/useAuth";
import axios from "axios";
import { API_URL } from "../../api";
import { IOperationResult } from "../interfaces/operationResult";
import { useRoom } from "../../providers/RoomProvider";
import { IAccount, IAccountCreate } from "../interfaces/account";
import { acc } from "react-native-reanimated";

interface IContext {
  isLoading: boolean;
  error: string | null | undefined;
  accounts: IAccount[];
  clearError: () => void;
  getAllAccounts: () => Promise<boolean>;
  createAccount: (account: IAccountCreate) => Promise<boolean>;
}

const AccountServiceContext = createContext<IContext>({} as IContext);

export const AccountServiceProvider: FC<any> = ({ children }) => {
  const { getToken, user } = useAuth();
  const { roomId } = useRoom();

  const [token, setToken] = useState<string | null>();

  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>();

  const [accounts, setAccounts] = useState<IAccount[]>(null);

  const clearError = () => setError(null);

  useEffect(() => {
    getToken().then((jwt) => setToken(jwt));
  }, []);

  const createAccount = async (account: IAccountCreate) => {
    try {
      setIsLoading(true);

      const { data } = await axios.post<IOperationResult<number>>(
        `${API_URL}/account/create`,
        {
          name: account.name,
          accountTypeId: account.accountType,
          roomId: roomId,
          personId: account.accountType === 1 ? user.id : null,
        },
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
        setError("У вас недостаточно прав");
      } else {
        setError(e.response?.data?.message);
      }
      return false;
    } finally {
      setIsLoading(false);
    }
  };

  const getAllAccounts = async () => {
    try {
      setIsLoading(true);

      const { data } = await axios.get<IOperationResult<IAccount[]>>(
        `${API_URL}/account/${roomId}`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      if (data.success) {
        setAccounts(data.result);
        return true;
      } else {
        setError(data.message);
        return false;
      }
    } catch (e: any) {
      if (e.response?.status === 403) {
        setError("У вас недостаточно прав");
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
      accounts,
      getAllAccounts,
      createAccount,
    }),
    [isLoading, error, accounts]
  );

  return (
    <AccountServiceContext.Provider value={value}>
      {children}
    </AccountServiceContext.Provider>
  );
};

export const useAccountService = () => useContext(AccountServiceContext);
