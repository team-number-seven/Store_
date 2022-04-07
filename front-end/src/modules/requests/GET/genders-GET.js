const CONFIG = require('../../../jsconfig.json');

export const GendersGET = async () => {

    class Gender {
        constructor(id, title) {
            this.Id = id;
            this.Title = title;
        }
    }

    const response = await fetch(CONFIG["server"] + CONFIG.requests.GET["genders"], {
        mode: CONFIG["requestMode"],
        headers: {
            'Access-Control-Allow-Origin': CONFIG["origin"]
        }
    });
    if (response.ok) {
        let json = await response.json();
        const data = json.genders;

        let Genders = [];
        Genders = data.map((gender) => {
            if (gender) return new Gender(gender.id, gender.title);
            else throw new Error('Failed to operate genders');
        });

        return Genders;

    } else {
        let json = await response.json();
        console.log(json.errorMessage);
    }


}