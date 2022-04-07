const CONFIG = require('../../../jsconfig.json');

export const BrandsGET = async () => {

    class Brand {
        constructor(id, title) {
            this.Id = id;
            this.Title = title;
        }
    }

    const response = await fetch(CONFIG["server"] + CONFIG.requests.GET["brands"]);

    if (response.ok) {
        let json = await response.json();
        const data = json.brands;

        let Brands = [];
        Brands = data.map((brand) => {
            if (brand) return new Brand(brand.id, brand.title);
            else throw new Error('Failed to operate brands');
        });
        return Brands;

    } else {
        let json = await response.json();
        console.log(json.errorMessage);
    }


}