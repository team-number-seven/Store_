import React from "react";
import {useForm} from "react-hook-form";
import {Link} from "react-router-dom";

import "../authentication.css";
import CountryList from "../../services/country-list/country-list";

const UserSignUp = {
    UserName: undefined,
    Email: undefined,
    Password: undefined,
    CountryId: undefined,
    PhoneNumber: undefined,
}

async function userSignUpPost(){
    let response = await fetch("https://localhost:5001/Store/User/Create", {
        method : 'POST',
        headers: {
            'Content-Type': 'application/json; charset=utf-8',
            'UserName':UserSignUp.UserName,
            'Email':UserSignUp.Email,
            'Password':UserSignUp.Password,
            'CountryId': UserSignUp.CountryId,
            'PhoneNumber': UserSignUp.PhoneNumber
        }
    });
    if (response.ok) {
        let json = await response.json();
        console.log(json);
    } else {
        console.log(response);
        alert("Ошибка HTTP: " + response.status);
    }
}

export default function SignUpForm(props) {

    const PostUserSignUp = (formData) => {

        UserSignUp.UserName = formData.userName;
        UserSignUp.Email = formData.email;
        UserSignUp.Password = formData.password;
        UserSignUp.PhoneNumber = formData.phoneNumber;

        let searchTerm = formData.country;
        UserSignUp.CountryId = props.Countries.find(country => country.Name === searchTerm).Id;

        console.log(UserSignUp);
        userSignUpPost().then();
    }


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
        const formData = {
            userName: undefined,
            email: undefined,
            password: undefined,
            phoneNumber: undefined,
            country: undefined,
        }
        for (let key in formData) {
            for (let dataKey in data) {
                if (key === dataKey) {
                    formData[key] = data[dataKey];
                }
            }
        }

        PostUserSignUp(formData);
    }


    return (
        <div id="sign-up-overlay">
            <div className="authentication">
                <div className="authentication-container">
                    <div className="form-header">
                        <div className="a-back">
                            <small>
                                <Link to='/'>Back</Link>
                            </small>
                        </div>
                        <h1>Sign Up</h1>
                    </div>
                    <div className="form-body">
                        <form onSubmit={handleSubmit(onSubmit)}>
                            <div className="form-group">
                                <label htmlFor="user-name">Username:</label>
                                <input id="user-name" className="form-control" type="text" autoComplete="off"
                                       {...register('userName', {
                                           required: {
                                               value: true,
                                               message: 'This field cannot be empty',
                                           },
                                           pattern: {
                                               value: /^[a-zA-Z0-9]+$/,
                                               message: 'Invalid username',
                                           }
                                       })}
                                />
                                {errors?.userName && <small className="input-error">{errors?.userName?.message}</small>}
                            </div>
                            <div className="form-group">
                                <label htmlFor="email">Email:</label>
                                <input id="email" className="form-control" type="email" autoComplete="off"
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
                                <input id="password" className="form-control" type="password" autoComplete="off"
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
                            <div className="form-group">
                                <label htmlFor="password-repeat">Repeat password:</label>
                                <input id="password-repeat" className="form-control" type="password" autoComplete="off"
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
                                <input id="phone-number" className="form-control" type="text" autoComplete="off"
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
                                {errors?.phoneNumber &&
                                    <small className="input-error">{errors?.phoneNumber?.message}</small>}
                            </div>
                            <div className="form-group">
                                <label htmlFor="country">Your country:</label>
                                <select id="country-list" className="form-control selectpicker" data-live-search="true"
                                        data-width="fit" {...register('country')}>
                                    <CountryList Countries={props.Countries}/>
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
            </div>
        </div>
    )
}