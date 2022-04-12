import {Routes, Route, Navigate, useNavigate} from "react-router-dom";
import {HomePage} from "../common/components/pages/home-page/home-page";
import {MenPage} from "../common/components/pages/men-page/men-page";
import {WomenPage} from "../common/components/pages/women-page/women-page";
import {KidsPage} from "../common/components/pages/kids-page/kids-page";
import {SignIn} from "../common/components/sign-in/sign-in";
import {SignUp} from "../common/components/sign-up/sign-up";
import {ProfilePage} from "../common/components/pages/profile-page/profile-page";
import {ItemCreate} from "../common/components/items/item-create/item-create";
import {EmailSuccess} from "../common/components/email/confirm/email-success/email-success";
import {EmailExist} from "../common/components/email/confirm/email-exist/email-exist";
import {EmailNotFound} from "../common/components/email/confirm/email-not-found/email-not-found";


export const MainRoutes = ({USER, userAuth, auth}) => {
    let navigate = useNavigate();
    const userToMainRoutesHandler = (User) => {
        userAuth(User);
        navigate('/', {replace: true});
    }


    return (
        <>

            <Routes>

                <Route path={'/'} element={<HomePage/>}>
                    <Route path={'sign-up'} element={
                        !auth ? <SignUp USER={USER} userToMainRoutes={userToMainRoutesHandler}/> :
                            <Navigate to={'../'} replace={true}/>
                    }/>
                    <Route path={'sign-in'} element={
                        !auth ? <SignIn USER={USER} userToMainRoutes={userToMainRoutesHandler}/> :
                            <Navigate to={'../'} replace={true}/>
                    }/>
                </Route>
                <Route path={'men'} element={<MenPage/>}/>
                <Route path={'women'} element={<WomenPage/>}/>
                <Route path={'kids'} element={<KidsPage/>}/>
                <Route
                    path={'profile'}
                    element={auth ? <ProfilePage/> : <Navigate to={'../sign-in'} replace={true}/>}
                />
                <Route
                    path={'item-create'}
                    element={auth ? <ItemCreate/> : <Navigate to={'../sign-in'} replace={true}/>}
                />

                <Route path={'email/confirm/success'} element={<EmailSuccess/>}/>
                <Route path={'email/confirm/exist'} element={<EmailExist/>}/>
                <Route path={'email/confirm/not-found'} element={<EmailNotFound/>}/>


            </Routes>
        </>
    )
}