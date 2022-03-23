import {Outlet} from "react-router-dom";
import React from "react";

export default function HomePage() {

    return (
        <div className="home-page">
            <h1>Main page</h1>
            <Outlet/>
        </div>
    )
}