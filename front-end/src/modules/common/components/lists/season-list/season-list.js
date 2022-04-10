export const SeasonList = ({Seasons}) => {
    let key = 0;
    let defOption = [<option value="" key={key++} disabled>Choose season</option>];
    const options = Seasons.map((season) => {
        key++;
        return <option key={key}>{season.Title}</option>
    });
    const allOptions = defOption.concat(options);
    return (allOptions);
}

