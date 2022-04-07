const CONFIG = require('../../../jsconfig.json');

export const TypesGET = async () => {

    class Type {
        constructor(id, type) {
            this.Id = id;
            this.Type = type;
        }
    }

    const response = await fetch(CONFIG["server"] + CONFIG.requests.GET["types"]);
    if (response.ok) {
        let json = await response.json();
        const data = json.typeAndSubItem;

        let Types = [];
        Types = data.map((type) => {
            if (type) return new Type(type.id, type.size);
            else throw new Error('Failed to operate types');
        });

        return Types;

    } else {
        let json = await response.json();
        console.log(json.errorMessage);
    }


}