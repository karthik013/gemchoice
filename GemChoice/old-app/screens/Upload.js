import React, { useState } from 'react'
import { View, Text, TextInput } from 'react-native'

export default function Upload() {
    const [text, setText] = useState('')

    return (
        <View>
            <Text style={{ fontSize: 24 }}>
                This is Upload Page...
            </Text>
        </View>
    )
}