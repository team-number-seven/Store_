const CONFIG = require('../../../jsconfig.json');

export const SizesGET = async () => {

    class Size {
        constructor(id, size, standard, itemType) {
            this.Id = id;
            this.Size = size;
            this.Standard = standard;
            this.ItemType = itemType;
            this.Count = 0;
        }
    }

    const response = await fetch(CONFIG["server"] + CONFIG.requests.GET["sizes"]);

    if (response.ok) {
        let json = await response.json();
        const data = json.dto;

        let allSizes = {};
        for (let sizes of data) {
            allSizes[sizes[0].itemType] = [];
        }

        let key = 0;
        for (let sizes in allSizes) {
            allSizes[sizes] = data[key].map((size) => {
                if (size) return new Size(size.id, size.size, size.standard, size.itemType);
                else throw new Error('Failed to operate size');
            });
            key++;
        }

        return allSizes;

    } else {
        let json = await response.json();
        console.log(json.errorMessage);
    }


}