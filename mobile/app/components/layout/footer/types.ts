import { AntDesign } from '@expo/vector-icons';
import { RootStackParamList } from '../../../navigation/RootStackParams';

export interface IFooterItem {
  iconName: string;
  title: keyof RootStackParamList;
  text: string;
}
