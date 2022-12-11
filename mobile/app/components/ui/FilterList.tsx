import { View, Text, StyleSheet, Pressable } from 'react-native';
import React, { FC, useState } from 'react';

type Item = {
  key: any;
  text: string;
};

interface IFilterList {
  items: Item[];
  onPress: (key: any) => void;
}

const FilterList: FC<IFilterList> = ({ items, onPress }) => {
  const [active, setActive] = useState<number>(items[0].key);

  return (
    <View style={styles.container}>
      {items?.map(item => (
        <Pressable
          key={item.key}
          onPress={(key: any) => {
            setActive(item.key);
            onPress(item.key);
          }}
        >
          <Text
            style={
              item.key === active
                ? { ...styles.item, ...styles.itemActive }
                : styles.item
            }
          >
            {item.text}
          </Text>
        </Pressable>
      ))}
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flexDirection: 'row',
    justifyContent: 'space-around',
  },
  item: {
    fontSize: 18,
    paddingHorizontal: 10,
  },
  itemActive: {
    fontSize: 18,
    paddingHorizontal: 10,
    borderBottomColor: 'skyblue',
    borderBottomWidth: 4,
  },
});

export default FilterList;
