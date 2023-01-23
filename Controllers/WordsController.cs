using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using hangmanV1.Context;
using hangmanV1.Model;
using NuGet.Packaging.Signing;
using hangmanV1.Model.ResponseModel;
using hangmanV1.Services;
using hangmanV1.Model.RequestModel;
using hangmanV1.Model.ResponseModel;

namespace hangmanV1.Controllers
{
    [Route("api/Game")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        //private readonly WordDbContext _context;
        WordService _controller;

        public WordsController(WordService controller) { _controller = controller; }


        [HttpPost("takeGuessAndCheck")]
        public CheckAnswersResponseModel takeGuessAndCheck([FromBody] EnterGuessRequestModel enterguess)
            {
            var guesstaken = _controller.taketheguess(enterguess.letter);
           
                return _controller.checkTheGuessAnswers(enterguess.gameid, enterguess.letter);
            }

        [HttpGet("start")]
        public startResponseModel StartGame()
            {
            Console.WriteLine("");
            Console.WriteLine("WELCOME TO HANGMAN");
            return _controller.getRandomWord();
            }
       
        }
}
