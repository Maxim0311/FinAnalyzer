import { View, Text } from 'react-native';
import React, {
  createContext,
  FC,
  useContext,
  useEffect,
  useMemo,
  useState,
} from 'react';
import { ICategory } from '../interfaces/category';
import { useAuth } from '../../hooks/useAuth';
import axios from 'axios';
import { API_URL } from '../../api';
import { IOperationResult } from '../interfaces/operationResult';
import { useRoom } from '../../providers/RoomProvider';

interface IContext {
  isLoading: boolean;
  error: string | null | undefined;
  categories: ICategory[];
  clearError: () => void;
  getAllCategories: () => Promise<void>;
}

const CategoryServiceContext = createContext<IContext>({} as IContext);

export const CategoryServiceProvider: FC = ({ children }) => {
  const { getToken, user } = useAuth();

  const { roomId } = useRoom();

  const [token, setToken] = useState<string | null>();

  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>();

  const [categories, setCategories] = useState<ICategory[]>(null);

  const clearError = () => setError(null);

  useEffect(() => {
    getToken().then(jwt => setToken(jwt));
  }, []);

  const getAllCategories = async () => {
    try {
      setIsLoading(true);

      const { data } = await axios.get<IOperationResult<ICategory[]>>(
        `${API_URL}/categories/${roomId}`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      if (data.success) setCategories(data.result);
      else setError(data.message);
    } catch (e: any) {
      if (e.response?.status === 403) {
        setError('У вас недостаточно прав');
      } else {
        setError(e.response?.data?.message);
      }
    } finally {
      setIsLoading(false);
    }
  };

  const value = useMemo(
    () => ({
      isLoading,
      error,
      setError,
      categories,
      clearError,
      getAllCategories,
    }),
    [isLoading, error, categories]
  );

  return (
    <CategoryServiceContext.Provider value={value}>
      {children}
    </CategoryServiceContext.Provider>
  );
};

export const useCategoryService = () => useContext(CategoryServiceContext);
