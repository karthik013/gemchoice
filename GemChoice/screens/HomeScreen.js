import React from 'react';
import { View, StyleSheet, Text } from 'react-native';

import useStatusBar from '../hooks/useStatusBar';

export default function HomeScreen() {
  useStatusBar('dark-content');
  return (
    <View style={styles.container}>
      <Text>Welcome to Gem Choice</Text>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1
  }
});
