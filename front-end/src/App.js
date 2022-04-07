import React, {useState} from "react";
import {Header} from "./modules/common/components/header/header";
import {User} from "./modules/common/components/user/user";
import {ItemCreateForm} from "./modules/common/components/item-create/item-create-form/item-create-form";
import {Footer} from "./modules/common/components/footer/footer";
import {MainRoutes} from "./modules/routes/main-routes";
import {ItemCreate} from "./modules/common/components/item-create/item-create";


export default function App() {
    const [userExist, setUserExist] = useState(false);
    const [user, setUser] = useState({});

    const userAuthHandler = (User) => {
        setUser(User);
        setUserExist(true);
    }

    return (
        <>
            {userExist ? <User USER={user}/> : <></>}

            <Header auth={userExist}/>
            <MainRoutes USER={user} userAuth={userAuthHandler} auth={userExist}/>
            <Footer/>
        </>
    )
}