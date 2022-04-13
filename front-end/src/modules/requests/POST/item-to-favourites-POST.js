import CONFIG from "../../../jsconfig.json";

export const ItemToFavouritesPOST = async (id) => {
    return new Promise(async (resolve, reject) => {
        const response = await fetch(CONFIG["server"] + CONFIG.requests.POST["item-to-favourites"], {
            mode: CONFIG["requestMode"],
            method: 'POST',
            headers: {
                'Content-Type': CONFIG["content-type-URL8"],
                'Access-Control-Allow-Origin': CONFIG["server"],
            },
            body: {
                'ItemId': id,
            }
        })
        if (response.ok) {
            debugger
            let json = await response.json();
            console.log(json);
            resolve(true);
        } else reject(false);
    })
}