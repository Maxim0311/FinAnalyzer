import { View, Text, Pressable } from "react-native";
import React, { FC, useEffect } from "react";
import Icon from "react-native-vector-icons/Ionicons";
import { useAuth } from "../../../hooks/useAuth";
import { useNavigation } from "@react-navigation/native";

interface IProfile {
  route: any;
}

const Profile: FC<IProfile> = ({ route }) => {
  const { logout } = useAuth();
  const navigation = useNavigation();

  return (
    <View style={{ left: "80%", top: "3%" }}>
      <Pressable onPress={logout}>
        <Icon name="md-exit-outline" size={30} />
        <Text>Выход</Text>
      </Pressable>
    </View>
  );
};

export default Profile;
