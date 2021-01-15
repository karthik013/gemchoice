import React, { useState } from 'react'
import { StyleSheet, TextInput } from 'react-native'

export default function InputTextComponent({ placeholder, setValue }) {
    const [text, setText] = useState('')

    return (
        <TextInput
            style={styles.input}
            value={text}
            placeholder={placeholder}
            onChangeText={(value) => { setText(value); setValue(value) }}
        />
    )
}

const styles = StyleSheet.create({
    input: {
        width: "90%",
        backgroundColor: "#fff",
        padding: 15,
        marginBottom: 10,
        borderRadius: 4
    }
})