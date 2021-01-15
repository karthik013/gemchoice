import { Ionicons } from '@expo/vector-icons';
import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';
import { createStackNavigator } from '@react-navigation/stack';
import * as React from 'react';


import Home from '../screens/HomeScreen';
import Chat from '../screens/ChatScreen';
import Upload from '../screens/UploadScreen';
import Setting from '../screens/SettingScreen';

const BottomTab = createBottomTabNavigator();

export default function BottomTabNavigator() {
    return (
        <HomeTabBar />
    );
}

function HomeTabBar() {
    //const colorScheme = useColorScheme();
    const color = '#ccc';
    return <BottomTab.Navigator
        initialRouteName="Home"
        tabBarOptions={{ activeTintColor: '#2f95dc' }}
    >
        <BottomTab.Screen
            name="Home"
            component={HomeNavigator}
            options={{
                tabBarIcon: ({ color }) => <TabBarIcon name="home-outline" color={color} />,
            }}
        />
        <BottomTab.Screen
            name="Chat"
            component={ChatNavigator}
            options={{
                tabBarIcon: ({ color }) => <TabBarIcon name="chatbubbles-outline" color={color} />,
            }}
        />
        <BottomTab.Screen
            name="Upload"
            component={UploadNavigator}
            options={{
                tabBarIcon: ({ color }) => <TabBarIcon name="add-circle-outline" color={color} />,
            }}
        />
        <BottomTab.Screen
            name="Setting"
            component={SettingNavigator}
            options={{
                tabBarIcon: ({ color }) => <TabBarIcon name="settings-outline" color={color} />,
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
const HomeStack = createStackNavigator();

function HomeNavigator() {
    return (
        <HomeStack.Navigator>
            <HomeStack.Screen
                name="Home"
                component={Home}
                options={{ headerShown: true }}
            />
        </HomeStack.Navigator>
    );
}

const ChatStack = createStackNavigator();

function ChatNavigator() {
    return (
        <ChatStack.Navigator>
            <ChatStack.Screen
                name="Chat"
                component={Chat}
                options={{ headerShown: true }}
            />
        </ChatStack.Navigator>
    );
}

const UploadStack = createStackNavigator();

function UploadNavigator() {
    return (
        <UploadStack.Navigator>
            <UploadStack.Screen
                name="Upload"
                component={Upload}
                options={{ headerShown: true }}
            />
        </UploadStack.Navigator>
    );
}

const SettingStack = createStackNavigator();

function SettingNavigator() {
    return (
        <SettingStack.Navigator>
            <SettingStack.Screen
                name="Setting"
                component={Setting}
                options={{ headerShown: true }}
            />
        </SettingStack.Navigator>
    );
}
