import React, { FC } from 'react';
import { AuthProvider } from './AuthProvider';
import { RoomServiceProvider } from '../api/service/RoomService';
import RoomProvider from './RoomProvider';
import { CategoryServiceProvider } from '../api/service/CategoryService';
import { AccountServiceProvider } from '../api/service/AccountService';
import { TransactionServiceProvider } from '../api/service/TransactionService';

export const HeadProvider: FC = ({ children }) => {
  return (
    <AuthProvider>
      <RoomProvider>
        <RoomServiceProvider>
          <AccountServiceProvider>
            <TransactionServiceProvider>
              <CategoryServiceProvider>{children}</CategoryServiceProvider>
            </TransactionServiceProvider>
          </AccountServiceProvider>
        </RoomServiceProvider>
      </RoomProvider>
    </AuthProvider>
  );
};
export default HeadProvider;
