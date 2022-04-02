import React, {useState} from "react";
import {Routes, Route} from "react-router-dom";
import './App.css';
import Header from "./components/main/header/header";
import NavBar from "./components/main/nav-bar/nav-bar";
import Footer from "./components/main/footer/footer";
import SignUp from "./components/authentication/sign-up/sign-up";
import SignIn from "./components/authentication/sign-in/sign-in";
import HomePage from "./components/main/home-page/home-page";
import { FileUpload } from "./components/fileupload";


const USER_Pattern = {
    Id: undefined,
    UserName: undefined,
    Email: undefined,
    Country: undefined,
    Role: undefined,

    Favourites: undefined,
    Cart: undefined,

    AccessToken: undefined,
    RefreshToken: undefined,
}

export default class App extends React.Component {

    constructor() {
        super();

        this.state = {
            USER: USER_Pattern,
        }
    }

    setCookie = (name, value, options = {}) => {

        options = {
            path: '/',
            ...options
        };

        if (options.expires instanceof Date) {
            options.expires = options.expires.toUTCString();
        }

        let updatedCookie = encodeURIComponent(name) + "=" + encodeURIComponent(value);

        for (let optionKey in options) {
            updatedCookie += "; " + optionKey;
            let optionValue = options[optionKey];
            if (optionValue !== true) {
                updatedCookie += "=" + optionValue;
            }
        }

        document.cookie = updatedCookie;
    }

    updateUser = (userData) => {
        const newUser = this.state.USER;
        for (let key in userData) {
            for (let USER_key in this.state.USER) {
                if (key === USER_key) {
                    newUser[USER_key] = userData[key];
                }
            }
        }
        this.setState({USER: newUser})
    };

    handler_successSignUp = (userData) => {
        this.updateUser(userData);
        console.log('sign up ', this.state.USER);

    }

    handler_successSignIn = (userData) => {
        this.updateUser(userData);
        console.log('sign in ', this.state.USER);
        this.setCookie(this.state.USER.Role, this.state.USER.UserName, {secure: true, 'max-age': 30});
    }


    render() {
        return (
            <div className="App">
                <Header USER={this.state.USER}/>
                <NavBar/>
                <Routes>
                    <Route path='/' element={<HomePage/>}>
                        <Route path='sign-up'
                               element={<SignUp USER={this.state.USER} successSignUp={this.handler_successSignUp}/>}/>
                        <Route path='sign-in'
                               element={<SignIn USER={this.state.USER} successSignIn={this.handler_successSignIn}/>}/>
                    </Route>
                    <Route path='men' element={<h1>men</h1>}/>
                    <Route path='women' element={<h1>women</h1>}/>
                    <Route path='kids' element={<h1>kids</h1>}/>
                    <Route path={'profile'} element={<h1>User Profile</h1>}/>
                </Routes>

                <button className="btn btn-primary">Get Countries</button>
                <Footer/>
                <FileUpload></FileUpload>
            </div>
        )
    }


}

