import React from "react";
import {useForm} from "react-hook-form";
import "../authentication.css";
import {Link} from "react-router-dom";

const UserSignIn = {
    Email: undefined,
    Password: undefined,
}

async function userSignInPOST(){
    let response = await fetch("https://localhost:5001/Store/User/Login", {
        method : 'POST',
        headers: {
            'Content-Type': 'application/json; charset=utf-8',
            'Email':UserSignIn.Email,
            'Password':UserSignIn.Password}
    });
    if (response.ok) {
        let json = await response.json();
        console.log(json);
    } else {
        let json = await response.json();
        alert(json.errorMessage);
    }
}

export default function SignInForm() {

    const initSignIn = (formData) => {
        UserSignIn.Email = formData.email;
        UserSignIn.Password = formData.password;
    }

    const {
        formState: {errors, isValid},
        register,
        handleSubmit,
        reset
    } = useForm({
        mode: 'all'
    });

    const onSubmit = (data) => {
        const formData = {
            email: undefined,
            password: undefined,
        }
        for (let key in formData) {
            for (let dataKey in data) {
                if (key === dataKey) {
                    formData[key] = data[dataKey];
                }
            }
        }

        initSignIn(formData);
        userSignInPOST().then();

    }

    return (
        <div id="sign-in-overlay">
            <div className="authentication">
                <div className="authentication-container">
                    <div className="form-header">
                        <div className="a-back">
                            <small>
                                <Link to='/'>Back</Link>
                            </small>
                        </div>
                        <h1>Sign In</h1>
                    </div>
                    <div className="form-body">
                        <form onSubmit={handleSubmit(onSubmit)}>

                            <div className="form-group">
                                <label htmlFor="email-input">Email:</label>
                                <input id="email-input" className="form-control" type="email" autoComplete="off"
                                       placeholder="Enter your email"
                                       {...register('email', {
                                           required: {
                                               value: true,
                                               message: 'This field cannot be empty',
                                           },
                                           pattern: {
                                               value: /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
                                               message: 'Wrong email'
                                           }
                                       })}
                                />
                                {errors?.email && <small className="input-error">{errors?.email?.message}</small>}

                            </div>

                            <div className="form-group">
                                <label htmlFor="password-input">Password:</label>
                                <input id="password-input" className="form-control" type="password" autoComplete="off"
                                       placeholder="Enter your password"
                                       {...register('password', {
                                           required: {
                                               value: true,
                                               message: 'This field cannot be empty'
                                           },
                                           minLength: {
                                               value: 8,
                                               message: 'Password cannot be less than 8 characters'
                                           }
                                       })}
                                />
                                {errors?.password && <small className="input-error">{errors?.password?.message}</small>}


                            </div>
                            <div className="form-footer">
                                <button className="btn btn-primary" type="submit" disabled={!isValid}>
                                    Sign in
                                </button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    );
}


