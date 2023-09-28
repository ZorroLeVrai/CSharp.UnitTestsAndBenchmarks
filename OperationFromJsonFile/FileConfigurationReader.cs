using Newtonsoft.Json;

namespace OperationFromJsonFile
{
    public class FileConfigurationReader : IConfigurationReader
    {
        public string ConfigurationPath { get; }

        public FileConfigurationReader(string configurationPath)
        {
            ConfigurationPath = configurationPath;
        }

        public ComputationDto? Read()
        {
            if (!File.Exists(ConfigurationPath))
                throw new FileNotFoundException(ConfigurationPath);

            string jsonContent = File.ReadAllText(ConfigurationPath);
            return JsonConvert.DeserializeObject<ComputationDto>(jsonContent);
        }
    }
}
