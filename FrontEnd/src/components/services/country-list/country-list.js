import React from "react";

export default function CountryList(props) {
    let key = 0;
    const options = props.Countries.map((country) => {
        key++;
        return <option key={key}>{country.Name}</option>
    })

    return (options);
}