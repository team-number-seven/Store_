import {Link} from "react-router-dom";
import './nav-bar.css';
import Search from "../../services/search/search";

export default function NavBar() {

    return (
        <div className="nav-bar">
            <div className="first-filters">
                <Link to='*'>Men</Link>
                <Link to='*'>Women</Link>
                <Link to='*'>Kids</Link>
            </div>
            <Search/>
        </div>
    )
}