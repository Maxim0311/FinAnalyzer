import { View, Text, Pressable, StyleSheet } from 'react-native';
import React from 'react';
import { useNavigation } from '@react-navigation/native';
import Icon from '../../../ui/Icon';

const Transactions = () => {
  const navigation = useNavigation();

  return (
    <View>
      <Text style={styles.headerText}>Операции</Text>
      <Pressable
        style={styles.headerIcon}
        onPress={() => navigation.navigate('TransactionsCreate')}
      >
        <Icon author="Ionicons" name="add" size={35} />
      </Pressable>
    </View>
  );
};
const styles = StyleSheet.create({
  headerText: {
    fontSize: 20,
    textAlign: 'center',
  },
  accountTypeTitle: {
    fontSize: 15,
  },
  headerIcon: {
    position: 'absolute',
    right: 10,
  },
});
export default Transactions;
