import React from "react";

export const CountryList = ({Countries}) => {
    let key = 0;
    const options = Countries.map((country) => {
        key++;
        return <option key={key}>{country.Name}</option>
    })

    return (options);
}