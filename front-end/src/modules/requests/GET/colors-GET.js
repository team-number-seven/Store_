const CONFIG = require('../../../jsconfig.json');

export const ColorsGET = async () => {

    class Color {
        constructor(id, title) {
            this.Id = id;
            this.Title = title;
        }
    }

    const response = await fetch(CONFIG["server"] + CONFIG.requests.GET["colors"]);
    if (response.ok) {
        let json = await response.json();
        const data = json.colors;

        let Colors=[];
        Colors = data.map((color) => {
            if (color) return new Color(color.id, color.title);
            else throw new Error('Failed to operate colors');
        });
        return Colors;

    } else {
        let json = await response.json();
        console.log(json.errorMessage);
    }


}