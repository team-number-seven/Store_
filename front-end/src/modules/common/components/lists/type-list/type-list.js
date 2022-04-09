export const TypeList = ({Types}) => {
    let key = 0;
    const options = Types.map((type) => {
        key++;
        return <option key={key}>{type.Title}</option>
    });
    return (options);
}