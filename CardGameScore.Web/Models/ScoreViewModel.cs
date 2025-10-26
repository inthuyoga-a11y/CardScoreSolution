using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CardGameScore.Web.Models
{
    public class ScoreViewModel
    {
        // Data annotation for the user interface input field
        [DisplayName("Enter cards (comma-separated):")]
        [Required(ErrorMessage = "Please enter a list of cards.")]
        public  string CardsInput { get; set; }


        [ValidateNever]
        public int? FinalScore { get; set; } = null;
        [ValidateNever]
        public string? ErrorMessage { get; set; }

        // Flag to control visibility of the result panel in the View
        public bool HasResult => FinalScore !=null || !string.IsNullOrEmpty(ErrorMessage);
    }
}
