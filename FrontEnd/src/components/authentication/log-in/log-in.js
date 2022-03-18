import React from "react";
import './log-in.css';


export default class LogIn extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            emailValid: false,
            emailDirty: false,
            emailError: 'Email field cannot be empty',

            password: '',
            passwordValid: false,
            passwordDirty: false,
            passwordError: 'Password field cannot be empty',

            formValid: false,
        }

    }

    validateEmail(email) {
        const reg = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
        if (!reg.test(String(email).toLowerCase())) {
            this.setState({emailError: 'Incorrect email'});
            return false;
        } else {
            this.setState({emailError: ''});
            return true;
        }
    }

    emailHandler(e) {
        e.preventDefault();
        this.setState({
            email: e.target.value,
            emailValid: this.validateEmail(e.target.value)
        })
        this.validateForm();
    }

    validatePassword(password) {
        if (password.length < 3) {
            this.setState({passwordError: 'Password cannot be less than 4 symbols'});
            if (!password) {
                this.setState({passwordError: 'Password field cannot be empty'});
            }
            return false;
        } else {
            this.setState({passwordError: ''});
            return true;
        }
    }

    passwordHandler(e) {
        e.preventDefault();
        this.setState({
            password: e.target.value,
            passwordValid: this.validatePassword(e.target.value)
        })
        this.validateForm();
    }

    focusHandler(e) {
        switch (e.target.name) {
            case 'email':
                this.setState({emailDirty: true})
                break;
            case 'password':
                this.setState({passwordDirty: true})
                break;
        }
    }

    validateForm() {
        if (!this.state.passwordValid || !this.state.emailValid) {
            this.setState({
                formValid: false,
            })
        } else {
            this.setState({
                formValid: true,
            })
        }
    }


    /*
        checkFormForErrors() {
            debugger;
            if (this.state.emailError !== '' || this.state.passwordError !== '') {
                this.setState({
                    formValid: false,
                })
            } else {
                this.setState({
                    formValid: true,
                })
            }
        }

        emailHandler(e) {
            this.setState({email: e.target.value});
            const reg = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
            if (!reg.test(String(e.target.value).toLowerCase())) {
                this.setState({emailError: 'Incorrect email'});
            } else {
                this.setState({emailError: ''});
            }
        }


        passwordHandler(e) {
            this.setState({password: e.target.value});
            if (e.target.value.length < 4) {
                this.setState({passwordError: 'Password cannot be less than 4 symbols'});
                if (!e.target.value) {
                    this.setState({passwordError: 'Password field cannot be empty'});
                }
            } else {
                this.setState({passwordError: ''});
            }
        }

        focusHandler(e) {
            switch (e.target.name) {
                case 'email':
                    this.setState({emailDirty: true})
                    break;
                case 'password':
                    this.setState({passwordDirty: true})
                    break;
            }
        }
    */


    render() {
        return (
            <div id="log-in">
                <div id="log-in-container">
                    <form>
                        <h1>LOG IN</h1>

                        <div className="form-group">
                            <label htmlFor="email-input">Email:</label>
                            <input id="email-input" className="form-control" onChange={e => {
                                this.emailHandler(e);
                            }}
                                   value={this.state.email}
                                   onFocus={e => this.focusHandler(e)}
                                   name="email" type="text"
                                   placeholder="Enter your email"/>
                            {/*Email error message*/}
                            {(this.state.emailDirty && this.state.emailError) &&
                                <small className="input-error">{this.state.emailError}</small>}
                        </div>

                        <div className="form-group">
                            <label htmlFor="password-input">Password:</label>
                            <input id="password-input" className="form-control" onChange={e => {
                                this.passwordHandler(e);
                            }}
                                   value={this.state.password}
                                   onFocus={e => this.focusHandler(e)}
                                   name="password" type=""
                                   placeholder="Enter your password"/>
                            {/*Password error message*/}
                            {(this.state.passwordDirty && this.state.passwordError) &&
                                <small className="input-error">{this.state.passwordError}</small>}
                        </div>

                        <div className="form-footer">
                            <button className="btn btn-primary"
                                    onClick={(e) => {
                                        e.preventDefault();
                                        console.log(`logged in: email:${this.state.email} password:${this.state.password}`)
                                    }}
                                    disabled={!this.state.formValid} type="submit">Log in
                            </button>

                            <a href="#" className="badge">Sign Up</a>
                        </div>
                    </form>
                </div>
            </div>
        )
    }
}

