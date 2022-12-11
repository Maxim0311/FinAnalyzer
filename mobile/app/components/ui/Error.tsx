import { View, Text } from 'react-native';
import React, { FC } from 'react';

interface IError {
  text: string;
  style?: any;
}

const Error: FC<IError> = ({ text, style }) => {
  return (
    <Text style={{ color: 'red', width: '100%', fontSize: 16, ...style }}>
      {text}
    </Text>
  );
};

export default Error;
