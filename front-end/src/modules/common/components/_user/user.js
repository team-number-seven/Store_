import {useState} from "react";


export const _User = ({USER, onUpdatedUser, onSignUpUser = false}) => {

    const [User, setUser] = useState({
        Id: USER.Id,
        UserName: USER.UserName,
        Email: USER.Email,
        Country: USER.Country,
        Role: USER.Role,

        Favourites: USER.Favourites,
        Cart: USER.Cart,

        AccessToken: USER.AccessToken,
        RefreshToken: USER.RefreshToken
    })

    if (onSignUpUser) {
        onUpdatedUser(User);
    }

    console.log(User);


    return (

        <>
        </>
    )
}