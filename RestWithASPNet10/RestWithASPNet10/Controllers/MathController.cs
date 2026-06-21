using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNet10.Service;
using RestWithASPNet10.Utils;

namespace RestWithASPNet10.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        private readonly MathService _mathService;
        public MathController(MathService mathService) {
            _mathService = mathService;
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
            {
                var sum = _mathService.Sum(NumberHelper.ConvertToDecimal(firstNumber), NumberHelper.ConvertToDecimal(secondNumber));
                return Ok(sum);
            }
            return BadRequest("Invalid input!");
        }

        [HttpGet("sub/{firstNumber}/{secondNumber}")]
        public IActionResult Sub(string firstNumber, string secondNumber)
        {
            if(NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
            {
                var sub = _mathService.Sub(NumberHelper.ConvertToDecimal(firstNumber), NumberHelper.ConvertToDecimal(secondNumber));
                return Ok(sub);
            }
            return BadRequest("Invalid input!"); 
        }

        [HttpGet("div/{firstNumber}/{secondNumber}")]
        public IActionResult Div(string firstNumber, string secondNumber)
        {
            if(NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
            {
                if(NumberHelper.ConvertToDecimal(secondNumber) == 0)
                {
                    return BadRequest("Number can´t be divided by zero!");
                }
                var div = _mathService.Div(NumberHelper.ConvertToDecimal(firstNumber), NumberHelper.ConvertToDecimal(secondNumber));
                return Ok(div);
            }
            return BadRequest("Invalid input");
        }
        [HttpGet("mult/{firstNumber}/{secondNumber}")]
        public IActionResult Mult(string firstNumber, string secondNumber)
        {
            if(NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
            {
                var mult = _mathService.Mult(NumberHelper.ConvertToDecimal(firstNumber), NumberHelper.ConvertToDecimal(secondNumber));
                return Ok(mult);
            }
            return BadRequest("Invalid input!");
        }
        [HttpGet("media/{firstNumber}/{secondNumber}")]
        public IActionResult Media(string firstNumber, string secondNumber)
        {
            if(NumberHelper.IsNumeric(firstNumber) && NumberHelper.IsNumeric(secondNumber))
            {
                var media = _mathService.Media(NumberHelper.ConvertToDecimal(firstNumber), NumberHelper.ConvertToDecimal(secondNumber));
                return Ok(media);
            }
            return BadRequest("Invalid input!");
        }
        [HttpGet("raiz/{number}")]
        public IActionResult Raiz(string number)
        {
            if (NumberHelper.IsNumeric(number))
            {
                var raiz = _mathService.Sqrt(NumberHelper.ConvertToDecimal(number));
                return Ok(raiz);
            }
            return BadRequest("Invalid input!");
        }
    
    }
}
