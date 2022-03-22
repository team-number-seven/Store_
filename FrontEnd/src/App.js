import React from "react";
import {Routes, Route, Link} from "react-router-dom";

import SignIn from "./components/authentication/sign-in/sign-in";
import SignUp from "./components/authentication/sign-up/sign-up";
import Header from "./components/main/header/header";
import NavBar from "./components/main/nav-bar/nav-bar";
import Footer from "./components/main/footer/footer";


export default function App() {

    return (
        <div className="App">
            <Routes>
                <Route path='/sign-up' element={<SignUp/>}/>
                <Route path='/sign-in' element={<SignIn/>}/>
            </Routes>
            <Header/>
            <NavBar/>
            {/*<header>
                <Link to='/'>Home</Link>
                <Link to='/sign-up'>Sign Up</Link>
                <Link to='/sign-in'>
                </Link>
            </header>*/}
            <Footer/>


        </div>
    )


}

