export const CountryList = ({Countries}) => {
    Countries.sort((a, b) => a.Name > b.Name);
    let key = 0;
    let defOption = [<option value="" key={key++} disabled>Choose your country</option>];
    const options = Countries.map((country) => {
        key++;
        return <option key={key}>{country.Name}</option>
    });
    const allOptions = defOption.concat(options);
    return (allOptions);
}

