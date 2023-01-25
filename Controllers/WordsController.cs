using Microsoft.AspNetCore.Mvc;
using hangmanV1.Services;
using hangmanV1.DataAccessLayer;
using hangmanV1.Model.Entity;
using FluentValidation.Results;
using FluentValidation.AspNetCore;
using hangmanV1.Model.ResponseModel;
using hangmanV1.Model.RequestModel;
using hangmanV1.Model;
using Azure.Core;

namespace hangmanV1.Controllers
    {
    [Route("api/Game")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        GuessValidator validationRules = new GuessValidator();

        //private readonly WordDbContext _context;
        WordService _controller;

        public WordsController(WordService controller) { _controller = controller; }


        [HttpPost("takeGuessAndCheck")]
        public async Task<ActionResult<CheckAnswersResponseModel>> takeGuessAndCheck([FromBody] EnterGuessRequestModel request)
        {

            ValidationResult result = await validationRules.ValidateAsync(request);
            if (!result.IsValid)
                {
                result.AddToModelState(this.ModelState);
                return BadRequest(ModelState);
                }
            var guesstaken = _controller.taketheguess(request.letter);
            return await _controller.checkTheGuessAnswers(request.gameid, request.letter);
        }

        [HttpGet("start")]
        public startResponseModel StartGame()
        {
            Console.WriteLine("");
            Console.WriteLine("WELCOME TO HANGMAN");
            return _controller.getRandomWord();
        }

        [HttpPost("DeleteGame")]
        public ActionResult DeleteGame(int id)
        {
            Game game = unitOfWork.GameRepository.GetByID(id);
            unitOfWork.GameRepository.Delete(id);
            unitOfWork.Save();
            return Ok(true);
        }

        [HttpPost("DeleteUser")]
        public ActionResult DeleteUser(int id)
        {
            Users user = unitOfWork.UserRepository.GetByID(id);
            unitOfWork.UserRepository.Delete(id);
            unitOfWork.Save();
            return Ok(true);
        }


        [HttpPost("AddUser")]
        public ActionResult AddUser(string username, string password)
        {
            Users user = new Users
            {
                Username=username,
                Password=password
            };

            unitOfWork.UserRepository.Insert(user);
            unitOfWork.Save();
            return Ok(true);
        }

    }
}
