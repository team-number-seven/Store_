import React from "react";
import './log-in.css';


export default class LogIn extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            email: '',
            password: '',
            emailDirty: false,
            passwordDirty: false,
            emailError: 'Email field cannot be empty',
            passwordError: 'Password field cannot be empty',
            formValid: false,
        }

    }


    checkFormForErrors() {
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

    blurHandler() {
        this.checkFormForErrors();
    }

    render() {
        return (
            <div id="log-in">
                <div id="log-in-container">
                    <form>
                        <h1>LOG IN</h1>

                        <div className="form-group">
                            <label htmlFor="email-input">Email:</label>
                            <input id="email-input" className="form-control" onChange={e => this.emailHandler(e)}
                                   value={this.state.email}
                                   onFocus={e => this.focusHandler(e)}
                                   onBlur={() => this.blurHandler()}
                                   name="email" type="text"
                                   placeholder="Enter your email"/>
                            {/*Email error message*/}
                            {(this.state.emailDirty && this.state.emailError) &&
                                <small className="input-error">{this.state.emailError}</small>}
                        </div>

                        <div className="form-group">
                            <label htmlFor="password-input">Password:</label>
                            <input id="password-input" className="form-control" onChange={e => this.passwordHandler(e)}
                                   value={this.state.password}
                                   onFocus={e => this.focusHandler(e)}
                                   onBlur={() => this.blurHandler()}
                                   name="password" type="password"
                                   placeholder="Enter your password"/>
                            {/*Password error message*/}
                            {(this.state.passwordDirty && this.state.passwordError) &&
                                <small className="input-error">{this.state.passwordError}</small>}
                        </div>

                        <div className="form-footer">
                            <button className="btn btn-primary" onClick={() => console.log('logged in')}
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


/*
const App = () =>
    {
        const [email, setEmail] = useState('');
        const [password, setPassword] = useState('');
        const [emailDirty, setEmailDirty] = useState(false);
        const [passwordDirty, setPasswordDirty] = useState(false);
        const [emailError, setEmailError] = useState('Email field cannot be empty');
        const [passwordError, setPasswordError] = useState('Password field cannot be empty');
        const [formValid, setFormValid] = useState(false);

        useEffect(() => {
            if (emailError || passwordError) {
                setFormValid(false);
            } else {
                setFormValid(true);
            }
        }, [emailError, passwordError])

        const emailHandler = (e) => {
            setEmail(e.target.value);
            const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
            if (!re.test(String(e.target.value).toLowerCase())) {
                setEmailError('Incorrect email');
            } else {
                setEmailError('');
            }
        }

        const passwordHandler = (e) => {
            setPassword(e.target.value);
            if (e.target.value.length < 4) {
                setPasswordError('Password cannot be less than 4 symbols');
                if (!e.target.value) {
                    setPasswordError('Password field cannot be empty');
                }
            } else {
                setPasswordError('');
            }
        }

        const blurHandler = (e) => {
            switch (e.target.name) {
                case 'email':
                    setEmailDirty(true);
                    break;
                case 'password':
                    setPasswordDirty(true);
                    break;
            }
        }


        return (
            <div className="App">
                <h1>Log in</h1>
                {(emailDirty && emailError) && <div style={{color: 'red'}}>{emailError} </div>}
                <input onChange={e => emailHandler(e)} value={email} onBlur={e => blurHandler(e)} name='email'
                       type="text"
                       placeholder="Enter your email"/>
                {(passwordDirty && passwordError) && <div style={{color: 'red'}}>{passwordError} </div>}
                <input onChange={e => passwordHandler(e)} value={password} onBlur={e => blurHandler(e)}
                       name='password'
                       type="password"
                       placeholder="Enter your password"/>
                <button disabled={!formValid} type="submit">Log in</button>
            </div>
        )
    }

export default App;*/
