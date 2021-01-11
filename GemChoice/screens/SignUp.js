import React, { useState, useEffect } from 'react'
import { StyleSheet } from 'react-native'
import InputTextComponent from '../components/inputs/InputTextComponent'
import SubmitButton from './../components/buttons/SubmitButton'
import { View } from '../components/Themed';

export default function SignUp() {

    useEffect(() => {
        // console.log('started');
        // firebase
        //     .auth()
        //     .createUserWithEmailAndPassword('testtest@gmail.com', 'karthik013')
        //     .then((response) => {
        //         console.log(response);
        //         const uid = response.user.uid
        //         const data = {
        //             id: uid,
        //             email,
        //             fullName,
        //         };
        //         const usersRef = firebase.firestore().collection('users')
        //         usersRef
        //             .doc(uid)
        //             .set(data)
        //             .then(() => {
        //                 navigation.navigate('Home', { user: data })
        //             })
        //             .catch((error) => {
        //                 console.log('error');
        //                 alert(error)
        //             });
        //     })
        //     .catch((error) => {
        //         alert(error)
        //     });
    }, []);

    return (
        <View>
            <InputTextComponent placeholder={'Firstname'} />
            <InputTextComponent placeholder={'Lastname'} />
            <InputTextComponent placeholder={'Username'} />
            <InputTextComponent placeholder={'Mobile'} />
            <InputTextComponent placeholder={'Email'} />
            <InputTextComponent placeholder={'Password'} />
            <SubmitButton placeholder={'Register'} />
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        alignItems: 'center',
        justifyContent: 'center'
    }
});