
export const SignUpPOST = async (user) => {

    return new Promise(async (resolve, reject) => {
        debugger;
        const response = await fetch("https://localhost:5001/Store/User/SignUp", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=utf-8',
                'UserName': user.UserName,
                'Email': user.Email,
                'Password': user.Password,
                'CountryId': user.CountryId,
                'PhoneNumber': user.PhoneNumber
            }
        });
        if (response.ok) {
            resolve('successful registration');
        } else {
            let json = await response.json();
            reject(json.errorMessage);
        }
    })

}