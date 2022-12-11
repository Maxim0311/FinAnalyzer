import { View, Text, TouchableOpacity, StyleSheet, Alert } from 'react-native';
import React, { FC, useEffect, useState } from 'react';
import Field from '../../ui/Field';
import { useNavigation } from '@react-navigation/native';
import { useAuth } from '../../../hooks/useAuth';
import { IRegistrationRequest } from '../../../api/interfaces/auth';
import Button from '../../ui/Button';
import Error from '../../ui/Error';

const Registration: FC = () => {
  const { register, isLoading, error, setError, clearError } = useAuth();

  const navigation = useNavigation();

  const [data, setData] = useState<IRegistrationRequest>(
    {} as IRegistrationRequest
  );

  const [confirmPassword, setConfirmPassword] = useState('');

  const isPasswordConfirm = (): boolean => data.password === confirmPassword;

  const registerHandler = async () => {
    clearError();

    if (!isPasswordConfirm()) {
      setError('Пароли не совпадают');
      return;
    }

    if (await register(data)) navigation.navigate('Auth');
  };

  useEffect(() => {
    clearError();
  }, []);

  return (
    <View style={styles.container}>
      <View style={styles.content}>
        <Text style={styles.text}>Зарегистрироваться</Text>
        <Field
          onChange={value => {
            setData({ ...data, login: value });
          }}
          value={data.login}
          placeholder="Логин"
          style={styles.input}
        />
        <Field
          onChange={value => {
            setData({ ...data, firstname: value });
          }}
          value={data.firstname}
          placeholder="Имя"
          style={styles.input}
        />
        <Field
          onChange={value => {
            setData({ ...data, lastname: value });
          }}
          value={data.lastname}
          style={styles.input}
          placeholder="Фамилия"
        />
        <Field
          onChange={value => {
            setData({ ...data, middlename: value });
          }}
          value={data.middlename}
          style={styles.input}
          placeholder="Отчество"
        />
        <Field
          onChange={value => {
            setData({ ...data, password: value });
          }}
          value={data.password}
          placeholder="Пароль"
          style={styles.input}
          isSecure={true}
        />
        <Field
          onChange={value => {
            setConfirmPassword(value);
          }}
          value={confirmPassword}
          placeholder="Повторите пароль"
          style={styles.input}
          isSecure={true}
        />
        {error && <Error style={{ marginTop: 10 }} text={error} />}
        <Button
          style={{ marginTop: 10 }}
          disabled={isLoading}
          title="Зарегистрироваться"
          onPress={registerHandler}
        />
      </View>

      <TouchableOpacity
        style={{ width: '80%' }}
        onPress={() => navigation.navigate('Auth')}
      >
        <Text style={styles.bottomText}>Войти</Text>
      </TouchableOpacity>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  content: {
    width: '80%',
    justifyContent: 'center',
    alignItems: 'center',
  },
  text: {
    fontSize: 30,
    marginBottom: 10,
  },
  bottomText: {
    marginTop: 10,
    textAlign: 'right',
    opacity: 0.5,
    fontSize: 15,
  },
  input: {
    marginTop: 10,
  },
});

export default Registration;
