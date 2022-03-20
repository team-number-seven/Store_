import React from "react";
import {useForm} from "react-hook-form";

import "../authentication.css";
import CountryList from "../../services/country-list/country-list";

export default function SignUp(state) {
    const {
        formState: {errors, isValid},
        handleSubmit,
        register,
        reset,
        getValues,
    } = useForm({
            mode: 'all'
        }
    );

    const onSubmit = (data) => {
        console.log(data);
        console.log(state);
        reset();
    }


    return (
        <div className="authentication">
            <div className="authentication-container">
                <form onSubmit={handleSubmit(onSubmit)}>

                    <h1>Sign Up</h1>

                    <div className="form-group">
                        <label htmlFor="user-name">Username:</label>
                        <input id="user-name" className="form-control" type="text"
                               {...register('userName', {
                                   required: {
                                       value: true,
                                       message: 'This field cannot be empty',
                                   }
                               })}
                        />
                        {errors?.userName && <small className="input-error">{errors?.userName?.message}</small>}
                    </div>
                    <div className="form-group">
                        <label htmlFor="email">Email:</label>
                        <input id="email" className="form-control" type="text"
                               {...register('email', {
                                   required: {
                                       value: true,
                                       message: 'This field cannot be empty',
                                   },
                                   pattern: {
                                       value: /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
                                       message: 'Invalid email'
                                   }
                               })}
                        />
                        {errors?.email && <small className="input-error">{errors?.email?.message}</small>}
                    </div>
                    <div className="form-group">
                        <label htmlFor="password">Password:</label>
                        <input id="password" className="form-control" type="password"
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
                    <div className="form-group">
                        <label htmlFor="password-repeat">Repeat password:</label>
                        <input id="password-repeat" className="form-control" type="password"
                               {...register('passwordRepeat', {
                                   required: {
                                       value: true,
                                       message: 'This field cannot be empty'
                                   },
                                   minLength: {
                                       value: 6,
                                       message: 'Password cannot be less than 6 characters'
                                   },
                                   validate: {
                                       isMatch: (value) => {
                                           return value === getValues('password') || 'Passwords do not match'
                                       }
                                   }


                               })}
                        />
                        {errors?.passwordRepeat &&
                            <small className="input-error">{errors?.passwordRepeat?.message}</small>}
                    </div>

                    <div className="form-group">
                        <label htmlFor="phone-number">Your phone number:</label>
                        <input id="phone-number" className="form-control" type="text"
                               {...register('phoneNumber', {
                                   required: {
                                       value: true,
                                       message: 'This field cannot be empty'
                                   },
                                   pattern: {
                                       value: /^[+]?[(]?[0-9]{3}[)]?[-\s\]?[0-9]{3}[-\s\]?[0-9]{4,6}$/im,
                                       message: 'Invalid phone number',
                                   }
                               })}
                        />
                        {errors?.phoneNumber && <small className="input-error">{errors?.phoneNumber?.message}</small>}
                    </div>
                    <div className="form-group">
                        <label htmlFor="country">Your country:</label>
                        <select id="country-list" className="form-control selectpicker" data-live-search="true" data-width="fit">
                            <CountryList/>
                        </select>
                    </div>

                    <div className="form-footer">
                        <button className="btn btn-primary" type="submit" disabled={!isValid}>
                            Sign Up
                        </button>
                    </div>

                </form>
            </div>
        </div>
    )
}