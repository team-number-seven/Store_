import {SignInForm} from "../sign-in-form/sign-in-form";
import {SignInPOST} from "../../../requests/POST/sign-in-POST";
import {InitUserWithResolve} from "../../../requests/initUserWithResolve";


export const SignIn = ({userToMainRoutes}) => {
    const SignInHandler = (user) => {
        SignInPOST(user).then(resolve => {
            InitUserWithResolve(resolve, user);
            console.log(user);
            userToMainRoutes(user);

        }, reject => {
            console.log(reject);
        });

    }
    return (
        <>
            <SignInForm onSignIn={SignInHandler}/>
        </>
    )
}