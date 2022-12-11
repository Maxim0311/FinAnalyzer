import { View, Text, StyleSheet } from 'react-native';
import React, { FC } from 'react';
import Icon from 'react-native-vector-icons/Feather';

interface INotFound {
  title?: string;
  styles?: any;
}

const NotFound: FC<INotFound> = ({ title, styles }) => {
  return (
    <View style={{ ...styles, justifyContent: 'center', alignItems: 'center' }}>
      <Icon name="frown" size={40} style={{ marginBottom: 10 }} />
      <Text style={{ fontSize: 16 }}>
        {title ? title : 'Ничего не найдено'}
      </Text>
    </View>
  );
};

export default NotFound;
