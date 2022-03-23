import React from "react";
import {useForm} from "react-hook-form";
import "../authentication.css";
import {Link} from "react-router-dom";

const UserSignIn = {
    Email: undefined,
    Password: undefined,
}

export default function SignInForm() {

    const PostUserSignIn = (formData) => {
        UserSignIn.Email = formData.email;
        UserSignIn.Password = formData.password;

        console.log(UserSignIn);
        //отправить UserSignIn

        reset();
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

        PostUserSignIn(formData);

    }

    return (
        <div className="authentication">
            <div className="authentication-container">
                <form onSubmit={handleSubmit(onSubmit)}>
                    <small>
                        <Link to='/'>Back</Link>
                    </small>
                    <h1>SIGN IN</h1>

                    <div className="form-group">
                        <label htmlFor="email-input">Email:</label>
                        <input id="email-input" className="form-control" type="email"
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
                        <input id="password-input" className="form-control" type="password"
                               placeholder="Enter your password"
                               {...register('password', {
                                   required: {
                                       value: true,
                                       message: 'This field cannot be empty'
                                   },
                                   minLength: {
                                       value: 6,
                                       message: 'Password cannot be less than 6 characters'
                                   }
                               })}
                        />
                        {errors?.password && <small className="input-error">{errors?.password?.message}</small>}


                    </div>

                    <div className="form-footer">
                        <button className="btn btn-primary" type="submit" disabled={!isValid}>
                            Log in
                        </button>
                    </div>

                </form>
            </div>
        </div>
    );
}


