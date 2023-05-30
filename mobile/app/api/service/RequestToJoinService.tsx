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
import { useRoom } from "../../providers/RoomProvider";
import { IRequestToJoin } from "../interfaces/requestToJoin";
import { useRoomService } from "./RoomService";

interface IContext {
  isLoading: boolean;
  error: string | null | undefined;
  clearError: () => void;
  apply: (roomId: number, personId: number) => Promise<void>;
  accept: (requestId: number) => Promise<void>;
  reject: (requestId: number) => Promise<void>;
  getRequestsToJoin: () => Promise<void>;
  requestsToJoin: IRequestToJoin[];
}

const RequestToJoinServiceContext = createContext<IContext>({} as IContext);

export const RequestToJoinServiceProvider: FC<any> = ({ children }) => {
  const { getToken, user } = useAuth();

  const { roomId } = useRoom();

  const { getAllMembers } = useRoomService();

  const [token, setToken] = useState<string | null>();

  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>();

  const [requestsToJoin, setRequestsToJoin] = useState<IRequestToJoin[]>(null);

  useEffect(() => {
    getToken().then((jwt) => setToken(jwt));
  }, []);

  const clearError = () => setError(null);

  const apply = async (roomId: number, personId: number) => {
    try {
      setIsLoading(true);
      const { data } = await axios.get(
        `${API_URL}/request-to-join/apply?roomId=${roomId}&personId=${personId}`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      if (data.success) {
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

  const accept = async (requestId: number) => {
    try {
      setIsLoading(true);
      const { data } = await axios.get(
        `${API_URL}/request-to-join/accept?requestId=${requestId}`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      if (data.success) {
        getAllMembers();
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

  const reject = async (requestId: number) => {
    try {
      setIsLoading(true);
      const { data } = await axios.get(
        `${API_URL}/request-to-join/reject?requestId=${requestId}`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      if (data.success) {
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

  const getRequestsToJoin = async () => {
    try {
      setIsLoading(true);
      const { data } = await axios.get<IOperationResult<IRequestToJoin[]>>(
        `${API_URL}/request-to-join/${roomId}`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      if (data.success) {
        setRequestsToJoin(data.result);
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

  const value = useMemo(
    () => ({
      isLoading,
      error,
      clearError,
      apply,
      accept,
      reject,
      getRequestsToJoin,
      requestsToJoin,
    }),
    [isLoading, error]
  );

  return (
    <RequestToJoinServiceContext.Provider value={value}>
      {children}
    </RequestToJoinServiceContext.Provider>
  );
};

export const useRequestToJoinService = () =>
  useContext(RequestToJoinServiceContext);
