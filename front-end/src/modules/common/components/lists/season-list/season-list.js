export const SeasonList = ({Seasons}) => {
    let key = 0;
    const options = Seasons.map((season) => {
        key++;
        return <option key={key}>{season.Title}</option>
    });
    return (options);
}