import { View, Text, TouchableHighlight, StyleSheet } from 'react-native';
import React, { FC } from 'react';

interface IButton {
  title: string;
  onPress: () => void;
  colors?: [string, string];
  disabled?: boolean;
  style?: any;
}

const Button: FC<IButton> = ({
  title,
  onPress,
  colors = ['#3346FF', 'white'],
  disabled = false,
  style,
}) => {
  return (
    <View
      style={{
        ...styles.button,
        ...style,
        backgroundColor: colors[0],
        opacity: disabled ? 0.5 : 1,
      }}
    >
      <TouchableHighlight
        onPress={onPress}
        style={{
          ...styles.button,
        }}
        disabled={disabled}
      >
        <Text style={{ ...styles.text, color: colors[1] }}>{title}</Text>
      </TouchableHighlight>
    </View>
  );
};

const styles = StyleSheet.create({
  button: {
    width: '100%',
    height: 55,
    borderRadius: 25,
    alignItems: 'center',
    justifyContent: 'center',
  },
  text: {
    flex: 1,
    textAlign: 'center',
    textAlignVertical: 'center',
    fontSize: 20,
  },
  shadow: {
    shadowColor: '#000',
    shadowOffset: {
      width: 0,
      height: 1,
    },
    shadowOpacity: 0.22,
    shadowRadius: 2.22,

    elevation: 3,
  },
});

export default Button;
