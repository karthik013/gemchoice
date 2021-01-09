import * as React from 'react';
import { StyleSheet, TextInput, TouchableOpacity } from 'react-native';
import { Text, View } from '../components/Themed';

export default function SignUp() {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>Sign up</Text>
      <TextInput placeholder="UserName" placeholderTextColor="#000" style={styles.input}></TextInput>
      <TextInput placeholder="FirstName" placeholderTextColor="#000" style={styles.input}></TextInput>
      <TextInput placeholder="LastName" placeholderTextColor="#000" style={styles.input}></TextInput>
      <TextInput placeholder="Mobile" placeholderTextColor="#000" style={styles.input}></TextInput>
      <TextInput placeholder="Email" placeholderTextColor="#000" style={styles.input}></TextInput>
      <TextInput placeholder="Password" placeholderTextColor="#000" style={styles.input} secureTextEntry></TextInput>
      <View style={styles.btnContainer}>
        <TouchableOpacity style={styles.btn}>
          <Text style={styles.btnText} onPress={()=> alert("Registered Successfully!")}>Register</Text>
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
    fontSize: 30,
    //fontWeight: 'bold',
    textAlign: 'center',
    margin:30
  },
  separator: {
    marginVertical: 30,
    height: 1,
    width: '80%',
  },
  input: {
    width: "90%",
    backgroundColor: "#fff",
    padding: 15,
    marginBottom: 10,
    fontSize:15,
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
