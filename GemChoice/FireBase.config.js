import firebase from 'firebase/app';
import '@firebase/auth';
import '@firebase/firestore';

const firebaseConfig = {
    apiKey: "AIzaSyDD03EjDjnR0CugyGwv5iC-lfhlRTVD0Wc",
    authDomain: "gemchioce.firebaseapp.com",
    databaseURL: "https://gemchioce-default-rtdb.firebaseio.com",
    projectId: "gemchioce",
    storageBucket: "gemchioce.appspot.com",
    messagingSenderId: "382682637867",
    appId: "1:382682637867:web:1f88390de312bf2ae1ec6e",
    measurementId: "G-MR4Q0TTVYR"
};


firebase.initializeApp(firebaseConfig);

export { firebase };