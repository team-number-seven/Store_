import {JWT_decoder} from "../../utilites/jwt-decoder/jwt-decoder";
const CONFIG = require('../../../jsconfig.json');



export const SignInPOST = async (user) => {
    return new Promise(async (resolve, reject) => {
        const response = await fetch(CONFIG["server"]+CONFIG.requests.POST["sign-in"], {
            mode: CONFIG["requestMode"],
            method: 'POST',
            headers: {
                'Content-Type': CONFIG["content-type-URL8"],
                'Email': user.Email,
                'Password': user.Password,
                'Access-Control-Allow-Origin': CONFIG["server"],
            }
        });
        if (response.ok) {
            let json = await response.json();
            let jsonToken = JWT_decoder(json.accessToken.token);

            resolve({
                Id: jsonToken.Id,
                Role: jsonToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'],
                Country: jsonToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/country'],
                UserName: jsonToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'],
                Email: jsonToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'],
                AccessToken: json.accessToken,
                RefreshToken: json.refreshToken,
            })

        } else {
            let json = await response.json();
            reject(json.errorMessage);
        }
    })
}