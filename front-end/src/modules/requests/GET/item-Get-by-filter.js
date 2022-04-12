import CONFIG from "../../../jsconfig.json";

export const ItemGetByFilter = async (filters) => {

    class QueryGetItemByFilter {

        constructor(filters = {
            MinPrice: '228',
            MaxPrice: '1337',
            BrandsId: ['030c38ab-feef-401f-b714-fa6193849f3f', '1a2c0024-5ef8-448a-96a8-11a53bf97761'],
            ColorsId: [],
            SizesId: [],
            AgeTypeId: '',
            SeasonsId: [],
            GendersId: ['4bcccab5-8078-4183-acf5-b2424124c55f'],
            ItemTypesId: [],
            SubTypesId: [],
            GetCountItems: '10'
        }) {
            this.filters = filters;
            this.query = "?";
            this.buildQuery();
        }


        buildQuery() {
            debugger;
            for (let filter in this.filters) {
                if (typeof this.filters[filter] !== "string") {
                    for (let id of this.filters[filter]) {
                        this.query += `${filter}=${id}&`;
                    }
                } else {
                    if (this.filters[filter].length === 0) {
                        continue;
                    }
                    this.query += `${filter}=${this.filters[filter]}&`
                }
            }
            return this.query;
        }
    }

    const query = new QueryGetItemByFilter().query;
    const response = await fetch(CONFIG["server"] + CONFIG.requests.GET["item-by-filter"] + query, {
        mode: CONFIG["requestMode"],
        headers: {
            'Access-Control-Allow-Origin': CONFIG["origin"],
        }
    });
    if (response.ok) {
        let json = await response.json();
        return json.item;

    } else {
        let json = await response.json();
        console.log(json.errorMessage);
    }
    // https://localhost:5001/Store/Item/GetByFilter?ColorsId=0063c4d0-b4cb-4e7f-bef9-d13aad7ac3a7&ColorsId=0024e865-d01e-46cd-b8f2-fa8b47009740
}