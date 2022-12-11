import { View, Text, StyleSheet, Pressable } from 'react-native';
import React, { FC } from 'react';
import { useAuth } from '../../../hooks/useAuth';
import Icon from 'react-native-vector-icons/Ionicons';

interface IHeader {
  navigate: any;
}

const Header: FC<IHeader> = ({ navigate }) => {
  const { user } = useAuth();

  return (
    <View style={styles.container}>
      <Text style={styles.text}>Привет, {user?.login}</Text>
      <Pressable onPress={() => navigate('Profile')}>
        <Icon name="person-circle" size={40} />
      </Pressable>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    padding: 5,
    paddingHorizontal: 15,
    flexDirection: 'row',
    justifyContent: 'space-between',
    alignItems: 'center',
  },
  text: {
    fontSize: 16,
  },
});

export default Header;
