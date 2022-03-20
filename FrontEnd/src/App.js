import React from "react";

import SignIn from "./components/authentication/log-in/sign-in";

export default class App extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="App">
                <SignIn/>
            </div>
        )
    }


}

