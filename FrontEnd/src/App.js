import React from "react";
import {Routes, Route} from "react-router-dom";
import './App.css';

import Header from "./components/main/header/header";
import NavBar from "./components/main/nav-bar/nav-bar";
import Footer from "./components/main/footer/footer";
import SignUp from "./components/authentication/sign-up/sign-up";
import SignIn from "./components/authentication/sign-in/sign-in";
import HomePage from "./components/main/home-page/home-page";


export default function App() {


    async function GET() {
        let response = await fetch("https://localhost:5001/Store/Gender/CreateGender", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=utf-8',
            }
        });
        if (response.ok) {
            let json = await response.json();
            console.log(json);
        } else {
            alert("Ошибка HTTP: " + response.status);
        }

    }

    return (
        <div className="App">
            <Header/>
            <NavBar/>
            <Routes>
                <Route path='/' element={<HomePage/>}>
                    <Route path='sign-up' element={<SignUp/>}/>
                    <Route path='sign-in' element={<SignIn/>}/>
                </Route>
                <Route path='men' element={<h1>men</h1>}/>
                <Route path='women' element={<h1>women</h1>}/>
                <Route path='kids' element={<h1>kids</h1>}/>
            </Routes>


            <button className="btn btn-primary" onClick={GET}>Get Countries</button>
            <Footer/>
        </div>
    )


}

