using hangmanV1.Model.ResponseModel;

namespace hangmanV1.Services
    {
    public interface ILoginService
        {
        LoginResponseModel SignIn(string username, string password);
        LoginResponseModel Register (string username, string password);
        }
    }
