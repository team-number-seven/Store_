export const TypeList = ({Types}) => {
    let key = 0;
    let defOption = [<option value="" key={key++} disabled>Choose type</option>];
    const options = Types.map((type) => {
        key++;
        return <option key={key}>{type.Title}</option>
    });
    const allOptions = defOption.concat(options);
    return (allOptions);
}

