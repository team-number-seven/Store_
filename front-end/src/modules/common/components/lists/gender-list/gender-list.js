export const GenderList = ({Genders}) => {
    let key = 0;
    const options = Genders.map((gender) => {
        key++;
        return <option key={key}>{gender.Title}</option>
    });
    return (options);
}