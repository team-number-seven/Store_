export const GenderList = ({Genders}) => {
    Genders.sort((a, b) => a.Title > b.Title);
    let key = 0;
    let defOption = [<option value="" key={key++} disabled>Choose gender</option>];
    const options = Genders.map((gender) => {
        key++;
        return <option key={key}>{gender.Title}</option>
    });
    const allOptions = defOption.concat(options);
    return (allOptions);
}
