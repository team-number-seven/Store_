const CONFIG = require('../../../jsconfig.json');

export const TypesGET = async () => {

    class Type {
        constructor(id, title, subTypes) {
            this.Id = id;
            this.Title = title;
            this.subTypes = subTypes;
        }
    }

    class SubType {
        constructor(id, title) {
            this.Id = id;
            this.Title = title;
        }
    }


    const response = await fetch(CONFIG["server"] + CONFIG.requests.GET["types"]);

    if (response.ok) {
        let json = await response.json();
        const data = json.typeAndSubItem;

        let Types = [];
        Types = data.map((type) => {
            if (type) {
                let subTypes = [];
                subTypes = type.subItemTypes.map((subItem) => {
                    return new SubType(subItem.id, subItem.title)
                })
                return new Type(type.id, type.title, subTypes);
            } else throw new Error('Failed to operate types');
        });
        return Types;

    } else {
        let json = await response.json();
        console.log(json.errorMessage);
    }


}