import React from 'react';
import { View, StyleSheet, Button, Text } from 'react-native';

import useStatusBar from '../hooks/useStatusBar';

export default function ChatScreen() {
    useStatusBar('dark-content');
    return (
        <View style={styles.container}>
            <Text>this is chat screen</Text>
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        flex: 1
    }
});
