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
    let response = await fetch('https://localhost:5001/Store/Country/getAllCountries');

    if (response.ok) {
        let json = await response.json();
        console.log(json);
        let data = json.countries;

        CountryList = data.map((country) => {
            if (country) return new Country(country.id, country.name);
            else throw new Error('Failed to operate countries');
        });

    } else {
        alert("Ошибка HTTP: " + response.status);
    }


}

export default class SignUp extends React.Component {
    constructor() {
        super();
        this.state = {};
        countriesGET().then();
    }



    render() {

        return (
            <SignUpForm Countries={CountryList}/>
        )
    }

}