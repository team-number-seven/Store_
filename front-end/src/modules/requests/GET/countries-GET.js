export const CountriesGET = async () => {

    class Country {
        constructor(id, name) {
            this.Id = id;
            this.Name = name;
        }
    }

    const response = await fetch('https://localhost:5001/Store/Country/Get');

    if (response.ok) {
        let json = await response.json();
        const data = json.countries;

        const Countries = data.map((country) => {
            if (country) return new Country(country.id, country.name);
            else throw new Error('Failed to operate countries');
        });
        debugger;
        return Countries;

    } else {
        let json = await response.json();
        console.log(json.errorMessage);
    }


}