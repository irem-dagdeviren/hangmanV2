using hangmanV1.Context;
using hangmanV1.Model;
using hangmanV1.Model.RequestModel;
using hangmanV1.Model.ResponseModel;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace hangmanV1.Services
{
    public class WordService
    {

        WordDbContext _dbContext;
        public WordService(WordDbContext dbContext) { _dbContext = dbContext; }

        public bool checkTheGuess(string word, char letter) { return word.Contains(letter); }
        public IsGameOverResponseModel IsGameOver(int count)
        {
            bool b = count == 0;
            if (b)
            {
                var response = new IsGameOverResponseModel
                {
                    GameOver = true
                };
                return response;
            }
            else
            {
                var response = new IsGameOverResponseModel
                {
                    GameOver = false
                };
                return response;
            }
        }
        public startResponseModel getRandomWord()
        {

            List<string> words = new List<string>();
            int count = 5;
            foreach (var item in _dbContext.Words)
            {
                Console.WriteLine($"{item.ID} {item.Word}");
                words.Add(item.Word);
            };
            Random random = new Random();
            int index = random.Next(words.Count);
            string random_word = words[index];


            string guess = "";
            int wordlen = random_word.Length;

            for (int i = 0; i < wordlen; i++)
            {
                if (random_word[i] == ' ')
                    guess += " ";
                else
                    guess += "_";

            }
            Console.WriteLine(guess);
            Game game = new Game
            {
                previousGuess = guess,
                quesiton = random_word,
                lifeCount = count
            };
            _dbContext.Games.Add(game);
            _dbContext.SaveChanges();

            var response = new startResponseModel
            {
                gameID = game.ID,
                emptyQuestion = guess,
                letterCount = wordlen,
                lifeCount = count
            };
            return response;
        }

        public EnterGuessRequestModel taketheguess(char letter)
        {

            Console.WriteLine("enter your guess");
            //char letter = Convert.ToChar(Console.ReadLine());
            var letterdb = new Guesses
            {
                letter = letter
            };
            _dbContext.Guesses.Add(letterdb);
            _dbContext.SaveChanges();

            var enterGuessResponseModel = new EnterGuessRequestModel
            {
                letter = letter
            };
            return enterGuessResponseModel;
        }

        public CheckAnswersResponseModel checkTheGuessAnswers(int GameID, char letter)
        {

            Game? game = _dbContext.Games.FirstOrDefault(x => x.ID == GameID);


            string random_word = game.quesiton.ToString();
            string guess = game.previousGuess.ToString();
            int count = game.lifeCount;

            if (checkTheGuess(random_word, letter))
            {
                Console.WriteLine("Correct");
                for (int i = 0; i < random_word.Length; i++)
                {
                    if (random_word[i] == letter)
                    {
                        guess = guess.Substring(0, i) + letter + guess.Substring(i + 1);

                    }
                }

            }
            else
            {
                Console.WriteLine("Wrong");
                count--;
                game.lifeCount = count;
                _dbContext.SaveChanges();
                if (IsGameOver(count).GameOver)
                {
                    Console.WriteLine("Game Over");
                    Console.WriteLine("the word was " + random_word);
                }
                else
                {
                    Console.WriteLine("You have " + count + " guesses left");
                }
            }
            Console.WriteLine(guess);

            game.previousGuess = guess;
            _dbContext.SaveChanges();

            var response = new CheckAnswersResponseModel
            {
                lifeCount = count,
                guess = guess
            };
            return response;

        }

    }

}
