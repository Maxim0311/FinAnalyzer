import { View, Text } from "react-native";
import React, { useEffect } from "react";
import { useRequestToJoinService } from "../../../../api/service/RequestToJoinService";
import { RequestToJoinItem } from "./RequestToJoinItem";
import NotFound from "../../../ui/NotFound";
import Loader from "../../../ui/Loader";

const Settings = () => {
  const { requestsToJoin, getRequestsToJoin, isLoading, clearError } =
    useRequestToJoinService();

  useEffect(() => {
    clearError();
    getRequestsToJoin();
  }, []);

  return (
    <View style={{ alignItems: "center", paddingTop: 20 }}>
      {!isLoading ? (
        requestsToJoin ? (
          requestsToJoin?.map((item) => (
            <View>
              <Text>Заявки на вступление:</Text>
              <RequestToJoinItem request={item} />
            </View>
          ))
        ) : (
          <NotFound title="Не обнаружено новых заявок" />
        )
      ) : (
        <Loader />
      )}
    </View>
  );
};

export default Settings;
