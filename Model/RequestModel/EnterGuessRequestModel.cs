using FluentValidation;
using hangmanV1.DataAccessLayer;

namespace hangmanV1.Model.RequestModel
    {

    public class EnterGuessRequestModel
    {
        public string letter { get; set; }

        public int gameid { get; set; }
       
        }
    public class GuessValidator: AbstractValidator<EnterGuessRequestModel>
        {
        public GuessValidator()
            {
            RuleFor(x => x.letter).MinimumLength(1).MaximumLength(1).NotNull().NotEmpty();   //returns is valid or errors
            RuleFor(x => x.gameid)
            .Must(BeAUniqueID)
            .WithMessage("NOT VALID GAME ID");

            }

        private bool BeAUniqueID(int arg)
            {
            UnitOfWork unitOfWork = new UnitOfWork();
             if(unitOfWork.GameRepository.GetByID(arg) != null)
                {
                return true;
                }
            else
                {
                return false;
                }
              
            }
        }
    }