import React, { FC } from 'react';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import {
  NavigationContainer,
  useNavigationContainerRef,
} from '@react-navigation/native';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { useAuth } from '../hooks/useAuth';
import Auth from '../components/screens/auth/Auth';
import Home from '../components/screens/home/Home';
import Registration from '../components/screens/registration/Registration';
import Profile from '../components/screens/profile/Profile';
import RoomCreate from '../components/screens/room-create/RoomCreate';
import RoomMain from '../components/screens/room/main/RoomMain';
import Transactions from '../components/screens/room/transactions/Transactions';
import Accounts from '../components/screens/room/accounts/Accounts';
import Settings from '../components/screens/room/settings/Settings';
import Ionicons from 'react-native-vector-icons/Ionicons';
import AntDesign from 'react-native-vector-icons/AntDesign';
import Feather from 'react-native-vector-icons/Feather';
import Header from '../components/layout/header/Header';
import Categories from '../components/screens/room/categories/Categories';
import CategoryCreate from '../components/screens/room/categories/create/CategoryCreate';
import CategoryUpdate from '../components/screens/room/categories/update/CategoryUpdate';

const Stack = createNativeStackNavigator();
const Tab = createBottomTabNavigator();

const Navigation: FC = () => {
  const { user } = useAuth();

  const ref = useNavigationContainerRef();

  return (
    <>
      {user && <Header navigate={ref.navigate} />}
      <NavigationContainer ref={ref}>
        <Stack.Navigator screenOptions={{ headerShown: false }}>
          {user ? (
            <>
              <Stack.Screen name="Home" component={Home}></Stack.Screen>
              <Stack.Screen name="Profile" component={Profile}></Stack.Screen>
              <Stack.Screen
                name="RoomCreate"
                component={RoomCreate}
              ></Stack.Screen>
              <Stack.Screen name="Room" component={Room} />
            </>
          ) : (
            <>
              <Stack.Screen name="Auth" component={Auth}></Stack.Screen>
              <Stack.Screen
                name="Registration"
                component={Registration}
              ></Stack.Screen>
            </>
          )}
        </Stack.Navigator>
      </NavigationContainer>
    </>
  );
};

const Room = () => {
  return (
    <Tab.Navigator
      screenOptions={{ headerShown: false, tabBarHideOnKeyboard: true }}
    >
      <Tab.Screen
        name="RoomMain"
        component={RoomMain}
        options={{
          title: 'Главная',
          tabBarIcon: ({ size, color }) => (
            <Ionicons name="md-home" size={size} color={color} />
          ),
        }}
      />
      <Tab.Screen
        name="Transactions"
        component={Transactions}
        options={{
          title: 'Операции',
          tabBarIcon: ({ size, color }) => (
            <Feather name="repeat" size={size} color={color} />
          ),
        }}
      />
      <Tab.Screen
        name="Accounts"
        component={Accounts}
        options={{
          title: 'Счета',
          tabBarIcon: ({ size, color }) => (
            <AntDesign name="creditcard" size={size} color={color} />
          ),
        }}
      />
      <Tab.Screen
        name="Categories"
        component={CategoryStack}
        options={{
          title: 'Категории',
          tabBarIcon: ({ size, color }) => (
            <Feather name="grid" size={size} color={color} />
          ),
        }}
      />
      <Tab.Screen
        name="Settings"
        component={Settings}
        options={{
          title: 'Настройки',
          tabBarIcon: ({ size, color }) => (
            <Feather name="settings" size={size} color={color} />
          ),
        }}
      />
    </Tab.Navigator>
  );
};

const CategoryStack = () => {
  return (
    <Stack.Navigator screenOptions={{ headerShown: false }}>
      <Stack.Screen name="CategoriesMain" component={Categories}></Stack.Screen>
      <Stack.Screen
        name="CategoryCreate"
        component={CategoryCreate}
      ></Stack.Screen>
      <Stack.Screen
        name="CategoryUpdate"
        component={CategoryUpdate}
      ></Stack.Screen>
    </Stack.Navigator>
  );
};

export default Navigation;
