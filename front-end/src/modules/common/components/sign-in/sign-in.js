import {SignInForm} from "../sign-in-form/sign-in-form";

const JWT_decoder = (token) => {
    let base64Url = token.split('.')[1];
    let base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    let jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
}

const userSignInPOST = async (user) => {
    return new Promise(async(resolve, reject) => {
        const response = await fetch("https://localhost:5001/Store/User/SignIn", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=utf-8',
                'Email': user.Email,
                'Password': user.Password
            }
        });
        if (response.ok) {
            let json = {};
            json.token = undefined;
            json.errorMessage = undefined;

            json = await response.json();
            let jsonToken = JWT_decoder(json.token);

            resolve({
                Id: jsonToken.Id,
                Role: jsonToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'],
                Country: jsonToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/country'],
                UserName: jsonToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'],
                Email: jsonToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'],
                AccessToken: json.token,
            })

        } else {
            let json = await response.json();
            alert(json.errorMessage);
            reject(json.errorMessage);
        }
    })
}


export const SignIn = ({USER, userToMainRoutes}) => {
    const SignInHandler = (user) => {
        userSignInPOST(user).then(resolve => {
            user.Id = resolve.Id;
            user.Role = resolve.Role;
            user.Country = resolve.Country;
            user.UserName = resolve.UserName;
            user.Email = resolve.Email;
            user.AccessToken = resolve.AccessToken;

            userToMainRoutes(user);

        }, reject => {
            console.log(reject);
        })

    }
    return (
        <>
            <SignInForm onSignIn={SignInHandler}/>
        </>
    )
}