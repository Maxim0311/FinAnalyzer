import { View, Text, StyleSheet } from 'react-native';
import React, { useEffect, useState } from 'react';
import { SelectList } from 'react-native-dropdown-select-list';
import { useAccountService } from '../../../../../api/service/AccountService';
import { useAuth } from '../../../../../hooks/useAuth';
import { useCategoryService } from '../../../../../api/service/CategoryService';
import { IIncomeTransaction } from '../../../../../api/interfaces/transaction';
import { useRoom } from '../../../../../providers/RoomProvider';
import Field from '../../../../ui/Field';
import Button from '../../../../ui/Button';
import { useTransactionService } from '../../../../../api/service/TransactionService';
import { useNavigation } from '@react-navigation/native';
import Error from '../../../../ui/Error';

const IncomeTransactionsCreate = () => {
  const { roomId } = useRoom();
  const { getAllAccounts, accounts } = useAccountService();
  const { categories, getAllCategories } = useCategoryService();
  const { makeIncomeTransaction, isLoading, clearError, error } =
    useTransactionService();
  const { user } = useAuth();
  const navigation = useNavigation();

  const personAccounts = accounts
    ?.filter(x => x.personName === user.login)
    ?.map(x => {
      return {
        key: x.id,
        value: x.name,
      };
    });

  const personCategories = categories
    ?.filter(x => !x.isExpenditure)
    .map(x => ({ key: x.id, value: x.name }));

  const [data, setData] = useState<IIncomeTransaction>({
    amount: 0,
    name: '',
    roomId: roomId,
    sender: '',
    destination: 0,
  });

  useEffect(() => {
    getAllAccounts();
    getAllCategories();
  }, []);

  const submitHandler = async () => {
    clearError();

    const result = await makeIncomeTransaction(data);

    if (result) {
      navigation.navigate('Transactions');
      getAllAccounts();
    }
  };

  return (
    <View style={styles.container}>
      <View style={styles.content}>
        <Text style={styles.text}>Добавить доход</Text>

        <SelectList
          boxStyles={{ marginTop: 10, width: 330 }}
          placeholder="Счёт зачисления..."
          data={personAccounts ?? []}
          setSelected={value => setData({ ...data, destination: value })}
        />

        <SelectList
          boxStyles={{ marginTop: 10, width: 330 }}
          placeholder="Категория..."
          data={personCategories ?? []}
          setSelected={value => setData({ ...data, categoryId: value })}
        />

        <Field
          onChange={value => {
            setData({ ...data, name: value });
          }}
          value={data.name}
          placeholder="Описание"
          style={styles.input}
        />

        <Field
          onChange={value => {
            setData({ ...data, sender: value });
          }}
          value={data.sender}
          placeholder="Источник дохода"
          style={styles.input}
        />

        <Field
          onChange={value => {
            setData({ ...data, amount: value as any });
          }}
          value={data.amount as any}
          placeholder="Сумма"
          style={styles.input}
        />
        {error && <Error text={error} />}

        <Button
          style={{ marginTop: 10 }}
          disabled={isLoading}
          title="Добавить"
          onPress={submitHandler}
        />
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
  input: {
    marginTop: 10,
  },
});

export default IncomeTransactionsCreate;
