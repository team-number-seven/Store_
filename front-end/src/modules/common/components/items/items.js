import {ShortItem} from "./short-item/short-item";
import {useState} from "react";
import {ItemGetByFilter} from "../../../requests/GET/item-Get-by-filter";


export const Items = () => {
    const [items, setItems] = useState(undefined)

    if (typeof items === "undefined") {
        ItemGetByFilter().then(value => setItems(value));
    }


    return (
        <>
            {typeof items === "undefined" ? <></>
                :
                <>
                    <ShortItem itemData={items[0]}/>
                    <ShortItem itemData={items[1]}/>
                    <ShortItem itemData={items[2]}/>
                </>

            }


        </>
    )
}