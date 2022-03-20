import React from "react";

import SignIn from "./components/authentication/sign-in/sign-in";
import SignUp from "./components/authentication/sign-up/sign-up";

export default class App extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="App">
                {/*<SignIn/>*/}
                <SignUp/>
            </div>
        )
    }


}

