import React, {useState} from "react";
import {Header} from "./modules/common/components/header/header";
import {_User} from "./modules/common/components/_user/user";
import {ItemCreateForm} from "./modules/common/components/item-create-form/item-create-form";
import {Footer} from "./modules/common/components/footer/footer";
import {MainRoutes} from "./modules/routes/main-routes";


export default function App() {
    const [userExist, setUserExist] = useState(false);
    const [user, setUser] = useState({});

    const userAuthHandler = (User) => {
        debugger;
        setUser(User);
        setUserExist(true);
    }

    return (
        <>
            {/* eslint-disable-next-line react/jsx-pascal-case */}
            {userExist ? <_User USER={user}/> : <></>}

            <Header/>
            <MainRoutes USER={user} userAuth={userAuthHandler}/>
            <ItemCreateForm/>
            <Footer/>
        </>
    )
}