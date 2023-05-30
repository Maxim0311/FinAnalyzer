import { View, Text } from "react-native";
import React, {
  createContext,
  Dispatch,
  FC,
  SetStateAction,
  useContext,
  useState,
} from "react";

interface IContext {
  roomId: number | null;
  setRoomId: Dispatch<SetStateAction<number | null>>;
}

export const RoomContext = createContext<IContext>({} as IContext);

export const RoomProvider: FC<any> = ({ children }) => {
  const [roomId, setRoomId] = useState<number | null>(null);

  return (
    <RoomContext.Provider value={{ roomId, setRoomId }}>
      {children}
    </RoomContext.Provider>
  );
};

export const useRoom = () => useContext(RoomContext);

export default RoomProvider;
