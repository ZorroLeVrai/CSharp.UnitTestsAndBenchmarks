// See https://aka.ms/new-console-template for more information

using OperationFromJsonFile;

const string configurationPath = "computation.json";

var computator = new Computator(new FileConfigurationReader(configurationPath));

var computationResult = computator.Compute();
Console.WriteLine($"computation result = {computationResult}");
