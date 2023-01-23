using hangmanV1.Context;
using hangmanV1.Model.Entity;
using hangmanV1.Model.ResponseModel;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace hangmanV1.Services
    {
    public class LoginService
        {

        WordDbContext _dbContext;
        public LoginService(WordDbContext dbContext) { _dbContext = dbContext; }

        public LoginResponseModel SignIn(string username, string password)
            {
            try
                {
                Users user = _dbContext.Users.Where(x => x.Password == password && x.Username == username).SingleOrDefault();
                bool newUser;
                string status;
                if (user != null)
                    {

                    newUser = false;
                    status = "Login Successful";

                    return new LoginResponseModel
                        {
                        UserName = username,
                        password = password,
                        IsNewUser = newUser,
                        status = status
                        };

                    }
                else
                    {
                    newUser = true;
                    Console.WriteLine("please register");
                    status = "Registration Necessary";

                    return new LoginResponseModel
                        {
                        UserName = username,
                        password = password,
                        IsNewUser = newUser,
                        status = status
                        };

                    }
                }
            catch (Exception ex)
                {
                Console.WriteLine(ex.Message);
                return new LoginResponseModel
                    {
                    UserName = username,
                    password = password,
                    status = "Error Occured while Signing in"
                    };

                }
            }
        public LoginResponseModel Register(string username, string password)
            {
            try
                {
                Users user = _dbContext.Users.Where(x => x.Password == password && x.Username == username).SingleOrDefault();

                bool newUser;
                string status;
                if (user != null)
                    {
                    newUser = false;
                    status = "Please Sign In";
                    }
                else
                    {
                    newUser = true;
                    status = "Registration Succesful";
                    var Userdb = new Users
                        {
                        Username = username,
                        Password = password
                        };
                    _dbContext.Users.Add(Userdb);
                    _dbContext.SaveChanges();
                    }
                return new LoginResponseModel
                    {
                    UserName = username,
                    password = password,
                    IsNewUser = newUser,
                    status = status
                    };
                }
            catch (Exception ex)
                {
                Console.WriteLine(ex.Message);
                return new LoginResponseModel
                    {
                    UserName = username,
                    password = password,
                    status = "Error occured while registration"
                    };
                }
            }
        }
    }
            

    
