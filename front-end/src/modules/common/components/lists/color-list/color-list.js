export const ColorList = ({Colors}) => {
    let key = 0;
    const options = Colors.map((color) => {
        key++;
        return <option key={key}>{color.Title}</option>
    });
    return (options);
}