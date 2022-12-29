import { View, Text, StyleSheet } from 'react-native';
import React, { FC } from 'react';
import { ITransaction } from '../../../../api/interfaces/transaction';

interface ITransactionItemProps {
  transaction: ITransaction;
}

const TransactionItem: FC<ITransactionItemProps> = ({ transaction }) => {
  const transactionTypeToString = (id: number) => {
    switch (id) {
      case 1:
        return 'Доход';
      case 2:
        return 'Расход';
      case 3:
        return 'Перевод';
    }
  };

  return (
    <View
      style={{ ...styles.container, ...styles.shadow, paddingVertical: 10 }}
    >
      <View>
        <View style={{ flexDirection: 'row', justifyContent: 'space-between' }}>
          <Text>
            {new Date(transaction.createDate).toLocaleString('ru-RU')}
          </Text>
          <Text>{transactionTypeToString(transaction.transactionTypeId)}</Text>
        </View>
        <View style={{ flexDirection: 'row', justifyContent: 'space-between' }}>
          <Text>Описание: {transaction.name}</Text>
          <Text style={{ fontSize: 20 }}>{transaction.amount} р.</Text>
        </View>
        <View>
          <Text>
            Отправитель: {transaction.sender.name}{' '}
            {transaction.sender.personName &&
              `(${transaction.sender.personName})`}
          </Text>
          <Text>
            Получатель: {transaction.destination.name}{' '}
            {transaction.destination.personName &&
              `(${transaction.destination.personName})`}
          </Text>
          {transaction.category?.name && (
            <Text>Категория: {transaction.category.name}</Text>
          )}
        </View>
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    marginHorizontal: 15,
    backgroundColor: 'white',
    borderRadius: 8,
    paddingVertical: 15,
    paddingHorizontal: 25,
    marginVertical: 10,
    maxHeight: 150,
    justifyContent: 'space-between',
  },
  shadow: {
    shadowColor: '#000',
    shadowOffset: {
      width: 0,
      height: 7,
    },
    shadowOpacity: 0.41,
    shadowRadius: 9.11,

    elevation: 14,
  },
  name: {
    fontSize: 15,
    maxWidth: '80%',
  },
  balance: {
    fontSize: 20,
    textAlign: 'right',
    alignItems: 'flex-end',
  },
  description: {
    opacity: 0.5,
  },
  iconWrapper: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'flex-end',
    width: '20%',
  },
});

export default TransactionItem;
