namespace OperationFromJsonFile
{
    public static class Operator
    {
        public const string PLUS = "+";
        public const string MINUS = "-";
        public const string MULTIPLY = "*";
        public const string DIVIDE = "/";
    }

    public class Computator
    {
        public IConfigurationReader ConfigurationReader { get; }

        public Computator(IConfigurationReader configReader) {
            ConfigurationReader = configReader;
        }

        public double Compute()
        {
            var computationDto = ConfigurationReader.Read();
            if (computationDto == null)
                throw new Exception("Unable to load configuration from file");

            var operationFunction = GetFunction(computationDto.Operator);
            return operationFunction(computationDto.FirstOperand, computationDto.SecondOperand);


            Func<double, double, double> GetFunction(string operatorSymbol) => operatorSymbol switch
            {
                Operator.PLUS => (a, b) => a + b,
                Operator.MINUS => (a, b) => a - b,
                Operator.MULTIPLY => (a, b) => a * b,
                Operator.DIVIDE => (a, b) => a / b,
                _ => throw new ArgumentOutOfRangeException(nameof(operatorSymbol), $"Not expected operator symbol {operatorSymbol}")
            };
        }
    }
}
