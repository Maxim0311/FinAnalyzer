import { View, Text, StyleSheet, Pressable } from 'react-native';
import React, { FC } from 'react';
import { shadow } from '../../../../styles';
import Icon, { IconAuthor } from '../../../ui/Icon';

interface ICategoryItem {
  text: string;
  iconAuthor: IconAuthor;
  iconName: string;
  iconColor: string;
  onPress: () => void;
}

const CategoryItem: FC<ICategoryItem> = ({
  text,
  iconAuthor,
  iconName,
  onPress,
  iconColor,
}) => {
  return (
    <Pressable onPress={onPress} style={styles.container}>
      <Icon
        author={iconAuthor}
        name={iconName}
        size={50}
        style={styles.icon}
        color={iconColor}
      />
      <Text style={styles.text}>{text}</Text>
    </Pressable>
  );
};

const styles = StyleSheet.create({
  container: {
    alignItems: 'center',
    justifyContent: 'center',
    padding: 15,
    backgroundColor: 'white',
    borderRadius: 10,
    width: '45%',
    marginTop: 15,
    ...shadow,
  },
  icon: {},
  text: { marginTop: 5, fontSize: 16 },
});

export default CategoryItem;
