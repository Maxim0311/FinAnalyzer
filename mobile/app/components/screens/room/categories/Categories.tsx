import {
  View,
  Text,
  StyleSheet,
  ScrollView,
  Pressable,
  RefreshControl,
} from 'react-native';
import React, { useEffect, useState } from 'react';
import { useRoom } from '../../../../providers/RoomProvider';
import CategoryItem from './CategoryItem';
import FilterList from '../../../ui/FilterList';
import { ICategory } from '../../../../api/interfaces/category';
import Field from '../../../ui/Field';
import { useCategoryService } from '../../../../api/service/CategoryService';
import Icon from '../../../ui/Icon';
import { useNavigation } from '@react-navigation/native';
import NotFound from '../../../ui/NotFound';
import CategoriesItemModal from './CategoriesItemModal';
import Modal from 'react-native-modal';

const items = [
  { key: null, text: 'Все' },
  { key: true, text: 'Доходные' },
  { key: false, text: 'Расходные' },
];

const Categories = () => {
  const { categories, error, clearError, isLoading, getAllCategories } =
    useCategoryService();

  const navigation = useNavigation();

  const [select, setSelect] = useState<boolean | null>(null);

  const [search, setSearch] = useState('');

  const categoryClickHandler = (id: number) => {
    console.log(categories);

    setCurrentCat(categories[id]);
    setModalVisible(true);
  };

  const filterItem = (item: ICategory) =>
    select !== null
      ? item.isExpenditure === select &&
        item.name.toLocaleLowerCase().includes(search.toLowerCase())
      : item.name.toLocaleLowerCase().includes(search.toLowerCase());

  const fetchCategories = () => {
    clearError();
    getAllCategories();
  };

  useEffect(() => {
    fetchCategories();
  }, []);

  const [modalVisible, setModalVisible] = useState(false);

  const [currentCat, setCurrentCat] = useState<ICategory>(null);

  return (
    <View style={styles.container}>
      <View style={styles.headerWrapper}>
        <Text style={styles.headerText}>Категории</Text>
        <Pressable
          style={styles.headerIcon}
          onPress={() => navigation.navigate('CategoryCreate')}
        >
          <Icon author="Ionicons" name="add" size={35} />
        </Pressable>
      </View>
      <Field
        placeholder="Поиск..."
        value={search}
        onChange={value => setSearch(value)}
        isSearch
      />

      <CategoriesItemModal
        isVisible={modalVisible}
        setIsVisible={setModalVisible}
        category={currentCat}
      />

      <FilterList items={items} onPress={key => setSelect(key)} />

      <ScrollView
        refreshControl={
          <RefreshControl
            enabled
            refreshing={isLoading}
            onRefresh={fetchCategories}
          />
        }
      >
        <View style={styles.categoryContainer}>
          {categories &&
            categories
              .filter(item => filterItem(item))
              .map((item, index) => (
                <CategoryItem
                  key={item.id}
                  iconAuthor={item.iconAuthor}
                  iconName={item.iconName}
                  text={item.name}
                  iconColor={item.iconColor}
                  onPress={() => categoryClickHandler(index)}
                />
              ))}
        </View>
        {error && <NotFound title={error!} styles={{ marginTop: 20 }} />}
        {categories?.length === 0 && <NotFound styles={{ marginTop: 20 }} />}
      </ScrollView>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    justifyContent: 'center',
    width: '100%',
    padding: 10,
  },
  headerText: {
    fontSize: 25,
    textAlign: 'center',
  },
  headerWrapper: {
    justifyContent: 'center',
    flexDirection: 'row',
    marginBottom: 12,
  },
  headerIcon: {
    position: 'absolute',
    right: 10,
  },
  categoryContainer: {
    flexDirection: 'row',
    flexWrap: 'wrap',
    justifyContent: 'space-around',
  },
  categoryItem: {
    padding: 15,
  },
});

export default Categories;
