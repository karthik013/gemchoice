import { Ionicons } from '@expo/vector-icons';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { createStackNavigator } from '@react-navigation/stack';
import * as React from 'react';

import Colors from '../constants/Colors';
import useColorScheme from '../hooks/useColorScheme';
import SignIn from '../screens/SignIn';
import SignUp from '../screens/SignUp';

const BottomTab = createBottomTabNavigator();

export default function BottomTabNavigator() {
    return (
        <LoginTabBar />
    );
}

function LoginTabBar() {
    const colorScheme = useColorScheme();
    return <BottomTab.Navigator
        initialRouteName="Home"
        tabBarOptions={{ activeTintColor: Colors[colorScheme].tint }}>
        <BottomTab.Screen
            name="SignIn"
            component={SignInNavigator}
            options={{
                tabBarIcon: ({ color }) => <TabBarIcon name="people-outline" color={color} />,
            }}
        />
        <BottomTab.Screen
            name="SignUp"
            component={SignUpNavigator}
            options={{
                tabBarIcon: ({ color }) => <TabBarIcon name="person-add-outline" color={color} />,
            }}
        />
    </BottomTab.Navigator>;
}

// You can explore the built-in icon families and icons on the web at:
// https://icons.expo.fyi/
function TabBarIcon(props) {
    return <Ionicons size={30} style={{ marginBottom: -3 }} {...props} />;
}

// Each tab has its own navigation stack, you can read more about this pattern here:
// https://reactnavigation.org/docs/tab-based-navigation#a-stack-navigator-for-each-tab
const SignInStack = createStackNavigator();

function SignInNavigator() {
    return (
        <SignInStack.Navigator>
            <SignInStack.Screen
                name="SignIn"
                component={SignIn}
                options={{ headerShown: false }}
            />
        </SignInStack.Navigator>
    );
}

const SignUpStack = createStackNavigator();

function SignUpNavigator() {
    return (
        <SignUpStack.Navigator>
            <SignUpStack.Screen
                name="SignUp"
                component={SignUp}
                options={{ headerShown: false }}
            />
        </SignUpStack.Navigator>
    );
}
