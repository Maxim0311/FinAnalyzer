import { View, Text, StyleSheet } from 'react-native';
import React, { FC, useEffect, useState } from 'react';
import Field from '../../../../ui/Field';
import Button from '../../../../ui/Button';
import { ICategoryCreate } from '../../../../../api/interfaces/category';
import { useCategoryService } from '../../../../../api/service/CategoryService';
import Error from '../../../../ui/Error';
import CheckBox from '../../../../ui/CheckBox';

const CategoryCreate: FC = () => {
  const { error, clearError, isLoading } = useCategoryService();

  const [data, setData] = useState<ICategoryCreate>({
    name: '',
    isExpenditure: true,
  });

  const categoryCreateHandler = () => {};

  useEffect(() => clearError(), []);

  return (
    <View style={styles.container}>
      <View style={styles.content}>
        <Text style={styles.text}>Создание категории</Text>
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
        <CheckBox
          value={data.isExpenditure}
          onChange={() =>
            setData({ ...data, isExpenditure: !data.isExpenditure })
          }
          text="Доходная категория"
        />

        {error && <Error style={{ marginTop: 10 }} text={error} />}
        <Button
          style={{ marginTop: 10 }}
          disabled={isLoading}
          title="Создать"
          onPress={categoryCreateHandler}
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

export default CategoryCreate;
