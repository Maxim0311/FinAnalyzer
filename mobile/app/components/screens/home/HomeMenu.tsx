import React, { FC } from 'react';
import {
  Menu,
  MenuTrigger,
  MenuOption,
  MenuOptions,
} from 'react-native-popup-menu';
import Icon from 'react-native-vector-icons/Feather';

const HomeMenu: FC = ({ children }) => {
  return (
    <Menu>
      <MenuTrigger>
        <Icon name="more-vertical" size={30} />
      </MenuTrigger>
      <MenuOptions
        customStyles={{
          optionsContainer: {
            padding: 10,
            width: 'auto',
          },
        }}
      >
        {children}
      </MenuOptions>
    </Menu>
  );
};

export default HomeMenu;
