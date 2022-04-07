const CONFIG = require('../../../jsconfig.json');

export const AgesGET = async () => {

    class Age {
        constructor(id, title) {
            this.Id = id;
            this.Title = title;
        }
    }

    const response = await fetch(CONFIG["server"] + CONFIG.requests.GET["ages"]);

    if (response.ok) {
        let json = await response.json();
        const data = json.types;

        let Ages=[];
        Ages = data.map((age) => {
            if (age) return new Age(age.id, age.title);
            else throw new Error('Failed to operate ages');
        });
        return Ages;

    } else {
        let json = await response.json();
        console.log(json.errorMessage);
    }


}