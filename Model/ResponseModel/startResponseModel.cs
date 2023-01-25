using System.Net.Http.Headers;

namespace hangmanV1.Model.ResponseModel
{
    public class startResponseModel
    {
        public int gameID { get; set; }
        public int letterCount { get; set; }
        public string emptyQuestion { get; set; }
        public int lifeCount { get; set; }

    }
}
