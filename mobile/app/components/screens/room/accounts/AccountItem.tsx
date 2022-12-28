import { View, Text, StyleSheet } from 'react-native';
import React, { FC } from 'react';
import { IAccount } from '../../../../api/interfaces/account';
import { acc } from 'react-native-reanimated';

interface IAccountItemProps {
  account: IAccount;
}

const AccountItem: FC<IAccountItemProps> = ({ account }) => {
  return (
    <View style={{ ...styles.container, ...styles.shadow }}>
      <View style={styles.contentWrapper}>
        <Text style={styles.name}>
          {account.name}
          {account.personName && `\n Владелец: ${account.personName}`}
        </Text>
        <Text style={styles.balance}>{account.balance} р.</Text>
      </View>
    </View>
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
    justifyContent: 'space-between',
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
    fontSize: 15,
    maxWidth: '80%',
  },
  balance: {
    fontSize: 20,
    textAlign: 'right',
    alignItems: 'flex-end',
  },
  owner: {},
  description: {
    opacity: 0.5,
  },
  iconWrapper: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'flex-end',
    width: '20%',
  },
  contentWrapper: {
    // width: '80%',
    flexDirection: 'row',
    justifyContent: 'space-between',
  },
});
export default AccountItem;
