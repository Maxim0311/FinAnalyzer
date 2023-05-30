import { View, Text, Pressable } from "react-native";
import React, { FC, useEffect } from "react";
import { useNavigation } from "@react-navigation/native";
import { useRoom } from "../../../../providers/RoomProvider";
import Button from "../../../ui/Button";
import { PieChart } from "react-native-chart-kit";
import { useStatisticService } from "../../../../api/service/StatisticService";
import Error from "../../../ui/Error";
import { useRoomService } from "../../../../api/service/RoomService";
import Loader from "../../../ui/Loader";

interface IRoomMain {
  route: any;
}

const RoomMain: FC<IRoomMain> = ({ route }) => {
  const navigation = useNavigation();

  const { roomId, setRoomId } = useRoom();
  const { getRoomInfo, roomInfo, isLoading } = useRoomService();
  const { getCategoriesStatistic, categoriesItems, error, clearError } =
    useStatisticService();

  useEffect(() => {
    clearError();
    setRoomId(route.params.roomId);
    getCategoriesStatistic(roomId);
    getRoomInfo(roomId);
  }, []);

  const chartConfig = {
    backgroundGradientFrom: "#1E2923",
    backgroundGradientFromOpacity: 0,
    backgroundGradientTo: "#08130D",
    backgroundGradientToOpacity: 0.5,
    color: (opacity = 1) => `rgba(26, 255, 146, ${opacity})`,
    strokeWidth: 3, // optional, default 3
    barPercentage: 0.5,
    useShadowColorFromDataset: false, // optional
  };

  return (
    <View style={{ alignItems: "center" }}>
      <View>
        {isLoading ? (
          <Loader />
        ) : (
          <View
            style={{ width: 350, marginVertical: 20, alignItems: "center" }}
          >
            <Text style={{ fontSize: 25 }}>{roomInfo?.name}</Text>
            <Text style={{ opacity: 0.5, fontSize: 15 }}>
              {roomInfo?.description}
            </Text>
          </View>
        )}
      </View>
      {error && <Error text={error} />}
      <View
        style={{
          borderColor: "black",
          borderRadius: 10,
          backgroundColor: "#d5d6f2",
          alignItems: "center",
        }}
      >
        <Text style={{ fontSize: 20, textAlign: "center", marginTop: 10 }}>
          Самые популярные категории
        </Text>
        {categoriesItems && (
          <PieChart
            data={categoriesItems}
            width={380}
            height={210}
            chartConfig={chartConfig}
            accessor={"value"}
            backgroundColor={"transparent"}
            paddingLeft={"0"}
            absolute
          />
        )}
        <Button
          style={{ marginTop: 10, width: 300, marginBottom: 20 }}
          title="Подробная статистика"
          colors={["#3914AF", "white"]}
          onPress={() => {}}
        />
      </View>
      <View style={{ width: "80%", marginTop: 20 }}>
        <Button
          style={{ marginTop: 10 }}
          title="Участники комнаты"
          onPress={() => {}}
        />
      </View>
    </View>
  );
};

export default RoomMain;
