import {BrandList} from "../../lists/brand-list/brand-list";
import {ColorList} from "../../lists/color-list/color-list";
import {AgeList} from "../../lists/age-list/age-list";
import {SizeList} from "../../lists/size-list/size-list";
import {TypeList} from "../../lists/type-list/type-list";
import {GenderList} from "../../lists/gender-list/gender-list";
import {SeasonList} from "../../lists/season-list/season-list";

export const ItemCreateForm = ({Brands, Colors, Types, Genders, Seasons, Sizes, Ages}) => {

    const uploadFile = async (e) => {
        const formData = new FormData(document.querySelector('#item-create-form'));
        await fetch("https://localhost:5001/Store/Item/Create", {
            method: "POST",
            body: formData
        })
    }
    return (
        <form id={'item-create-form'} className="container form-group">
            <input name={'Title'} type={'text'} className="form-control" placeholder={'Title'}/>
            <input name={'Description'} type={'text'} className="form-control" placeholder={'Description'}/>
            <input name={'Price'} type={'text'} className="form-control" placeholder={'Price'}/>
            <input name={'ArticleNumber'} type={'text'} className="form-control" placeholder={'Price'}/>


            <select id="brand-list" className="form-control selectpicker" data-live-search="true"
                    data-width="fit">
                <BrandList Brands={Brands}/>
            </select>

            <select id="color-list" className="form-control selectpicker" data-live-search="true"
                    data-width="fit">
                <ColorList Colors={Colors}/>
            </select>

            <select id="age-list" className="form-control selectpicker" data-live-search="true"
                    data-width="fit">
                <AgeList Ages={Ages}/>
            </select>

            <select id="size-list" className="form-control selectpicker" data-live-search="true"
                    data-width="fit">
                <SizeList Sizes={Sizes}/>
            </select>

            <select id="type-list" className="form-control selectpicker" data-live-search="true"
                    data-width="fit">
                <TypeList Types={Types}/>
            </select>
            <select id="gender-list" className="form-control selectpicker" data-live-search="true"
                    data-width="fit">
                <GenderList Genders={Genders}/>
            </select>
            <select id="season-list" className="form-control selectpicker" data-live-search="true"
                    data-width="fit">
                <SeasonList Seasons={Seasons}/>
            </select>

            <input name={'Files'} type={'file'}/>
            <input type={'button'} value={'Upload'} onClick={uploadFile}/>
        </form>
    )
}