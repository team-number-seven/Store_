import React, {useState} from "react";
import {Header} from "./modules/common/components/header/header";
import {_User} from "./modules/common/components/_user/user";
import {ItemCreateForm} from "./modules/common/components/item-create-form/item-create-form";
import {Footer} from "./modules/common/components/footer/footer";
import {MainRoutes} from "./modules/routes/main-routes";

let user = {
    Id: 123,
    UserName: 'Name',
    Email: undefined,
    Country: undefined,
    Role: undefined,

    Favourites: undefined,
    Cart: undefined,

    AccessToken: undefined,
    RefreshToken: undefined,
}

export default function App() {
    const [userExist, setUserExist] = useState(false);

    const onUpdatedUser_handler = (USER)=>{
        user = USER;
    }

    return (
        <>

            {/* eslint-disable-next-line react/jsx-pascal-case */}
            {userExist ? <_User USER={user} onUpdatedUser={onUpdatedUser_handler} /> : <></>}
            <button onClick={(e)=>{setUserExist(true)}} >Click</button>

            <Header/>
            <MainRoutes USER={user} />
            <ItemCreateForm/>
            <Footer/>
        </>
    )
}