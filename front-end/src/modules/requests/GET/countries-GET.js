const CONFIG = require('../../../jsconfig.json');

export const CountriesGET = async () => {

    class Country {
        constructor(id, name) {
            this.Id = id;
            this.Name = name;
        }
    }

    const response = await fetch(CONFIG["server"] + CONFIG.requests.GET["countries"]);
    if (response.ok) {
        let json = await response.json();
        const data = json.countries;

        let Countries = [];
        Countries = data.map((country) => {
            if (country) return new Country(country.id, country.name);
            else throw new Error('Failed to operate countries');
        });
        return Countries;

    } else {
        let json = await response.json();
        console.log(json.errorMessage);
    }


}