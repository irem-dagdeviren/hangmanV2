using hangmanV1.Model.RequestModel;
using hangmanV1.Model.ResponseModel;
using hangmanV1.Services;
using Microsoft.AspNetCore.Mvc;

namespace hangmanV1.Controllers
    {

    [Route("api/LoginPage")]
    [ApiController]
    public class LoginController : ControllerBase
        {
        
        LoginService _controller;

        public LoginController(LoginService controller) {  _controller = controller; }


        [HttpPost("SignIn")]
        public LoginResponseModel SignIn([FromBody] LoginRequestModel loginRequestModel)
            {
                {

                var Login = _controller.SignIn(loginRequestModel.username, loginRequestModel.password);
                if(!Login.IsNewUser) {
                    Console.WriteLine( "Succesfully Signed In");

                    }
                else
                    {
                    Console.WriteLine("please register");
                    }

                return Login;

                }

            }
        [HttpPost("Register")]
        public LoginResponseModel Register([FromBody] LoginRequestModel loginRequestModel)
            {
                {
                var Login = _controller.Register(loginRequestModel.username, loginRequestModel.password);

                if (Login.IsNewUser)
                    {
                    Login.status = "Succesfully Registered";

                    }
                else
                    {
                    Console.WriteLine("yau have already registered please sign in");

                    }
            return Login;

                }

            }
        }
    }