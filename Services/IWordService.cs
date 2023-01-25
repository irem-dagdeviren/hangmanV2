using hangmanV1.Model.RequestModel;
using hangmanV1.Model.ResponseModel;
using hangmanV1.Model.RequestModel;
using hangmanV1.Model.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace hangmanV1.Services
    {
    public interface IWordService
        {
        bool checkTheGuess(string word, string letter);
        IsGameOverResponseModel IsGameOver(int c);
        startResponseModel getRandomWord();
        Task<ActionResult<CheckAnswersResponseModel>> checkTheGuessAnswers(int id, string letter);
        EnterGuessRequestModel taketheguess(string letter);
        }
    }
