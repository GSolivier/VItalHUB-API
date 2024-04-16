using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace WebAPI.Utils.OCR
{
    public class OcrService
    {
        private readonly string _subscriptionKey = "26bf8e8b63204a26858d03b610a545ae";

        private readonly string _endPoint = "https://cvvitalhubg07.cognitiveservices.azure.com/";

        public async Task<string> RecognizeTextAsync(Stream imageStream)
        {
            try
            {
                var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(_subscriptionKey))
                {
                    Endpoint = _endPoint
                };

                var ocrResult = await client.RecognizePrintedTextInStreamAsync(true, imageStream);

                return ProcessRecognitionResult(ocrResult);
            }
            catch (Exception ex) 
            {
                return ex.Message;
            }
        }

        public static string ProcessRecognitionResult(OcrResult result)
        {
            string recognizedText = "";

            foreach (var region in result.Regions)
            {
                foreach (var line in region.Lines)
                {
                    foreach (var word in line.Words)
                    {
                        recognizedText += word.Text + " ";
                    }

                    recognizedText += "\n";       
              }
            }

            return recognizedText;
        }
    }
}
