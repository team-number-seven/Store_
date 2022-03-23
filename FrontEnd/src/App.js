import React from "react";
import {Routes, Route} from "react-router-dom";

import Header from "./components/main/header/header";
import NavBar from "./components/main/nav-bar/nav-bar";
import Footer from "./components/main/footer/footer";
import SignUp from "./components/authentication/sign-up/sign-up";
import SignIn from "./components/authentication/sign-in/sign-in";



export default function App() {

    return (
        <div className="App">
            <Routes>
                <Route path='/sign-up' element={<SignUp/>}/>
                <Route path='/sign-in' element={<SignIn/>}/>
            </Routes>

            <Header/>
            <NavBar/>
            <Footer/>
        </div>
    )


}

