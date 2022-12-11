import { RootStackParamList } from './app/navigation/RootStackParams';

declare global {
  namespace ReactNavigation {
    interface RootParamList extends RootStackParamList {}
  }
}
