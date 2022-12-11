import {
  View,
  Text,
  StyleSheet,
  Pressable,
  Touchable,
  TouchableHighlightBase,
} from 'react-native';
import React, { FC } from 'react';
import Icon from 'react-native-vector-icons/AntDesign';

interface IRoomItem {
  name: string;
  description: string;
  onPress: () => void;
}

const RoomItem: FC<IRoomItem> = ({ name, description, onPress }) => {
  return (
    <Pressable
      onPress={onPress}
      style={{ ...styles.container, ...styles.shadow }}
    >
      <View style={{ width: '80%' }}>
        <Text style={styles.name}>{name}</Text>
        <Text style={styles.description}>
          {description.slice(0, 100)}
          {description.length >= 100 && '...'}
        </Text>
      </View>
      <View style={styles.iconWrapper}>
        {/* <Text>Test</Text> */}
        <Icon name="export" size={30} />
      </View>
    </Pressable>
  );
};

const styles = StyleSheet.create({
  container: {
    marginHorizontal: 15,
    backgroundColor: 'white',
    borderRadius: 8,
    paddingVertical: 15,
    paddingHorizontal: 25,
    marginVertical: 10,
    maxHeight: 150,
    flex: 1,
    flexDirection: 'row',
  },
  shadow: {
    shadowColor: '#000',
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
    justifyContent: 'center',
    alignItems: 'flex-end',
    width: '20%',
  },
});

export default RoomItem;
