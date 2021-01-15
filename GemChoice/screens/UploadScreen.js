import React from 'react';
import { View, StyleSheet, Button, Text } from 'react-native';

import useStatusBar from '../hooks/useStatusBar';

export default function UploadScreen() {
    useStatusBar('dark-content');
    return (
        <View style={styles.container}>
            <Text>Please Upload your data</Text>
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        flex: 1
    }
});
