export const SizeList = ({Sizes, itemType, onChangeSize}) => {
    let key = 0;
    if (typeof itemType === 'undefined') {
        return (<></>)
    }
    const sizeInputs = Sizes[itemType].map((size) => {
        key++;
        return (
            <div key={key}>
                <label htmlFor={`size-${size.Size.toString()}`}>{size.Size}</label>
                <input type={'number'} id={`size-${size.Size.toString()}`} onChange={(e) => onChangeSize(e)}/>
            </div>
        )
    });
    return (sizeInputs);
}