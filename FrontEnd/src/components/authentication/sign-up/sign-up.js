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
    Id: undefined,
}


export default class SignUp extends React.Component {

    constructor(props) {
        super(props);

        this.state = {
            SignUpUser: UserSignUpPattern
        }

        this.updateUser = this.updateUser.bind(this);
        this.onSignUpHandler = this.onSignUpHandler.bind(this);
        // eslint-disable-next-line no-func-assign
        this.userSignUpPOST = this.userSignUpPOST.bind(this);

        countriesGET().then(() => {
                this.setState({countries: CountryList});
            }
        );
    }

    async userSignUpPOST(user) {

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
            return json.id;

        } else {
            console.log(response);
            alert("Ошибка HTTP: " + response.status);
        }
    }

    updateUser = (user) => {
        this.setState({SignUpUser: user});
    }

    onSignUpHandler = (user) => {
        this.updateUser(user);
        this.userSignUpPOST(user).then((id) => {
                user.Id = id;
                this.updateUser(user);
                this.props.successSignUp(user);
            }
        );

    }

    render() {
        if (this.state.countries) {
            return (<SignUpForm Countries={this.state.countries}
                                onSignUp={this.onSignUpHandler}/>)
        }
        return null;
    }


}