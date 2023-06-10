using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Text;

namespace ReceiptReaderDemo
{
    public class ReceiptReader
    {
        readonly string subscriptionKey = " enter a subscription key (removed this as it has t0 be unique and is confidential)"; 
        readonly string endpoint = "enter a endpoint (removed this as it has to be unique and is confidential)"; 

        public async Task<string> Read(string pathToFile)
        {
            if (string.IsNullOrEmpty(subscriptionKey))
                throw new Exception("No subscription key has been entered.");

            if (string.IsNullOrEmpty(endpoint))
                throw new Exception("Enter a valid endpoint.");

            ComputerVisionClient client = Authenticate();

            return await ProcessFile(client, pathToFile);
        }

        private ComputerVisionClient Authenticate()
        {
            ComputerVisionClient client = new(new ApiKeyServiceClientCredentials(subscriptionKey))
            {
                Endpoint = endpoint
            };
            return client;
        }

        private async Task<string> ProcessFile(ComputerVisionClient client, string pathToFile)
        {
            FileStream stream = File.OpenRead(pathToFile);
            ReadInStreamHeaders textHeaders = await client.ReadInStreamAsync(stream);

            Thread.Sleep(2000);

            string operationLocation = textHeaders.OperationLocation;
            string operationId = operationLocation[^36..];

            ReadOperationResult results;

            do
            {
                results = await client.GetReadResultAsync(Guid.Parse(operationId));
            }
            while ((results.Status == OperationStatusCodes.Running || results.Status == OperationStatusCodes.NotStarted));

            IList<ReadResult> textUrlFileResults = results.AnalyzeResult.ReadResults;

            StringBuilder sb = new();
            foreach (ReadResult page in textUrlFileResults)
            {
                foreach (Line line in page.Lines)
                {
                    sb.AppendLine(line.Text);
                }
            }
            return string.Join(Environment.NewLine, sb);
        }
    }
}
