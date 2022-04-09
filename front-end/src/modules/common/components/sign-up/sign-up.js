import {SignUpForm} from "./sign-up-form/sign-up-form";
import {SignUpPOST} from "../../../requests/POST/sign-up-POST";
import {SignInPOST} from "../../../requests/POST/sign-in-POST";
import {InitUserWithResolve} from "../../../requests/initUserWithResolve";
import {CountriesGET} from "../../../requests/GET/countries-GET";
import {useState} from "react";

export const SignUp = ({userToMainRoutes}) => {
    const [Countries, setCountries] = useState([]);
    if (Countries.length === 0) {
        CountriesGET().then((value) => {
            setCountries(value);
        });
    }

    const onSignUpHandler = (user) => {
        SignUpPOST(user).then(
            resolve => SignInPOST(user).then(resolve => {
                InitUserWithResolve(resolve, user);
                userToMainRoutes(user);
            }, reject => {
                console.log(reject);
            })
            , reject => {
                console.log(reject);
            });
    }


    return (
        <>
            <SignUpForm Countries={Countries} onSignUp={onSignUpHandler}/>
        </>
    )
}