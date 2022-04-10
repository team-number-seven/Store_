export const ColorList = ({Colors}) => {
    let key = 0;
    let defOption = [<option value="" key={key++} disabled>Choose color</option>];
    const options = Colors.map((color) => {
        key++;
        return <option key={key}>{color.Title}</option>
    });
    const allOptions = defOption.concat(options);
    return (allOptions);
}

