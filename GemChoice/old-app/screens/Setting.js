import React, { useState } from 'react'
import { View, Text } from 'react-native'
import { useAsyncStorage } from '@react-native-async-storage/async-storage'
import { } from '../navigation'

export default function Setting({ navigation }) {
    const [text, setText] = useState('')

    const clearAsyncStorage = async () => {
        const { getItem, setItem, removeItem, mergeItem } = useAsyncStorage('@localUser');
        await removeItem();
        navigation.navigate('')
    }

    return (
        <View>
            <Text style={{ fontSize: 24 }}>
                This is Setting Page...
            </Text>
            <Text onPress={() => clearAsyncStorage()}>LogOut</Text>
        </View>
    )
}