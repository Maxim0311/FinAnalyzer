import { View, StyleSheet, TouchableOpacity, Text, Alert } from 'react-native';
import React, { Dispatch, FC } from 'react';
import Modal from 'react-native-modal';
import { ICategory } from '../../../../api/interfaces/category';
import Icon from '../../../ui/Icon';
import { useNavigation } from '@react-navigation/native';
import { useCategoryService } from '../../../../api/service/CategoryService';

interface ICategoriesItemModal {
  isVisible: boolean;
  setIsVisible: Dispatch<boolean>;
  category: ICategory | null;
}

const CategoriesItemModal: FC<ICategoriesItemModal> = ({
  isVisible,
  category,
  setIsVisible,
}) => {
  const navigation = useNavigation();
  const { deleteCategory, getAllCategories } = useCategoryService();

  const deleteHandler = async () => {
    const result = await deleteCategory(category.id);
    if (result) {
      setIsVisible(false);
      getAllCategories();
    } else {
      Alert.alert('Не удалось удалить категорию');
    }
  };
  return (
    <Modal
      isVisible={isVisible}
      onBackButtonPress={() => setIsVisible(false)}
      onBackdropPress={() => setIsVisible(false)}
    >
      <View style={styles.container}>
        <View style={styles.headerWrapper}>
          <TouchableOpacity onPress={() => setIsVisible(false)}>
            <Icon author="AntDesign" name="close" size={40} />
          </TouchableOpacity>
          <View style={{ flexDirection: 'row' }}>
            <TouchableOpacity
              onPress={() => {
                navigation.navigate('CategoryUpdate', { ...category });
              }}
            >
              <Icon author="AntDesign" name="edit" size={40} />
            </TouchableOpacity>
            <TouchableOpacity
              style={{ marginLeft: 15 }}
              onPress={deleteHandler}
            >
              <Icon author="FontAwesome" name="trash-o" size={40} />
            </TouchableOpacity>
          </View>
        </View>
        <View style={styles.main}>
          <Icon
            author={category?.iconAuthor}
            name={category?.iconName}
            size={100}
            color={category?.iconColor}
          />
          <Text style={styles.catName}>{category?.name}</Text>
          <Text style={styles.catDescription}>
            {category?.description || 'Описание не найдено'}
          </Text>
        </View>
      </View>
    </Modal>
  );
};

const styles = StyleSheet.create({
  container: {
    padding: 10,
    backgroundColor: 'white',
  },
  headerWrapper: {
    flexDirection: 'row',
    justifyContent: 'space-between',
  },
  main: {
    alignItems: 'center',
    width: '100%',
  },
  catName: {
    fontSize: 30,
  },
  catDescription: {
    fontSize: 15,
    color: 'grey',
  },
});

export default CategoriesItemModal;
