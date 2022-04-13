import {Navigate, useNavigate} from "react-router-dom";

export const ShortItem = ({itemData}) => {

    const navigate = useNavigate();

    const onClickShortItemHandler = (id) => {
        navigate(`item/${id}`, {replace: true});
    }

    return (
        <div className={'short-item'} style={{backgroundColor: "lightblue"}}
             onClick={() => onClickShortItemHandler(itemData.id)}>
            <p>{itemData.title}</p>
            <p>{itemData.color}</p>
            <p>{itemData.type}</p>
            <p>{itemData.subType}</p>

            <img src={'data:image/png;base64, ' + itemData.image.fileContents} alt={itemData.title}/>
            <p>{itemData.price}</p>
        </div>
    )
}