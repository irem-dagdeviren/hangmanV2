using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using deneme2.Context;
using deneme2.Model;
using NuGet.Packaging.Signing;
using deneme2.Model.ResponseModel;
using deneme2.Services;
using deneme2.Model.RequestModel;
using deneme2.Model.ResponseModel;

namespace deneme2.Controllers
{
    [Route("api/Game")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        //private readonly WordDbContext _context;
        wordService _controller;

        public WordsController(wordService controller) { _controller = controller; }


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
