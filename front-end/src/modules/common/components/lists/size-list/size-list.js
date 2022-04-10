export const SizeList = ({Sizes, itemType}) => {
    let key = 0;
    if (typeof itemType === 'undefined') {
        return (<></>)
    }
    const sizeInputs = Sizes[itemType].map((size) => {
        key++;
        return (
            <div key={key}>
                <label htmlFor={size.Size.toString()}>{size.Size}</label>
                <input type={'number'} id={size.Size.toString()}/>
            </div>
        )
    });
    return (sizeInputs);
}