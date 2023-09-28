namespace OperationFromJsonFile
{
    //DTO: Data Transfer Object
    public class ComputationDto
    {
        public double FirstOperand { get; set; }
        public double SecondOperand { get; set; }
        public string Operator { get; set; } = string.Empty;
    }
}