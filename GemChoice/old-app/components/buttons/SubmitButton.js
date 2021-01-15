import React from 'react'
import { StyleSheet, TouchableOpacity } from 'react-native'
import { Text, View } from './../../components/Themed';

export default function SubmitButton({ placeholder, callback }) {

    return (
        <View style={styles.btnContainer}>
            <TouchableOpacity style={styles.btn} onPress={() => callback()}>
                <Text style={styles.btnText}>{placeholder}</Text>
            </TouchableOpacity>
        </View>
    )
}

const styles = StyleSheet.create({
    btnContainer: {
        justifyContent: "center",
        width: "90%"
    },
    btn: {
        padding: 15,
        width: "100%",
        backgroundColor: "#ffd700"
    },
    btnText: {
        fontSize: 18,
        textAlign: "center",
        color: "black"
    }
});