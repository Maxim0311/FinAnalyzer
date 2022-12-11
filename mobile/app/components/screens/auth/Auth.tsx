import { View, Text, StyleSheet, TouchableOpacity } from 'react-native';
import React, { FC, useEffect, useState } from 'react';
import { useAuth } from '../../../hooks/useAuth';
import Field from '../../ui/Field';
import { useNavigation } from '@react-navigation/native';
import Button from '../../ui/Button';
import { IAuthRequest } from '../../../api/interfaces/auth';
import Error from '../../ui/Error';
import { useRoomService } from '../../../api/service/RoomService';
import { IRoomCreate } from '../../../api/interfaces/room';

const Auth: FC = () => {
  const { isLoading, login, error, clearError } = useAuth();

  const navigation = useNavigation();

  const [data, setData] = useState<IAuthRequest>({
    login: '',
    password: '',
  });

  const loginHandler = () => {
    clearError();
    login(data);
  };

  useEffect(() => {
    clearError();
  }, []);

  return (
    <View style={styles.container}>
      <View style={styles.content}>
        <Text style={styles.text}>Войти</Text>
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
            setData({ ...data, password: value });
          }}
          value={data.password}
          placeholder="Пароль"
          isSecure={true}
          style={styles.input}
        />
        {error && <Error style={{ marginTop: 10 }} text={error} />}
        <Button
          style={{ marginTop: 10 }}
          disabled={isLoading}
          title="Войти"
          onPress={loginHandler}
        />
      </View>

      <TouchableOpacity
        style={{ width: '80%' }}
        onPress={() => navigation.navigate('Registration')}
      >
        <Text style={styles.bottomText}>Зарегистрироваться</Text>
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

export default Auth;
