import { StatusBar } from 'expo-status-bar';
import * as React from 'react';
import { StyleSheet, TouchableOpacity, Image } from 'react-native';
import { TextInput } from 'react-native-gesture-handler';
import { Text, View } from '../components/Themed';

export default function SignIn() {
  return (
    <View style={styles.container}>
      <StatusBar 
      backgroundColor="dodgerblue"
      />
      <Image style={styles.imageLogo} source={require('./../assets/images/logo.png')} />
      {/* <Text style={styles.title}>Welcome to Gem Store</Text> */}
      <TextInput placeholder="UserName" placeholderTextColor="#000" style={styles.input}></TextInput>
      <TextInput placeholder="Password" placeholderTextColor="#000" style={styles.input} secureTextEntry></TextInput>
      <View style={styles.btnContainer}>
        <TouchableOpacity style={styles.btn}>
          <Text style={styles.btnText} onPress={()=> alert("Login Successfully!")}>Login</Text>
        </TouchableOpacity>
      </View>
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
    fontSize: 20,
    textAlign: 'center',
    margin:10
  },
  separator: {
    marginVertical: 30,
    height: 1,
    width: '80%',
  },
  imageLogo: {
    marginBottom: 20
  },
  input: {
    width: "90%",
    backgroundColor: "#fff",
    padding: 15,
    marginBottom: 10,
    borderRadius: 4
  },
  btnContainer: {
    justifyContent: "center",
    width: "90%"
  },
  btn: {
    padding: 15,
    width: "100%",
    backgroundColor: "#ffd700"
  },
  btnText:{
    fontSize: 18,
    textAlign: "center",
    color: "black"
  }
});
