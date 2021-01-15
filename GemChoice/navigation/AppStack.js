import * as React from 'react';
import { createStackNavigator } from '@react-navigation/stack';
import HomeBottomTabNavigator from './bottomNavigator'

const Stack = createStackNavigator();

export default function AppStack() {
  return (
    <Stack.Navigator screenOptions={{ headerShown: false }}>
      <Stack.Screen name="HomeRoot" component={HomeBottomTabNavigator} />
    </Stack.Navigator>
  );
}
