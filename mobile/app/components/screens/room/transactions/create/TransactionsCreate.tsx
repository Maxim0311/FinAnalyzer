import { View, Text, StyleSheet, Pressable } from 'react-native';
import React from 'react';
import Icon from '../../../../ui/Icon';
import { useNavigation } from '@react-navigation/native';

const TransactionsCreate = () => {
  const navigation = useNavigation();

  return (
    <View style={styles.container}>
      <View style={styles.content}>
        <Text style={styles.text}>Совершить операцию</Text>
        <View style={styles.iconContainer}>
          <Pressable
            onPress={() => navigation.navigate('IncomeTransactionsCreate')}
          >
            <Icon size={70} color="blue" author="Entypo" name="plus" />
          </Pressable>
          <Pressable
            onPress={() => navigation.navigate('PersonTransactionsCreate')}
          >
            <Icon size={60} color="blue" author="AntDesign" name="retweet" />
          </Pressable>
          <Pressable
            onPress={() => navigation.navigate('ExpendTransactionsCreate')}
          >
            <Icon size={70} color="blue" author="Entypo" name="minus" />
          </Pressable>
        </View>
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    justifyContent: 'center',
    alignItems: 'center',
  },
  content: {
    width: '80%',
    justifyContent: 'center',
    alignItems: 'center',
  },
  text: {
    fontSize: 20,
  },
  iconContainer: {
    marginTop: 40,
    width: '100%',
    flexDirection: 'row',
    justifyContent: 'space-around',
  },
});

export default TransactionsCreate;
