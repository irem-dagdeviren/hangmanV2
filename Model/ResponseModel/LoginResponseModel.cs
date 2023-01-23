namespace hangmanV1.Model.ResponseModel
    {
    public class LoginResponseModel
        {
        public int ID{ get; set; }
        public string UserName { get; set; }
        public string password { get; set; }
        public bool IsNewUser { get; set; }
        public string status { get; set; }
        }
    }
