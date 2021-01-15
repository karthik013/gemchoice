import React, { useState } from 'react'
import { View, Text } from 'react-native'


export default function Home() {
    const [text, setText] = useState('');

    return (
        <View>
            <Text style={{ fontSize: 24 }}>
                This is Home Page...
            </Text>
        </View>
    )
}