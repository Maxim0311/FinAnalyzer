import {
  View,
  Text,
  StyleSheet,
  Modal,
  Pressable,
  ScrollView,
} from 'react-native';
import React, { FC, useEffect, useState } from 'react';
import Field from '../../../../ui/Field';
import Button from '../../../../ui/Button';
import { ICategoryCreate } from '../../../../../api/interfaces/category';
import { useCategoryService } from '../../../../../api/service/CategoryService';
import Error from '../../../../ui/Error';
import CheckBox from '../../../../ui/CheckBox';
import Icon from '../../../../ui/Icon';
import { ColorPicker, fromHsv } from 'react-native-color-picker';
import { HsvColor } from 'react-native-color-picker/dist/typeHelpers';
import { icons, IIconCreate } from './icons';

const CategoryCreate: FC = () => {
  const { error, clearError, isLoading, createCategory } = useCategoryService();

  const [data, setData] = useState<ICategoryCreate>({
    name: '',
    isExpenditure: true,
    iconAuthor: null,
    iconName: '',
    iconColor: '',
  });

  const [modalIconSelectVisible, setModalIconSelectVisible] = useState(false);
  const [modalColorPickerVisible, setModalColorPickerVisible] = useState(false);

  const [colorInModal, setColorInModal] = useState('');

  const categoryCreateHandler = () => {
    clearError();
    createCategory(data);
  };

  const iconPressHanldler = (icon: IIconCreate) => {
    setData({ ...data, iconAuthor: icon.iconAuthor, iconName: icon.iconName });
    setModalIconSelectVisible(false);
  };

  const colorChangeHandler = (color: HsvColor) => {
    setColorInModal(fromHsv(color));
  };

  const onSelectColor = () => {
    setData({ ...data, iconColor: colorInModal });
    setModalColorPickerVisible(false);
  };

  const validateForm = () =>
    data.iconAuthor &&
    data.iconName !== '' &&
    data.iconColor !== '' &&
    data.name !== '';

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

        <Button
          style={{ marginTop: 10 }}
          disabled={isLoading}
          title="Выбрать иконку"
          onPress={() => setModalIconSelectVisible(true)}
        />

        {data.iconAuthor && (
          <View style={{ width: '100%', alignItems: 'center', marginTop: 10 }}>
            <Icon
              name={data.iconName}
              author={data.iconAuthor}
              size={100}
              color={data.iconColor}
            />
            <Button
              style={{ marginTop: 10 }}
              disabled={isLoading}
              title="Выбрать цвет"
              onPress={() => setModalColorPickerVisible(true)}
            />
          </View>
        )}

        {error && <Error style={{ marginTop: 10 }} text={error} />}
        <Button
          style={{ marginTop: 10 }}
          disabled={isLoading || !validateForm()}
          title="Создать"
          onPress={categoryCreateHandler}
        />
      </View>
      {/* модальное окно выбора иконки */}
      <Modal
        animationType="slide"
        transparent={true}
        visible={modalIconSelectVisible}
        onRequestClose={() => {
          setModalIconSelectVisible(!modalIconSelectVisible);
        }}
      >
        <View style={styles.centeredView}>
          <View style={styles.modalView}>
            <Text style={styles.modalHeaderText}>Выбор иконки</Text>
            <View style={styles.iconsContainer}>
              {icons.map((item, index) => (
                <Pressable onPress={() => iconPressHanldler(item)}>
                  <Icon
                    author={item.iconAuthor}
                    name={item.iconName}
                    size={50}
                    key={index}
                    style={styles.icon}
                  />
                </Pressable>
              ))}
            </View>
          </View>
        </View>
      </Modal>
      {/* модальное окно выбора цвета */}
      <Modal
        animationType="slide"
        transparent={true}
        visible={modalColorPickerVisible}
        onRequestClose={() => {
          setModalColorPickerVisible(!modalColorPickerVisible);
        }}
      >
        <View style={styles.centeredView}>
          <View style={styles.modalView}>
            <Text style={styles.modalHeaderText}>Выбор цвета</Text>
            <ColorPicker
              style={styles.colorPicker}
              onColorChange={colorChangeHandler}
            />
            <Icon
              author={data.iconAuthor}
              name={data.iconName}
              color={colorInModal}
              size={100}
            />
            <Pressable
              style={[styles.button, styles.buttonClose]}
              onPress={onSelectColor}
            >
              <Text style={styles.textStyle}>Выбрать</Text>
            </Pressable>
          </View>
        </View>
      </Modal>
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

  centeredView: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    marginTop: 22,
  },
  modalView: {
    margin: 20,
    backgroundColor: 'white',
    borderRadius: 20,
    padding: 35,
    alignItems: 'center',
    shadowColor: '#000',
    shadowOffset: {
      width: 0,
      height: 2,
    },
    shadowOpacity: 0.25,
    shadowRadius: 4,
    elevation: 5,
  },
  button: {
    borderRadius: 20,
    padding: 10,
    elevation: 2,
  },
  buttonOpen: {
    backgroundColor: '#F194FF',
  },
  buttonClose: {
    backgroundColor: '#2196F3',
  },
  textStyle: {
    color: 'white',
    fontWeight: 'bold',
    textAlign: 'center',
  },
  modalText: {
    marginBottom: 15,
    textAlign: 'center',
  },
  iconsContainer: {
    width: 250,
    flexDirection: 'row',
    flexWrap: 'wrap',
    justifyContent: 'space-around',
  },
  icon: {
    marginBottom: 10,
  },
  colorPicker: {
    width: 300,
    height: 300,
  },
  modalHeaderText: {
    fontSize: 25,
    marginBottom: 15,
  },
});

export default CategoryCreate;
