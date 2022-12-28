import {
  View,
  Text,
  StyleSheet,
  RefreshControl,
  ScrollView,
  Pressable,
} from 'react-native';
import React, { useEffect } from 'react';
import { useAccountService } from '../../../../api/service/AccountService';
import AccountItem from './AccountItem';
import { useNavigation } from '@react-navigation/native';
import Icon from '../../../ui/Icon';

const Accounts = () => {
  const { accounts, isLoading, getAllAccounts } = useAccountService();
  const navigation = useNavigation();
  useEffect(() => {
    getAllAccounts();
  }, []);

  return (
    <View>
      <Text style={styles.headerText}>Счета</Text>
      <Pressable
        style={styles.headerIcon}
        onPress={() => navigation.navigate('AccountsCreate')}
      >
        <Icon author="Ionicons" name="add" size={35} />
      </Pressable>
      {isLoading ? (
        <Text>Loading...</Text>
      ) : (
        <ScrollView
          refreshControl={
            <RefreshControl
              enabled
              refreshing={isLoading}
              onRefresh={getAllAccounts}
            />
          }
          style={{ width: '100%' }}
        >
          <View>
            <View>
              <Text style={styles.accountTypeTitle}>Общие счета</Text>
              {accounts
                ?.filter(x => x.accountType.id == 2)
                .map(item => (
                  <AccountItem account={item} />
                ))}
            </View>
            <View>
              <Text style={styles.accountTypeTitle}>Личные счета</Text>
              {accounts
                ?.filter(x => x.accountType.id == 1)
                .map(item => (
                  <AccountItem account={item} />
                ))}
            </View>
          </View>
        </ScrollView>
      )}
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

export default Accounts;
