export const SizeList = ({Sizes}) => {
    let key = 0;
    const options = Sizes.map((size) => {
        key++;
        return <option key={key}>{size.Size}</option>
    });
    return (options);
}