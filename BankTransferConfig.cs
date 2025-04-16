using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace modul8_103022300142
{
    internal class BankTransferConfig
    {
        public Config config { get; set; }
        public string filePath = @"bank_transfer_config.json";
        public BankTransferConfig() {
            try
            {
                ReadConfigFile();
            }
            catch {
                config = new Config();
                config.lang = "en";
                config.transfer = new Transfer(25000000, 6500, 15000);
                config.methods = new List<string>();
                config.methods.Add("RTO (real-time)");
                config.methods.Add("SKN");
                config.methods.Add("RTGS");
                config.methods.Add("BI Fast");
                config.confirmation = new Confirmation("yes", "ya");


                WriteNewConfigFile();
            }
        }

        private void ReadConfigFile()
        {
            string configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<Config>(configJsonData);
            
        }
        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }

    }
}
