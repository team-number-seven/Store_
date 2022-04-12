const CONFIG = require('../../../../../jsconfig.json')

/*const id = "4e963a09-c19d-40f2-8675-f5e1fbf9936b";

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

const aaa = async () => {
    const query = new QueryGetItemById(id).query;
    const response = await fetch(CONFIG["server"] + CONFIG.requests.GET["item-by-id"] + query, {
        mode: CONFIG["requestMode"],
        headers: {
            'Access-Control-Allow-Origin': CONFIG["origin"],
        }
    })
}

aaa().then();*/


class QueryGetItemByFilter {

    constructor(id) {
        this.id = id;
        this.filters=[];
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

// https://localhost:5001/Store/Item/GetByFilter?ColorsId=0063c4d0-b4cb-4e7f-bef9-d13aad7ac3a7&ColorsId=0024e865-d01e-46cd-b8f2-fa8b47009740

export const Item = () => {
    return (<></>)
}