import { View, Text, StyleSheet } from 'react-native';
import React, { FC, useState } from 'react';
import { menu } from './menu';
import NavItem from './NavItem';
import { RootStackParamList } from '../../../navigation/RootStackParams';

interface IFooter {
  navigate: (screenName: keyof RootStackParamList) => void;
  currentRoute: string;
}

const Footer: FC<IFooter> = ({ navigate, currentRoute }) => {
  const [active, setActive] = useState<number>();

  return (
    <View style={styles.footer}>
      {menu.map(item => (
        <NavItem item={item} navigate={navigate} currentRoute={currentRoute} />
      ))}
    </View>
  );
};

const styles = StyleSheet.create({
  footer: {
    height: '20%',
    backgroundColor: '#E0E0E0',
    flex: 1,
    justifyContent: 'space-around',
    flexDirection: 'row',
  },
});

export default Footer;
