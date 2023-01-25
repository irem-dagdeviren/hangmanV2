using FluentValidation;
using hangmanV1.Model.RequestModel;
using System.ComponentModel.DataAnnotations;

namespace hangmanV1.Model.ResponseModel
    {
    public class CheckAnswersResponseModel
        {
        [Range(0, 5)]
        [Required]
        public int lifeCount { get; set; }
        public string guess { get; set; }
        public string status { get; set; }


        }
    }
