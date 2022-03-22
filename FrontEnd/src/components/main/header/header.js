import {Link} from "react-router-dom";
import './header.css';

export default function Header() {
    return (
        <header>
            <div id="header-logo">
                <Link to ='*'>Home</Link>
            </div>
            <div id="header-authentication">
                <Link to='/sign-up'>Sign Up</Link>
                <Link to='/sign-in'>Sign In</Link>
            </div>
        </header>
    )
}