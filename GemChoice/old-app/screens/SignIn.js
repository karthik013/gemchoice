import React, { useState, useEffect } from 'react'
import { firebase } from '../FireBase.config'
import { StyleSheet, Image } from 'react-native'
import InputTextComponent from '../components/inputs/InputTextComponent'
import SubmitButton from './../components/buttons/SubmitButton'
import { View } from '../components/Themed';
import { useAsyncStorage } from '@react-native-async-storage/async-storage';

export default function SignIn({ navigation }) {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');


    const onLoginPress = async () => {
        alert(username + '-' + password);
        const { getItem, setItem } = useAsyncStorage('@localUser');
        //setItem('calleddd')
        //setUser
        // const rr = await getItem();
        // alert(rr);
        // console.log(rr);
        firebase
            .auth()
            .signInWithEmailAndPassword('karthik013mail@gmail.com', 'karthik013')
            .then((user) => {
                alert('login successful');
                //console.log(user);
                setItem('karthik013mail@gmail.com')
                navigation.navigate('Home')
            })
            .catch(error => {
                alert(error.message)
            });
    };

    return (
        <View style={styles.container}>
            <Image style={styles.imageLogo} source={require('./../assets/images/logo.png')} />
            <InputTextComponent placeholder={'Username'} setValue={setUsername} />
            <InputTextComponent placeholder={'Password'} setValue={setPassword} />
            <SubmitButton placeholder={'Login'} callback={() => onLoginPress()} />
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        alignItems: 'center',
        justifyContent: 'center',
        //backgroundColor: 'dodgerblue'
    },
    imageLogo: {
        marginBottom: 20
    }
});