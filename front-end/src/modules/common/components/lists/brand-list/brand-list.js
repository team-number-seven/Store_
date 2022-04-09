export const BrandList = ({Brands}) => {
    let key = 0;
    const options = Brands.map((brand) => {
        key++;
        return <option key={key}>{brand.Title}</option>
    });
    return (options);
}