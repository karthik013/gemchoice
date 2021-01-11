import { NavigationContainer, DefaultTheme, DarkTheme } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';
import * as React from 'react';

import HomeBottomTabNavigator from './HomeBottomTabNavigator';
import LoginBottomTabNavigator from './LoginBottomTabNavigator';
import LinkingConfiguration from './LinkingConfiguration';

// If you are not familiar with React Navigation, we recommend going through the
// "Fundamentals" guide: https://reactnavigation.org/docs/getting-started
export default function Navigation({ colorScheme }) {
  return (
    <NavigationContainer
      linking={LinkingConfiguration}//TODO: need to change it
      theme={colorScheme === 'dark' ? DarkTheme : DefaultTheme}>
      {(false) ? <HomeStackScreen /> : <LoginStackScreen />}
    </NavigationContainer>
  );
}

// A root stack navigator is often used for displaying modals on top of all other content
// Read more here: https://reactnavigation.org/docs/modal


function HomeStackScreen() {
  const HomeStack = createStackNavigator();
  return (
    <HomeStack.Navigator screenOptions={{ headerShown: false }}>
      <HomeStack.Screen name="HomeRoot" component={HomeBottomTabNavigator} />
      {/* <Stack.Screen name="NotFound" component={NotFoundScreen} options={{ title: 'Oops!' }} /> */}
    </HomeStack.Navigator>
  );
}

function LoginStackScreen() {
  const LoginStack = createStackNavigator();
  return (
    <LoginStack.Navigator screenOptions={{ headerShown: false }}>
      <LoginStack.Screen name="LoginRoot" component={LoginBottomTabNavigator} />
    </LoginStack.Navigator>
  );
}
