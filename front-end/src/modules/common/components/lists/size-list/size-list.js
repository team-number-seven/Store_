export const SizeList = ({Sizes}) => {
    Sizes.sort((a, b) => +a.Size > +b.Size);
    let key = 0;
    const options = Sizes.map((size) => {
        key++;
        return <option key={key}>{size.Size}</option>
    });
    return (options);
}