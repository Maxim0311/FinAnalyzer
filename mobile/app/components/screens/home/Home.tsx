import {
  View,
  Text,
  StyleSheet,
  ScrollView,
  Alert,
  RefreshControl,
} from "react-native";
import React, { FC, useEffect, useState } from "react";
import { useAuth } from "../../../hooks/useAuth";
import RoomItem from "./RoomItem";
import { useRoomService } from "../../../api/service/RoomService";
import { IPagination } from "../../../api/interfaces/pagination";
import { IRoom } from "../../../api/interfaces/room";
import { IOperationResult } from "../../../api/interfaces/operationResult";
import Field from "../../ui/Field";
import NotFound from "../../ui/NotFound";
import RoomChecker from "./RoomChecker";
import HomeMenu from "./HomeMenu";
import Icon from "react-native-vector-icons/MaterialIcons";
import { MenuOption } from "react-native-popup-menu";
import { useNavigation } from "@react-navigation/native";
import { log } from "react-native-reanimated";
import { useRequestToJoinService } from "../../../api/service/RequestToJoinService";

const Home: FC = () => {
  const { user } = useAuth();

  const navigation = useNavigation();

  const {
    getAllRooms,
    getRoomsByPersonId,
    isLoading,
    error,
    clearError,
    rooms,
  } = useRoomService();

  const { apply } = useRequestToJoinService();

  const [data, setData] = useState<
    IOperationResult<IPagination<IRoom>> | null | undefined
  >(null);

  const [searchText, setSearchText] = useState("");

  const [isAllRooms, setIsAllRooms] = useState(true);

  const fetchData = () => {
    if (isAllRooms) {
      fetchAllRooms();
    } else {
      fetchPersonRooms();
    }
  };

  const fetchAllRooms = () => {
    clearError();
    getAllRooms(0, 20, searchText);
  };

  const fetchPersonRooms = () => {
    clearError();
    getRoomsByPersonId(user!.id, 0, 20, searchText);
  };

  const roomPressHandler = (id: number) => {
    if (isAllRooms) {
      Alert.alert(
        "Подать заявку на вступление",
        "Вы уверены что хотите подать заявку на вступление в эту комнату?",
        [
          {
            text: "Отмена",
            style: "cancel",
          },
          {
            text: "Подтвердить",
            onPress: () => {
              apply(id, user.id);
              Alert.alert("Заявка подана");
            },
            style: "default",
          },
        ],
        {
          cancelable: true,
        }
      );
    } else {
      navigation.navigate("Room", {
        screen: "RoomMain",
        params: { roomId: id },
      } as any);
    }
  };

  const room: IRoom = {} as IRoom;

  useEffect(() => {
    fetchAllRooms();
  }, []);

  useEffect(() => {
    let debouncer = setTimeout(() => {
      fetchData();
    }, 200);
    return () => {
      clearTimeout(debouncer);
    };
  }, [searchText]);

  useEffect(() => {
    fetchData();
  }, [isAllRooms]);

  return (
    <View style={styles.container}>
      <Text style={styles.headText}>Комнаты</Text>
      <View
        style={{
          width: "90%",
          marginBottom: 10,
          flexDirection: "row",
          justifyContent: "space-between",
          alignItems: "center",
        }}
      >
        <Field
          onChange={(value) => setSearchText(value)}
          value={searchText}
          placeholder="Поиск..."
          style={{ width: "85%" }}
          isSearch
        />
        <HomeMenu>
          <MenuOption
            style={{ flexDirection: "row", alignItems: "center" }}
            onSelect={() => navigation.navigate("RoomCreate")}
          >
            <Icon name="add-chart" size={30} />
            <Text style={{ fontSize: 20, marginLeft: 10 }}>
              Создать комнату
            </Text>
          </MenuOption>
        </HomeMenu>
      </View>

      <RoomChecker isAllRooms={isAllRooms} setIsAllRooms={setIsAllRooms} />

      <ScrollView
        refreshControl={
          <RefreshControl
            enabled
            refreshing={isLoading}
            onRefresh={fetchData}
          />
        }
        style={{ width: "100%" }}
      >
        {rooms &&
          rooms.map((item) => (
            <RoomItem
              key={item.id}
              name={item.name}
              description={item.description}
              onPress={() => roomPressHandler(item.id)}
            />
          ))}

        {error && <NotFound title={error!} styles={{ marginTop: 20 }} />}
      </ScrollView>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    paddingTop: 15,
    flex: 1,
    alignItems: "center",
  },
  headText: {
    marginTop: 10,
    fontSize: 30,
  },
});

export default Home;
