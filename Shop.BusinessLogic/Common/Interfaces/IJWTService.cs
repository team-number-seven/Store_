using Store.DAL.Entities;

namespace Store.BusinessLogic.Common.Interfaces
{
    public interface IJWTService
    {
        string GenerateJwtToken(User user);
    }
}
