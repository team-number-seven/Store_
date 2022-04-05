import {Routes, Route} from "react-router-dom";
import {HomePage} from "../common/components/_pages/home-page/home-page";
import {MenPage} from "../common/components/_pages/men-page/men-page";
import {WomenPage} from "../common/components/_pages/women-page/women-page";
import {KidsPage} from "../common/components/_pages/kids-page/kids-page";
import {SignIn} from "../common/components/sign-in/sign-in";
import {SignUp} from "../common/components/sign-up/sign-in";

export const MainRoutes = ({USER, userAuth}) => {



    const userToMainRoutesHandler = (User) => {
        userAuth(User);
    }

    return (
        <Routes>
            <Route path={'/'} element={<HomePage/>}>
                <Route path={'sign-up'}
                       element={
                           <SignUp USER={USER} userToMainRoutes={userToMainRoutesHandler}/>
                       }/>
                <Route path={'sign-in'} element={
                    <SignIn USER={USER} userToMainRoutes={userToMainRoutesHandler}/>
                }/>
            </Route>
            <Route path={'men'} element={<MenPage/>}/>
            <Route path={'women'} element={<WomenPage/>}/>
            <Route path={'kids'} element={<KidsPage/>}/>
            <Route path={'profile'} element={<h1>User Profile</h1>}/>
        </Routes>
    )
}