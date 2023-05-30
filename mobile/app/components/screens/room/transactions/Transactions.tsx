import {
  View,
  Text,
  Pressable,
  StyleSheet,
  TextInputComponent,
  ScrollView,
  RefreshControl,
} from "react-native";
import React, { useEffect } from "react";
import { useNavigation } from "@react-navigation/native";
import Icon from "../../../ui/Icon";
import { useTransactionService } from "../../../../api/service/TransactionService";
import TransactionItem from "./TransactionItem";
import Error from "../../../ui/Error";
import NotFound from "../../../ui/NotFound";
import { useCategoryService } from "../../../../api/service/CategoryService";
import { useAccountService } from "../../../../api/service/AccountService";

const Transactions = () => {
  const navigation = useNavigation();
  const { getAllTransactions, transactions, error, isLoading, clearError } =
    useTransactionService();
  const { getAllCategories } = useCategoryService();
  const { getAllAccounts } = useAccountService();

  useEffect(() => {
    getAllCategories();
    getAllAccounts();
    clearError();
    getAllTransactions();
  }, []);

  return (
    <View>
      <Text style={styles.headerText}>Операции</Text>
      <Pressable
        style={styles.headerIcon}
        onPress={() => navigation.navigate("TransactionsCreate")}
      >
        <Icon author="Ionicons" name="add" size={35} />
      </Pressable>
      <ScrollView
        refreshControl={
          <RefreshControl
            enabled
            refreshing={isLoading}
            onRefresh={getAllTransactions}
          />
        }
        style={{ width: "100%", minHeight: 200, paddingHorizontal: 30 }}
      >
        {error ? (
          <NotFound title={error} />
        ) : (
          transactions?.map((item) => (
            <TransactionItem transaction={item} key={item.id} />
          ))
        )}
      </ScrollView>
    </View>
  );
};
const styles = StyleSheet.create({
  headerText: {
    fontSize: 20,
    textAlign: "center",
  },
  accountTypeTitle: {
    fontSize: 15,
  },
  headerIcon: {
    position: "absolute",
    right: 10,
  },
});
export default Transactions;
