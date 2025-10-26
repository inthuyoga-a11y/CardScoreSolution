using CardGameScore.BL;
using CardGameScore.BL.Exceptions;
using CardGameScore.BL.StaticData;
using CardGameScore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CardGameScore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CardScoreCalculator _calculator = new CardScoreCalculator();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new ScoreViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ScoreViewModel model)
        {
            model.FinalScore = null;
            model.ErrorMessage = null;

            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            try
            {
                if (string.IsNullOrWhiteSpace(model.CardsInput) || model.CardsInput.Length < 2)
                {
                    // have to length 2
                    throw new CardParseException(CardExceptionMessages.CardNotRecognized);
                }
               
                //if Separator not common error 
                if (model.CardsInput.Length > 2 && !model.CardsInput.Contains(','))
                {
                    model.ErrorMessage = CardExceptionMessages.WrongSeparator;

                }
                else
                {
                    var inputStringToList = model.CardsInput
                                                .Split(',')
                                                .Select(x => x.Trim())
                                                .Where(s => !string.IsNullOrEmpty(s))
                                                .ToList();
                    if (inputStringToList.Count > 0)
                        model.FinalScore = _calculator.CalculateHandScore(inputStringToList);
                    else
                        model.ErrorMessage = CardExceptionMessages.InvalidData;
                }
            }
            catch (InvalidCardHandException ex)
            {
                _logger.LogWarning("Invalid card hand: {Message}", ex.Message);
                model.ErrorMessage = ex.Message;
            }
            catch (CardParseException ex)
            {
                _logger.LogWarning("Card parsing error: {Message}", ex.Message);
                model.ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error calculating card score");
                model.ErrorMessage = $"An unexpected error occurred: {ex.Message}";
            }


            return View("Index", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
