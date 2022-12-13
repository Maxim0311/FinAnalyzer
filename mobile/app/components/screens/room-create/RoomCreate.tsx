import { View, Text, StyleSheet, Modal, Pressable } from 'react-native';
import React, { useEffect, useState } from 'react';
import { useNavigation } from '@react-navigation/native';
import Error from '../../ui/Error';
import Field from '../../ui/Field';
import { IRoomCreate } from '../../../api/interfaces/room';
import { useRoomService } from '../../../api/service/RoomService';
import Button from '../../ui/Button';
import { useRoom } from '../../../providers/RoomProvider';

const RoomCreate = () => {
  const navigation = useNavigation();

  const { createRoom, isLoading, error, clearError } = useRoomService();

  const { roomId } = useRoom();

  const [data, setData] = useState<IRoomCreate>({
    name: '',
  });

  const roomCreateHandler = async () => {
    clearError();

    console.log('test');

    const response = await createRoom(data);

    if (response.success) navigation.navigate('Home');
  };

  useEffect(() => {
    clearError();
  }, []);

  return (
    <View style={styles.container}>
      <View style={styles.content}>
        <Text style={styles.text}>Создание комнаты</Text>
        <Field
          onChange={value => {
            setData({ ...data, name: value });
          }}
          value={data.name}
          placeholder="Название"
          style={styles.input}
        />
        <Field
          onChange={value => {
            setData({ ...data, description: value });
          }}
          value={data.description}
          placeholder="Описание"
          style={styles.input}
        />
        {error && <Error style={{ marginTop: 10 }} text={error} />}
        <Button
          style={{ marginTop: 10 }}
          disabled={isLoading}
          title="Создать"
          onPress={roomCreateHandler}
        />
      </View>
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

export default RoomCreate;
