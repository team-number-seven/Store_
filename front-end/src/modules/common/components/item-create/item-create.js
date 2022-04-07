import {useState} from "react";
import {AgesGET} from "../../../requests/GET/ages-GET";
import {BrandsGET} from "../../../requests/GET/brands-GET";
import {ColorsGET} from "../../../requests/GET/colors-GET";
import {GendersGET} from "../../../requests/GET/genders-GET";
import {SeasonsGET} from "../../../requests/GET/seasons-GET";
import {SizesGET} from "../../../requests/GET/sizes-GET";
import {TypesGET} from "../../../requests/GET/types-GET";
import {ItemCreateForm} from "./item-create-form/item-create-form";

export const ItemCreate = () => {
    const [Brands, setBrands] = useState(undefined);
    const [Colors, setColors] = useState(undefined);
    const [Sizes, setSizes] = useState(undefined);
    const [Ages, setAges] = useState(undefined);
    const [Seasons, setSeasons] = useState(undefined);
    const [Genders, setGenders] = useState(undefined);
    const [Types, setTypes] = useState(undefined);

    if (typeof Brands === 'undefined') {
        AgesGET().then((value) => {
            setAges(value);
        });
        BrandsGET().then((value) => {
            setBrands(value);
        });
        ColorsGET().then((value) => {
            setColors(value);
        });
        GendersGET().then((value) => {
            setGenders(value);
        });
        SeasonsGET().then((value) => {
            setSeasons(value);
        });
        SizesGET().then((value) => {
            setSizes(value);
        });
        TypesGET().then((value) => {
            setTypes(value);
        });
    }

    return(
        <ItemCreateForm/>
    )
}
