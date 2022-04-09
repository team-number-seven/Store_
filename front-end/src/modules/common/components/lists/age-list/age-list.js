export const AgeList = ({Ages}) => {
    Ages.sort((a, b) => a.Title > b.Title);
    let key = 0;
    let defOption = [<option value="" key={key++} disabled>Choose age</option>];
    const options = Ages.map((age) => {
        key++;
        return <option key={key}>{age.Title}</option>
    });
    const allOptions = defOption.concat(options);
    return (allOptions);
}