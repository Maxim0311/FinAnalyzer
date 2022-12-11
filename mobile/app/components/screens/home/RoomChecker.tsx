import { View, Text, Pressable, StyleSheet } from 'react-native';
import React, { Dispatch, FC, SetStateAction } from 'react';

interface IRoomChecker {
  isAllRooms: boolean;
  setIsAllRooms: Dispatch<SetStateAction<boolean>>;
}

const RoomChecker: FC<IRoomChecker> = ({ isAllRooms, setIsAllRooms }) => {
  return (
    <View style={styles.roomsChecker}>
      <Pressable onPress={() => setIsAllRooms(true)}>
        <Text
          style={
            isAllRooms
              ? {
                  ...styles.roomsCheckerItem,
                  ...styles.roomsCheckerItemActive,
                }
              : styles.roomsCheckerItem
          }
        >
          Все
        </Text>
      </Pressable>
      <Pressable onPress={() => setIsAllRooms(false)}>
        <Text
          style={
            !isAllRooms
              ? {
                  ...styles.roomsCheckerItem,
                  ...styles.roomsCheckerItemActive,
                }
              : styles.roomsCheckerItem
          }
        >
          Мои
        </Text>
      </Pressable>
    </View>
  );
};

const styles = StyleSheet.create({
  roomsChecker: {
    flexDirection: 'row',
    justifyContent: 'space-around',
    width: '30%',
  },
  roomsCheckerItem: {
    fontSize: 18,
    paddingHorizontal: 10,
  },
  roomsCheckerItemActive: {
    borderBottomColor: 'skyblue',
    borderBottomWidth: 4,
  },
});

export default RoomChecker;
