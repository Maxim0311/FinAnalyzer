import { View, Text, StyleSheet } from 'react-native';
import React, { useEffect, useState } from 'react';
import Button from '../../../../ui/Button';
import Error from '../../../../ui/Error';
import Field from '../../../../ui/Field';
import { SelectList } from 'react-native-dropdown-select-list';
import { IExpendTransaction } from '../../../../../api/interfaces/transaction';
import { useAccountService } from '../../../../../api/service/AccountService';
import { useRoom } from '../../../../../providers/RoomProvider';
import { useCategoryService } from '../../../../../api/service/CategoryService';
import { useTransactionService } from '../../../../../api/service/TransactionService';
import { useAuth } from '../../../../../hooks/useAuth';
import { useNavigation } from '@react-navigation/native';

const ExpendTransactionsCreate = () => {
  const { roomId } = useRoom();
  const { getAllAccounts, accounts } = useAccountService();
  const { categories, getAllCategories } = useCategoryService();
  const { makeExpendTransaction, isLoading, clearError, error } =
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
    ?.filter(x => x.isExpenditure)
    .map(x => ({ key: x.id, value: x.name }));

  const [data, setData] = useState<IExpendTransaction>({
    amount: 0,
    name: '',
    roomId: roomId,
    sender: 0,
    destination: '',
  });

  useEffect(() => {
    clearError();
    getAllAccounts();
    getAllCategories();
  }, []);

  const submitHandler = async () => {
    clearError();

    const result = await makeExpendTransaction(data);

    if (result) {
      navigation.navigate('Transactions');
      getAllAccounts();
    }
  };

  return (
    <View style={styles.container}>
      <View style={styles.content}>
        <Text style={styles.text}>Добавить расход</Text>

        <SelectList
          boxStyles={{ marginTop: 10, width: 330 }}
          placeholder="Счёт списания..."
          data={personAccounts ?? []}
          setSelected={value => setData({ ...data, sender: value })}
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
            setData({ ...data, destination: value });
          }}
          value={data.destination}
          placeholder="Цель расхода"
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

export default ExpendTransactionsCreate;
