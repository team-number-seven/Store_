import {Link} from "react-router-dom";
import './nav-bar.css';
import Search from "../../services/search/search";

export default function NavBar() {

    return (
        <div className="nav-bar">
            <div className="first-filters">
                <Link to='/men'>Men</Link>
                <Link to='/women'>Women</Link>
                <Link to='/kids'>Kids</Link>
            </div>
            <Search/>
        </div>
    )
}