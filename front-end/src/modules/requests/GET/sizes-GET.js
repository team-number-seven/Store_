const CONFIG = require('../../../jsconfig.json');

export const SizesGET = async () => {

    class Size {
        constructor(id, size) {
            this.Id = id;
            this.Size = size;
        }
    }

    const response = await fetch(CONFIG["server"] + CONFIG.requests.GET["sizes"]);
    if (response.ok) {
        let json = await response.json();
        const data = json.sizes;

        let Sizes = [];
        Sizes = data.map((size) => {
            if (size) return new Size(size.id, size.size);
            else throw new Error('Failed to operate size');
        });

        return Sizes;

    } else {
        let json = await response.jsize
        console.log(json.errorMessage);
    }


}