import {JWT_decoder} from "../../utilites/jwt-decoder/jwt-decoder";


export const SignInPOST = async (user) => {
    return new Promise(async (resolve, reject) => {
        const response = await fetch("https://localhost:5001/Store/User/SignIn", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json; charset=utf-8',
                'Email': user.Email,
                'Password': user.Password
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