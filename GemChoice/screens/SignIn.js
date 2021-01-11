import React, { useState, useEffect } from 'react'
import { firebase } from '../FireBase.config'
import { StyleSheet, Image } from 'react-native'
import InputTextComponent from '../components/inputs/InputTextComponent'
import SubmitButton from './../components/buttons/SubmitButton'
import { View } from '../components/Themed';

export default function SignIn() {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');

    const onLoginPress = () => {
        alert(username + '-' + password);
        firebase
            .auth()
            .signInWithEmailAndPassword('karthik013mail@gmail.com', 'karthik013')
            .then((response) => {
                alert('loginsuccessful');
                //     const uid = response.user.uid
                //     const usersRef = firebase.firestore().collection('users')
                //     usersRef
                //         .doc(uid)
                //         .get()
                //         .then(firestoreDocument => {
                //             if (!firestoreDocument.exists) {
                //                 alert("User does not exist anymore.")
                //                 return;
                //             }
                //             const user = firestoreDocument.data()
                //             navigation.navigate('Home', { user })
                //         })
                //         .catch(error => {
                //             alert(error)
                //         });
            })
            .catch(error => {
                alert(error)
            })
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