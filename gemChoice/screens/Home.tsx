import * as React from 'react';
import { StyleSheet, TextInput, TouchableOpacity } from 'react-native';
import { Text, View } from '../components/Themed';

export default function SignUp() {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>Welcome to Gem Store Karthik!!!</Text>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    backgroundColor: 'dodgerblue'
  },
  title: {
    fontSize: 30,
    fontWeight: 'bold',
    textAlign: 'center',
    margin:30
  }
});
