export const AgeList = ({Ages}) => {
    let key = 0;
    const options = Ages.map((age) => {
        key++;
        return <option key={key}>{age.Title}</option>
    });
    return (options);
}