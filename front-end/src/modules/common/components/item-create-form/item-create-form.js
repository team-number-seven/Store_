import React, {useState} from "react";

export const ItemCreateForm = () => {

    const uploadFile = async (e) => {
        const formData = new FormData(document.querySelector('#item-create-form'));
        await fetch("https://localhost:5001/Store/Item/Create", {
            method: "POST",
            body: formData
        })
    }
    return (
        <form id={'item-create-form'}>
            <input name={'Title'} type={'text'}/>
            <input name={'Description'} type={'text'}/>
            <input name={'Price'} type={'text'}/>
            <input name={'ArticleNumber'} type={'text'}/>

            <input name={'Files'} type={'file'}/>
            <input type={'button'} value={'Upload'} onClick={uploadFile}/>
        </form>
    )
}