import { View, Text, Pressable, ScrollView } from "react-native";
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
  const { getRoomInfo, roomInfo, isLoading, members, getAllMembers } =
    useRoomService();
  const { getCategoriesStatistic, categoriesItems, error, clearError } =
    useStatisticService();

  useEffect(() => {
    clearError();
    setRoomId(route.params.roomId);
    setTimeout(() => {
      getCategoriesStatistic(roomId);
      getRoomInfo(roomId);
      getAllMembers();
    }, 20);
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
        {categoriesItems?.length !== 0 ? (
          <View style={{ alignItems: "center" }}>
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
        ) : (
          <Text style={{ textAlign: "center", fontSize: 20, padding: 10 }}>
            В данной комнате пока нет ни одной совершённой операции
          </Text>
        )}

        {/* <Text style={{ fontSize: 20, textAlign: "center", marginTop: 10 }}>
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
        )} */}
      </View>
      <View style={{ width: "80%", marginTop: 20 }}>
        <Text style={{ fontSize: 20 }}>Участники комнаты:</Text>
        <ScrollView style={{ width: "100%", minHeight: 200 }}>
          {members?.map((item) => (
            <Text style={{ fontSize: 15 }}>
              {item.login} ({item.lastname} {item.firstname}) {item.roomRole}
            </Text>
          ))}
        </ScrollView>
      </View>
    </View>
  );
};

export default RoomMain;
