import { Alert } from "react-native";
import React, {
  createContext,
  FC,
  useContext,
  useEffect,
  useMemo,
  useState,
} from "react";
import {
  ICategory,
  ICategoryCreate,
  ICategoryUpdate,
} from "../interfaces/category";
import { useAuth } from "../../hooks/useAuth";
import axios from "axios";
import { API_URL } from "../../api";
import { IOperationResult } from "../interfaces/operationResult";
import { useRoom } from "../../providers/RoomProvider";

interface IContext {
  isLoading: boolean;
  error: string | null | undefined;
  categories: ICategory[];
  clearError: () => void;
  getAllCategories: () => Promise<boolean>;
  createCategory: (category: ICategoryCreate) => Promise<boolean>;
  updateCategory: (category: ICategoryUpdate) => Promise<boolean>;
  deleteCategory: (id: number) => Promise<boolean>;
}

const CategoryServiceContext = createContext<IContext>({} as IContext);

export const CategoryServiceProvider: FC<any> = ({ children }) => {
  const { getToken, user } = useAuth();
  const { roomId } = useRoom();

  const [token, setToken] = useState<string | null>();

  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>();

  const [categories, setCategories] = useState<ICategory[]>(null);

  const clearError = () => setError(null);

  useEffect(() => {
    getToken().then((jwt) => setToken(jwt));
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

      if (data.success) {
        setCategories(data.result);
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

  const createCategory = async (category: ICategoryCreate) => {
    try {
      setIsLoading(true);

      const { data } = await axios.post<IOperationResult<number>>(
        `${API_URL}/categories/create`,
        {
          roomId: roomId,
          ...category,
        },
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      if (data.success) {
        Alert.alert("Категория успешно создана");
        return true;
      } else {
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

  const updateCategory = async (category: ICategoryUpdate) => {
    try {
      setIsLoading(true);
      console.log(category);

      const { data } = await axios.put<IOperationResult<number>>(
        `${API_URL}/categories/update`,
        category,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );
      console.log(data);

      if (data.success) return true;
      return false;
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

  const deleteCategory = async (id: number) => {
    try {
      setIsLoading(true);

      const { data } = await axios.delete<IOperationResult<null>>(
        `${API_URL}/categories/delete/${id}`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      if (data.success) return true;
      return false;
    } catch (e: any) {
      console.log(e);

      if (e.response?.status === 403) {
        setError("У вас недостаточно прав");
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
      createCategory,
      updateCategory,
      deleteCategory,
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
