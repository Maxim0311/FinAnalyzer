import {
  View,
  Text,
  StyleSheet,
  Pressable,
  Touchable,
  TouchableHighlightBase,
} from "react-native";
import React, { FC } from "react";
import { IRequestToJoin } from "../../../../api/interfaces/requestToJoin";
import Icon from "../../../ui/Icon";
import { useRequestToJoinService } from "../../../../api/service/RequestToJoinService";

interface IRequestToJoinItem {
  request: IRequestToJoin;
}

export const RequestToJoinItem: FC<IRequestToJoinItem> = ({ request }) => {
  const { accept, reject, getRequestsToJoin } = useRequestToJoinService();

  const onAccept = () => {
    accept(request.id);
    getRequestsToJoin();
  };
  const onReject = () => {
    reject(request.id);
    getRequestsToJoin();
  };
  return (
    <View style={{ ...styles.container, ...styles.shadow, width: 370 }}>
      <View>
        <Text>{new Date(request.dateTime).toLocaleString("ru-RU")}</Text>
        <Text>Логин: {request.person.login}</Text>
        <Text>
          ФИО: {request.person.lastname} {request.person.firstname}{" "}
          {request.person.middlename}
        </Text>
      </View>
      <View style={styles.iconWrapper}>
        <View style={{ flexDirection: "row" }}>
          <Pressable onPress={onReject}>
            <Icon
              style={{ marginRight: 10 }}
              author="MaterialCommunityIcons"
              name="cancel"
              size={30}
            />
          </Pressable>
          <Pressable onPress={onAccept}>
            <Icon author="Feather" name="check" size={30} />
          </Pressable>
        </View>
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    marginHorizontal: 15,
    backgroundColor: "white",
    borderRadius: 8,
    paddingVertical: 15,
    paddingHorizontal: 25,
    marginVertical: 10,
    maxHeight: 150,
    flexDirection: "row",
  },
  shadow: {
    shadowColor: "#000",
    shadowOffset: {
      width: 0,
      height: 7,
    },
    shadowOpacity: 0.41,
    shadowRadius: 9.11,

    elevation: 14,
  },
  name: {
    fontSize: 20,
  },
  description: {
    opacity: 0.5,
  },
  iconWrapper: {
    flex: 1,
    justifyContent: "center",
    alignItems: "flex-end",
    width: "20%",
  },
});

export default RequestToJoinItem;
