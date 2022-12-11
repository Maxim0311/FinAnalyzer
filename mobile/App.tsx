import { MenuProvider } from 'react-native-popup-menu';
import { SafeAreaView } from 'react-native-safe-area-context';

import Navigation from './app/navigation/Navigation';
import HeadProvider from './app/providers/HeadProvider';

export default function App() {
  return (
    <SafeAreaView style={{ height: '100%' }}>
      <HeadProvider>
        <MenuProvider>
          <Navigation />
        </MenuProvider>
      </HeadProvider>
    </SafeAreaView>
  );
}
