using deneme2.Model.RequestModel;
using deneme2.Model.ResponseModel;
using hangmanV1.Model.RequestModel;
using hangmanV1.Model.ResponseModel;

namespace hangmanV1.Services
    {
    public interface IWordService
        {
        bool checkTheGuess(string word, char letter);
        IsGameOverResponseModel IsGameOver(int c);
        startResponseModel getRandomWord();
        CheckAnswersResponseModel checkTheGuessAnswers(int id, char letter);
        EnterGuessRequestModel taketheguess(char letter);
        }
    }
