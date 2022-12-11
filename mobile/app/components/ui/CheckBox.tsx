import { View, Text, StyleSheet, Platform, Pressable } from 'react-native';
import React, { FC } from 'react';
import Checkbox from 'expo-checkbox';

interface ICheckBox {
  value: boolean;
  onChange: () => void;
  text: string;
  color?: string;
  style?: any;
  disabled?: boolean;
}

const CheckBox: FC<ICheckBox> = ({
  value,
  onChange,
  text,
  style,
  color = '#4630EB',
  disabled = false,
}) => {
  return (
    <Pressable style={{ ...styles.container, ...style }} onPress={onChange}>
      <Checkbox
        style={styles.checkbox}
        value={value}
        onValueChange={onChange}
        color={color}
        disabled={disabled}
      />
      <Text style={styles.text}>{text}</Text>
    </Pressable>
  );
};

const styles = StyleSheet.create({
  container: {
    justifyContent: 'flex-start',
    flexDirection: 'row',
    width: '100%',
    marginTop: 10,
  },
  checkbox: { height: 25, width: 25 },
  text: {
    marginLeft: 8,
    fontSize: 16,
  },
});

export default CheckBox;
