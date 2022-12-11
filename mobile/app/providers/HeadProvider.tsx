import React, { FC } from 'react';
import { AuthProvider } from './AuthProvider';
import { RoomServiceProvider } from '../api/service/RoomService';
import RoomProvider from './RoomProvider';
import { CategoryServiceProvider } from '../api/service/CategoryService';

export const HeadProvider: FC = ({ children }) => {
  return (
    <AuthProvider>
      <RoomProvider>
        <RoomServiceProvider>
          <CategoryServiceProvider>{children}</CategoryServiceProvider>
        </RoomServiceProvider>
      </RoomProvider>
    </AuthProvider>
  );
};

export default HeadProvider;
