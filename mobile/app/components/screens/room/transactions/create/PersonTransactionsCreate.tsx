import { View, Text, StyleSheet, Alert } from "react-native";
import React, { useEffect, useState } from "react";
import { SelectList } from "react-native-dropdown-select-list";
import { useAuth } from "../../../../../hooks/useAuth";
import { useAccountService } from "../../../../../api/service/AccountService";
import { IPersonTransaction } from "../../../../../api/interfaces/transaction";
import { useRoom } from "../../../../../providers/RoomProvider";
import Field from "../../../../ui/Field";
import Button from "../../../../ui/Button";
import { useTransactionService } from "../../../../../api/service/TransactionService";
import Error from "../../../../ui/Error";
import { useNavigation } from "@react-navigation/native";
import { useStatisticService } from "../../../../../api/service/StatisticService";

const PersonTransactionsCreate = () => {
  const { getAllAccounts, accounts } = useAccountService();
  const { makePersonTransaction, error, isLoading, clearError } =
    useTransactionService();
  const { user } = useAuth();
  const { roomId } = useRoom();
  const { updateAllStatistic } = useStatisticService();
  const navigation = useNavigation();

  const personAccounts = accounts
    ?.filter((x) => x.personName === user.login)
    ?.map((x) => {
      return {
        key: x.id,
        value: x.name,
      };
    });

  const allAccounts = accounts
    ?.filter((x) => x.accountType.id !== 3 && x.personName !== user.login)
    ?.map((x) => ({
      key: x.id,
      value: x.name,
    }));

  const [data, setData] = useState<IPersonTransaction>({
    name: "",
    sender: -1,
    destination: -1,
    amount: 0,
    roomId: roomId,
  });

  const submitHandler = async () => {
    clearError();

    const result = await makePersonTransaction(data);
    console.log(result);

    if (result) {
      navigation.navigate("Transactions");
      getAllAccounts();
    }
  };

  useEffect(() => {
    clearError();
    getAllAccounts();
  }, []);

  return (
    <View style={styles.container}>
      <View style={styles.content}>
        <Text style={styles.text}>Совершить перевод</Text>

        <Field
          onChange={(value) => {
            setData({ ...data, name: value });
          }}
          value={data.name}
          placeholder="Наименование"
          style={styles.input}
        />

        <Field
          onChange={(value) => {
            setData({ ...data, amount: +value });
          }}
          value={data.amount as any}
          placeholder="Сколько перести"
          style={styles.input}
        />
        <SelectList
          boxStyles={{ marginTop: 10, width: 330 }}
          placeholder="Счёт списания..."
          data={personAccounts ?? []}
          setSelected={(value) => setData({ ...data, sender: value })}
        />

        <SelectList
          boxStyles={{ marginTop: 10, width: 330 }}
          placeholder="Счёт зачисления..."
          data={allAccounts ?? []}
          setSelected={(value) => setData({ ...data, destination: value })}
        />

        {error && <Error text={error} />}

        <Button
          style={{ marginTop: 10 }}
          disabled={isLoading}
          title="Перевести"
          onPress={submitHandler}
        />
      </View>
    </View>
  );
};

const styles = StyleSheet.create({
  container: {
    justifyContent: "center",
    alignItems: "center",
  },
  content: {
    width: "80%",
    justifyContent: "center",
    alignItems: "center",
  },
  text: {
    fontSize: 20,
    marginVertical: 20,
  },
  iconContainer: {
    marginTop: 40,
    width: "100%",
    flexDirection: "row",
    justifyContent: "space-around",
  },
  input: {
    marginTop: 10,
  },
});

export default PersonTransactionsCreate;
