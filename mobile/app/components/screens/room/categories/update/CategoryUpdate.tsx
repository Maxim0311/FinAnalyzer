import { View, Text } from 'react-native';
import React, { FC } from 'react';
import { RouteProp, useNavigation } from '@react-navigation/native';
import { RootStackParamList } from '../../../../../navigation/RootStackParams';
import { ICategory } from '../../../../../api/interfaces/category';

interface ICategoryUpdate {
  route: RouteProp<RootStackParamList, 'CategoryUpdate'>;
}

const CategoryUpdate: FC<ICategoryUpdate> = ({ route }) => {
  const navigation = useNavigation();

  return (
    <View>
      <Text>Update category: {route.params.name}</Text>
    </View>
  );
};

export default CategoryUpdate;
