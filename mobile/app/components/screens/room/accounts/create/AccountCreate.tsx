import { View, Text, StyleSheet, Alert } from 'react-native';
import React, { FC, useEffect, useState } from 'react';
import Field from '../../../../ui/Field';
import Button from '../../../../ui/Button';
import { useAccountService } from '../../../../../api/service/AccountService';
import { IAccountCreate } from '../../../../../api/interfaces/account';
import Error from '../../../../ui/Error';
import { useNavigation } from '@react-navigation/native';
import { SelectList } from 'react-native-dropdown-select-list';

const AccountCreate: FC = () => {
  const { createAccount, isLoading, error, clearError } = useAccountService();

  const navigation = useNavigation();

  const [data, setData] = useState<IAccountCreate>({
    name: '',
    accountType: null,
  });

  const submitHundler = async () => {
    clearError();
    const result = await createAccount(data);
    console.log(result);

    if (result) {
      Alert.alert('Счёт успешно создан');
      navigation.navigate('Accounts');
    }
  };

  useEffect(() => {
    clearError();
  }, []);
  useEffect(() => {
    console.log(data);
  }, [data]);
  const [items, setItems] = useState([
    { key: 1, value: 'Личный счёт' },
    { key: 2, value: 'Общий счёт' },
  ]);

  return (
    <View style={styles.container}>
      <Text style={styles.headerText}>Создание нового счёта</Text>

      <Field
        onChange={value => {
          setData({ ...data, name: value });
        }}
        value={data.name}
        placeholder="Название"
        style={styles.input}
      />

      <SelectList
        boxStyles={{ marginTop: 10 }}
        placeholder="Выберите тип счёта..."
        data={items}
        setSelected={value => setData({ ...data, accountType: value })}
      />

      {error && <Error text={error} />}
      <Button
        style={{ marginTop: 30 }}
        disabled={isLoading}
        title="Создать"
        onPress={submitHundler}
      />
    </View>
  );
};
const styles = StyleSheet.create({
  container: {
    paddingHorizontal: 20,
  },
  headerText: {
    fontSize: 20,
    textAlign: 'center',
  },
  input: {
    marginTop: 10,
  },
});
export default AccountCreate;
