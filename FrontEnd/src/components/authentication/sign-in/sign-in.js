import React from "react";

import SignInForm from "./sign-in-form";

const UserSignInPattern = {
    Email: undefined,
    Password: undefined,
}


export default class SignIn extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            SignInUser: UserSignInPattern
        }

    }

    updateUser = (user) => {
        this.setState({User: user});
    }

    async userSignInPOST(user) {
        let response = await fetch("https://localhost:5001/Store/User/SignIn", {
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
            let jsonToken = this.JWT_decoder(json.token);

            return {
                Id: jsonToken.Id,
                Role: jsonToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'],
                Country: jsonToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/country'],
                UserName: jsonToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'],
                Email: jsonToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'],
                AccessToken: json.token,
            }

        } else {
            let json = await response.json();
            alert(json.errorMessage);
        }
    }

    JWT_decoder = (token) => {
        let base64Url = token.split('.')[1];
        let base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
        let jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
            return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
        }).join(''));

        return JSON.parse(jsonPayload);
    }

    onSignInHandler = (user) => {
        this.updateUser(user);
        this.userSignInPOST(user).then(({Id, Role, Country, UserName, Email, AccessToken}) => {

            user.Id = Id;
            user.Role = Role;
            user.Country = Country;
            user.UserName = UserName;
            user.Email = Email;
            user.AccessToken = AccessToken;

            this.updateUser(user);
            this.props.successSignIn(user);
        });
    }

    render() {
        return (<SignInForm onSignIn={this.onSignInHandler}/>)
    }
}