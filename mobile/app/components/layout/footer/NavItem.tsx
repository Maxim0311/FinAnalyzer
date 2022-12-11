import { View, Text, Pressable } from 'react-native';
import React, { FC } from 'react';
import { AntDesign } from '@expo/vector-icons';
import { IFooterItem } from './types';
import Icon from 'react-native-vector-icons/FontAwesome';
import { RootStackParamList } from '../../../navigation/RootStackParams';

interface INavItem {
  item: IFooterItem;
  navigate: (screenName: keyof RootStackParamList) => void;
  currentRoute: string;
}

const NavItem: FC<INavItem> = ({ item, navigate, currentRoute }) => {
  const isActive = currentRoute === item.title;

  return (
    <Pressable
      onPress={() => navigate(item.title)}
      style={{ justifyContent: 'center' }}
    >
      <View
        style={{
          flex: 1,
          justifyContent: 'center',
          alignItems: 'center',
        }}
      >
        <Icon
          name={item.iconName}
          size={30}
          color={isActive ? '#2E55FF' : '#616161'}
        />
        <Text style={{ fontSize: 11 }}>{item.text}</Text>
      </View>
    </Pressable>
  );
};

export default NavItem;
