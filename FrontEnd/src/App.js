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
        // let response = await fetch("https://localhost:5001/Gender/GetAllGenders");
        let response = await fetch('http://www.filltext.com/?rows=32&id=%7Bnumber%7C1000%7D&firstName=%7BfirstName%7D&lastName=%7BlastName%7D&email=%7Bemail%7D&phone=%7Bphone%7C(xxx)xxx-xx-xx%7D&address=%7BaddressObject%7D&description=%7Blorem%7C32%7D');
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

