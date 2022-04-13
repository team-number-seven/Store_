import CONFIG from "../../../jsconfig.json";

export const ItemGETById = async (id) => {

    class QueryGetItemById {

        constructor(id) {
            this.id = id;
            this.query = "?";
            this.buildQuery();
        }

        buildQuery() {
            if (!typeof this.id !== undefined) {
                this.query += `id=${this.id}`;
            }
            return this.query;
        }
    }

    const query = new QueryGetItemById(id).query;
    const response = await fetch(CONFIG["server"] + CONFIG.requests.GET["item-by-id"]+query, {
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

}