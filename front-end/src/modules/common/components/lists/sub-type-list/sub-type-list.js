export const SubTypeList = ({Types, itemType}) => {
    let key = 0;
    let defOption = [<option value="" key={key++} disabled>Choose subtype</option>];

    if (typeof itemType === 'undefined') {
        return (defOption);
    }

    let options = [];
    Types.map((type) => {
        if (type.Title === itemType) {
            options = type.subTypes.map((subType) => {
                key++;
                return <option key={key}>{subType.Title}</option>
            });
        }
    });
    const allOptions = defOption.concat(options);
    return (allOptions);
}