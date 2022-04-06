export const InitUserWithResolve = (resolve, user) => {
    user.Id = resolve.Id;
    user.Role = resolve.Role;
    user.Country = resolve.Country;
    user.UserName = resolve.UserName;
    user.Email = resolve.Email;
    user.AccessToken = resolve.AccessToken;
    user.RefreshToken = resolve.RefreshToken;
}