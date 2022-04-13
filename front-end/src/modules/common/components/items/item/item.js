import {useParams} from "react-router-dom";
import {useState} from "react";
import {ItemGETById} from "../../../../requests/GET/item-GET-by-id";
import {ItemToFavouritesPOST} from "../../../../requests/POST/item-to-favourites-POST";


export const Item = () => {
    const params = useParams();
    const itemId = params.id;
    const [itemData, setItemData] = useState(undefined);

    if (typeof itemData === "undefined") {
        ItemGETById(itemId).then(value => setItemData(value));
    }


    const itemLikeHandler = () => {
        ItemToFavouritesPOST(itemData.id).then(resolve => {
            console.log('added to favourites successfully');
        }, reject => {
            console.log('failed when adding to favourites');
        });
    }

    const itemToCartHandler = () => {

    }

    let key = 0;

    return (
        <>
            {typeof itemData === "undefined" ? <></>
                :
                <div className={'item'}>
                    {itemData.images.map((image) => {
                        key++;
                        return <img style={{
                            width: '100px',
                            height: '100px',
                            objectFit: 'cover',
                            objectPosition: '0 0',
                        }} src={'data:image/png;base64, ' + image.fileContents} alt={itemData.title} key={key}/>
                    })}
                    <p>{itemData.title}</p>
                    <p>{itemData.description}</p>
                    <p>{itemData.type}</p>
                    <p>{itemData.subType}</p>
                    <p>{itemData.color}</p>
                    <p>{itemData.brand}</p>
                    <p>{itemData.articleNumber}</p>
                    {
                        itemData.sizes.map((size) => {
                            key++;
                            if (+size.count === 0) {
                                return <button className={'btn'} key={key} disabled>{size.size}</button>

                            }
                            return <button className={'btn'} key={key}>{size.size}</button>
                        })
                    }
                    <button className={'btn btn-primary'} onClick={itemLikeHandler}>Like</button>
                    <button className={'btn btn-primary'} onClick={itemToCartHandler}>Add to Cart</button>


                </div>
            }
        </>
    )
}