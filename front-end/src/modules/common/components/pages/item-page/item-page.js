import {Outlet} from 'react-router-dom';

export const ItemPage = () => {
    return (
        <div className="home-page">
            <h1>Item page</h1>
            <Outlet/>
        </div>
    )
}