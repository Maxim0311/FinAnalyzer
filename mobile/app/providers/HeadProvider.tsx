import React, { FC } from "react";
import { AuthProvider } from "./AuthProvider";
import { RoomServiceProvider } from "../api/service/RoomService";
import RoomProvider from "./RoomProvider";
import { CategoryServiceProvider } from "../api/service/CategoryService";
import { AccountServiceProvider } from "../api/service/AccountService";
import { TransactionServiceProvider } from "../api/service/TransactionService";
import { StatisticServiceProvider } from "../api/service/StatisticService";

export const HeadProvider: FC<any> = ({ children }) => {
  return (
    <AuthProvider>
      <RoomProvider>
        <RoomServiceProvider>
          <StatisticServiceProvider>
            <AccountServiceProvider>
              <TransactionServiceProvider>
                <CategoryServiceProvider>{children}</CategoryServiceProvider>
              </TransactionServiceProvider>
            </AccountServiceProvider>
          </StatisticServiceProvider>
        </RoomServiceProvider>
      </RoomProvider>
    </AuthProvider>
  );
};
export default HeadProvider;
