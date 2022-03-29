import React from "react";
import SignUpForm from "./sign-up-form";


class Country {
    constructor(id, name) {
        this.Id = id;
        this.Name = name;
    }
}

let CountryList = [];

async function countriesGET() {
    let response = await fetch('https://localhost:5001/Store/Country/Get');

    if (response.ok) {
        let json = await response.json();
        let data = json.countries;

        CountryList = data.map((country) => {
            if (country) return new Country(country.id, country.name);
            else throw new Error('Failed to operate countries');
        });

    } else {
        alert("Ошибка HTTP: " + response.status);
    }


}

const UserSignUpPattern = {
    UserName: undefined,
    Email: undefined,
    Password: undefined,
    CountryId: undefined,
    PhoneNumber: undefined,
}

async function userSignUpPOST(user) {

    let response = await fetch("https://localhost:5001/Store/User/SignUp", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json; charset=utf-8',
            'UserName': user.UserName,
            'Email': user.Email,
            'Password': user.Password,
            'CountryId': user.CountryId,
            'PhoneNumber': user.PhoneNumber
        }
    });
    if (response.ok) {
        let json = await response.json();
        console.log(json);
        console.log(response);
    } else {
        console.log(response);
        alert("Ошибка HTTP: " + response.status);
    }
}


export default class SignUp extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            User: UserSignUpPattern
        }

        this.updateUser = this.updateUser.bind(this);
        this.onSignUpHandler = this.onSignUpHandler.bind(this);
        // eslint-disable-next-line no-func-assign
        userSignUpPOST = userSignUpPOST.bind(this);

        countriesGET().then(() => {
                this.setState({countries: CountryList});
            }
        );
    }

    updateUser = (user) => {
        this.setState({User: user});
    }

    onSignUpHandler = (user) => {
        this.updateUser(user);
        userSignUpPOST(user).then();
    }

    render() {
        if (this.state.countries) {
            return (<SignUpForm Countries={this.state.countries}
                                onSignUp={this.onSignUpHandler}/>)
        }
        return null;
    }


}