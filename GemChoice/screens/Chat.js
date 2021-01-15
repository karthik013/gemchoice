import React, { useState } from 'react'
import { View, Text, TextInput } from 'react-native'

export default function Chat() {
    const [text, setText] = useState('')

    return (
        <View>
            <Text style={{ fontSize: 24 }}>
                This is Chat Page...
            </Text>
        </View>
    )
}