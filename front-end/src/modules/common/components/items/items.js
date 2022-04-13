import {ShortItem} from "./short-item/short-item";
import {useState} from "react";
import {ItemGetByFilter} from "../../../requests/GET/item-Get-by-filter";
import {Routes, Route, Navigate, useNavigate} from "react-router-dom";
import {Item} from "./item/item";


export const Items = () => {
    const [items, setItems] = useState(undefined)

    const generateRoutes = () => {
        let k = 0;
        const routes = items.map((item) => {
            k++;
            return <Route key={k} path={`item/${item.id}`} element={<Item itemId={item.id}/>}/>
        });
        return (

            <Routes>
                {routes}
            </Routes>
        )
    }

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

                    {generateRoutes()}
                </>

            }


        </>
    )
}