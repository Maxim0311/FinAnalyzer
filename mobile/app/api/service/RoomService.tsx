import axios, { AxiosError } from "axios";
import {
  createContext,
  FC,
  useContext,
  useEffect,
  useMemo,
  useState,
} from "react";
import { API_URL } from "../../api";
import { useAuth } from "../../hooks/useAuth";
import { IOperationResult } from "../interfaces/operationResult";
import { IPagination } from "../interfaces/pagination";
import { IRoom, IRoomCreate } from "../interfaces/room";

interface IContext {
  isLoading: boolean;
  error: string | null | undefined;
  rooms: IRoom[];
  roomInfo: IRoom;
  clearError: () => void;

  getAllRooms: (
    skip?: number,
    take?: number,
    searchText?: string
  ) => Promise<void>;

  getRoomsByPersonId: (
    personId: number,
    skip?: number,
    take?: number,
    searchText?: string
  ) => Promise<void>;

  getRoomInfo: (roomId: number) => Promise<void>;

  createRoom: (room: IRoomCreate) => Promise<IOperationResult<number>>;
}

export const RoomServiceContext = createContext<IContext>({} as IContext);

export const RoomServiceProvider: FC<any> = ({ children }) => {
  const { getToken, user } = useAuth();

  const [token, setToken] = useState<string | null>();

  const [isLoading, setIsLoading] = useState(false);
  const [error, setError] = useState<string | null>();

  const [rooms, setRooms] = useState<IRoom[]>(null);
  const [roomInfo, setRoomInfo] = useState<IRoom>(null);

  useEffect(() => {
    getToken().then((jwt) => setToken(jwt));
  }, []);

  const clearError = () => setError(null);

  const getRoomInfo = async (roomId: number) => {
    try {
      setIsLoading(true);
      const { data } = await axios.get<IOperationResult<IRoom>>(
        `${API_URL}/rooms/${roomId}`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );
      if (data.success) {
        setRoomInfo(data.result);
      }
    } catch (e: any) {
      const error = e as AxiosError<IOperationResult<IRoom> | null | undefined>;

      if (error.response?.status === 403) setError("У вас недостаточно прав");
      else setError(error.response?.data?.message);
    } finally {
      setIsLoading(false);
    }
  };

  const getAllRooms = async (
    skip?: number,
    take?: number,
    searchText?: string
  ): Promise<void> => {
    try {
      setIsLoading(true);
      const { data } = await axios.get<IOperationResult<IPagination<IRoom>>>(
        `${API_URL}/rooms?skip=${skip}&take=${take}&searchText=${
          searchText ? searchText : ""
        }`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      if (data.success) setRooms(data.result.items);
      else setError(data.message);
    } catch (e: any) {
      const error = e as AxiosError<
        IOperationResult<IPagination<IRoom>> | null | undefined
      >;

      if (error.response?.status === 403) setError("У вас недостаточно прав");
      else setError(error.response?.data?.message);
    } finally {
      setIsLoading(false);
    }
  };

  const getRoomsByPersonId = async (
    personId: number,
    skip?: number,
    take?: number,
    searchText?: string
  ): Promise<void> => {
    try {
      setIsLoading(true);
      const { data } = await axios.get<IOperationResult<IPagination<IRoom>>>(
        `${API_URL}/rooms/get-by-personid/${personId}?skip=${skip}&take=${take}&searchText=${
          searchText ? searchText : ""
        }`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      if (data.success) {
        setRooms(data.result.items);
      } else {
        setError(data.message);
      }
    } catch (e: any) {
      const error = e as AxiosError<
        IOperationResult<IPagination<IRoom>> | null | undefined
      >;

      if (error.response?.status === 403) {
        setError("У вас недостаточно прав");
      } else {
        setError(error.response?.data?.message);
      }
    } finally {
      setIsLoading(false);
    }
  };

  const createRoom = async (
    room: IRoomCreate
  ): Promise<IOperationResult<any>> => {
    try {
      setIsLoading(true);
      const { data } = await axios.post<IOperationResult<number>>(
        `${API_URL}/rooms/create`,
        {
          personId: user?.id,
          ...room,
        },
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      return data;
    } catch (e) {
      const error = e as AxiosError<IOperationResult<any> | null | undefined>;

      if (error.response?.status === 403) {
        setError("У вас недостаточно прав");
      } else {
        setError(error.response?.data?.message);
      }

      return error.response?.data!;
    } finally {
      setIsLoading(false);
    }
  };

  const value = useMemo(
    () => ({
      isLoading,
      error,
      clearError,
      getAllRooms,
      getRoomsByPersonId,
      createRoom,
      rooms,
      getRoomInfo,
      roomInfo,
    }),
    [rooms, setRooms, getAllRooms, isLoading, error]
  );

  return (
    <RoomServiceContext.Provider value={value}>
      {children}
    </RoomServiceContext.Provider>
  );
};

export const useRoomService = () => useContext(RoomServiceContext);
