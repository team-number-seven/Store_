import React from "react";

import LogIn from "./components/authentication/log-in/log-in";

export default class App extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div className="App">
                <LogIn/>
            </div>
        )
    }


}

