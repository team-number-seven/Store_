import {Link} from "react-router-dom";

export const Header = () => {
    return (<header>
        <Link to ='/'>Home</Link>
        <Link to='/sign-up'>Sign Up</Link>
        <Link to='/sign-in'>Sign In</Link>
    </header>)
}