namespace RestWithASPNet10.Utils
{
    public class NumberHelper
    {
        public static decimal ConvertToDecimal(string stringNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(
                stringNumber, System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.CurrentInfo,
                out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        public static bool IsNumeric(string stringNumber)
        {
            decimal decimalValue;
            bool isNumber = decimal.TryParse(
                stringNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.CurrentInfo,
                out decimalValue);

            return isNumber;
        }
    }
}
