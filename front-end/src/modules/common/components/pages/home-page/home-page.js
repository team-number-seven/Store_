import {Outlet} from 'react-router-dom';

export const HomePage = () => {
    return (
        <div className="home-page">
            <h1>Home</h1>
            <Outlet/>
        </div>
    )
}