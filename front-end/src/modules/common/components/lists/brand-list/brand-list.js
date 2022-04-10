export const BrandList = ({Brands}) => {
    let key = 0;
    let defOption = [<option value="" key={key++} disabled>Choose brand</option>];
    const options = Brands.map((brand) => {
        key++;
        return <option key={key}>{brand.Title}</option>
    });
    const allOptions = defOption.concat(options);
    return (allOptions);
}
