namespace RestWithASPNet10.Service
{
    public class MathService
    {
        public decimal Sum(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber + secondNumber;
        }
        public decimal Sub(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber - secondNumber;
        }
        public decimal Div(decimal firstNumber, decimal secondNumber)
        {
            if (secondNumber == 0) throw new ArgumentException("Division by zero is not allowed");
            return firstNumber / secondNumber;
        }
        public decimal Mult(decimal firstNumber, decimal secondNumber)
        {
            return firstNumber * secondNumber;
        }
        public decimal Media(decimal firstNumber, decimal secondNumber)
        {
            return (firstNumber + secondNumber) / 2;
        }
        public decimal Sqrt(decimal number)
        {
            if (number < 0) throw new ArgumentException("Square root of negative number is not allowed");
            return (decimal)Math.Sqrt((double)number);
        }
    }
}
