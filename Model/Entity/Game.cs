using FluentValidation;
using hangmanV1.Model.ResponseModel;
using System.ComponentModel.DataAnnotations;

namespace hangmanV1.Model
{
    public class Game
    {
        public int ID { get; set; }
        public string previousGuess { get; set; }
        public string quesiton { get; set; }
        [Range(0, 5)]
        public int lifeCount { get; set; }
    }

    public class lifeCountValidation : AbstractValidator<CheckAnswersResponseModel>
        {
        public lifeCountValidation()
            {
            RuleFor(x => x.lifeCount).GreaterThanOrEqualTo(0);
            }

        }

    }
