import {
  useState,
  useEffect,
  useMemo,
  FC,
  createContext,
  useContext,
} from "react";
import { useAuth } from "../../hooks/useAuth";
import {
  CategoriesStatsResponse,
  PieDiagramItem,
} from "../interfaces/statistic";
import axios, { AxiosError } from "axios";
import { IOperationResult } from "../interfaces/operationResult";
import { API_URL } from "../../api";
import { log } from "react-native-reanimated";

interface IContext {
  isLoading: boolean;
  error: string | null | undefined;
  categoriesItems: PieDiagramItem[];
  clearError: () => void;
  getCategoriesStatistic: (roomId: number) => Promise<void>;
  updateAllStatistic: (roomId: number) => Promise<void>;
}

const StatisticServiceContext = createContext<IContext>({} as IContext);

export const StatisticServiceProvider: FC<any> = ({ children }) => {
  const { getToken, user } = useAuth();

  const [token, setToken] = useState<string | null>();

  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>();

  const [categoriesItems, setCategoriesItems] =
    useState<PieDiagramItem[]>(null);

  useEffect(() => {
    getToken().then((jwt) => setToken(jwt));
  }, []);

  const clearError = () => setError(null);

  const getCategoriesStatistic = async (roomId: number) => {
    try {
      setIsLoading(true);
      const { data } = await axios.get<
        IOperationResult<CategoriesStatsResponse[]>
      >(`${API_URL}/statistic/get-categories-statistic?roomId=${roomId}`, {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      });

      if (data.success) {
        console.log(data);

        setCategoriesItems(
          data.result.map((item) => {
            return {
              name: `% ${item.name}`,
              color: item.color,
              value: item.value,
              legendFontColor: "#7F7F7F",
              legendFontSize: 15,
            };
          })
        );
      } else {
        setError(data.message);
      }
    } catch (e: any) {
      if (e.response?.status === 403) setError("У вас недостаточно прав");
      else setError(e.response?.data?.message);
    } finally {
      setIsLoading(false);
    }
  };

  const updateAllStatistic = async (roomId: number) => {
    await getCategoriesStatistic(roomId);
  };

  const value = useMemo(
    () => ({
      isLoading,
      error,
      clearError,
      getCategoriesStatistic,
      categoriesItems,
      updateAllStatistic,
    }),
    [categoriesItems, isLoading, error]
  );

  return (
    <StatisticServiceContext.Provider value={value}>
      {children}
    </StatisticServiceContext.Provider>
  );
};

export const useStatisticService = () => useContext(StatisticServiceContext);
