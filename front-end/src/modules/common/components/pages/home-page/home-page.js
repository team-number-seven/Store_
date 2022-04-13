import {Outlet} from 'react-router-dom';
import {Items} from "../../items/items";

export const HomePage = () => {
    return (
        <div className="home-page">
            <h1>Home</h1>
            <Items/>
            <Outlet/>
        </div>
    )
}