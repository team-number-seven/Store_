import {Link} from "react-router-dom";

export const Header = ({auth}) => {
    return (<header>
        <Link to='/'>Home</Link>
        {!auth ? <Link to='/sign-up'>Sign Up</Link> : <></>}
        {!auth ? <Link to='/sign-in'>Sign In</Link> : <></>}
        {auth ? <Link to='/profile'>Profile</Link> : <></>}

    </header>)
}