import { View, Text, ScrollView, StyleSheet } from 'react-native';
import React, { FC } from 'react';
import { useTailwind } from 'tailwind-rn';

interface ILayout {
  isScrollView?: boolean;
}

const Layout: FC<ILayout> = ({ children, isScrollView = false }) => {
  return (
    <View style={{ padding: '10%' }}>
      {isScrollView ? <ScrollView>{children}</ScrollView> : { children }}
    </View>
  );
};

export default Layout;
