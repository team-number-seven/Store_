const CONFIG = require('../../../jsconfig.json');
export const SignUpPOST = async (user) => {

    return new Promise(async (resolve, reject) => {
        debugger;
        const response = await fetch(CONFIG["server"] + CONFIG.requests.POST["sign-up"], {
            mode: CONFIG["requestMode"],
            method: 'POST',
            headers: {
                'Content-Type': CONFIG["content-type-URL8"],
                'UserName': user.UserName,
                'Email': user.Email,
                'Password': user.Password,
                'CountryId': user.CountryId,
                'PhoneNumber': user.PhoneNumber,
                'Access-Control-Allow-Origin': CONFIG.server,
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