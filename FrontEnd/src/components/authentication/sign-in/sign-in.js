import React from "react";

import SignInForm from "./sign-in-form";

const UserSignInPattern = {
    Email: undefined,
    Password: undefined,
}

async function userSignInPOST(user) {
    let response = await fetch("https://localhost:5001/Store/User/SignIn", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=utf-8',
            'Email': user.Email,
            'Password': user.Password
        }
    });
    if (response.ok) {
        let json = await response.json();
        console.log(json);
        console.log(document.cookie)
    } else {
        let json = await response.json();
        alert(json.errorMessage);
    }
}

export default class SignIn extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            User: UserSignInPattern
        }

    }

    updateUser = (user) => {
        this.setState({User: user});
    }

    onSignInHandler = (user) => {
        this.updateUser(user);
        userSignInPOST(user).then();
    }

    render() {
        return (<SignInForm onSignIn={this.onSignInHandler}/>)
    }
}