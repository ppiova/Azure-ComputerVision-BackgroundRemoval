using System.Drawing.Imaging;
using System.Net.Http.Headers;

namespace AzureComputerVisionBackground
{
    class Program
    {
        private static readonly string SubscriptionKey = Environment.GetEnvironmentVariable("COMPUTER_VISION_SUBSCRIPTION_KEY");
        private static readonly string Endpoint = Environment.GetEnvironmentVariable("COMPUTER_VISION_ENDPOINT");
        //set the image directory for input and output
        private static readonly string InputFolder = @"E:/GitDemosCognitiveServices/ComputerVision4-Preview/Images/";
        private static readonly string OutputFolder = @"E:/GitDemosCognitiveServices/ComputerVision4-Preview/OutputImages/";
        private static readonly string ApiVersion = "2023-02-01-preview";

        static async Task Main()
        {
            Console.WriteLine("Please type an option:");
            Console.WriteLine("1 - Remove Background");
            Console.WriteLine("2 - Foreground Matting");
            Console.Write("Option: ");
            int option = int.Parse(Console.ReadLine());

            var imageFiles = Directory.GetFiles(InputFolder).Where(IsValidImage).ToList();

            switch (option)
            {
                case 1:
                    foreach (string inputFile in imageFiles)
                    {
                        string outputFile = Path.Combine(OutputFolder, $"{Path.GetFileNameWithoutExtension(inputFile)}_output.png");
                        await ProcessImageAsync(inputFile, outputFile, "backgroundRemoval");
                    }
                    break;
                case 2:
                    foreach (string inputFile in imageFiles)
                    {
                        string outputFile = Path.Combine(OutputFolder, $"{Path.GetFileNameWithoutExtension(inputFile)}_output.png");
                        await ProcessImageAsync(inputFile, outputFile, "foregroundMatting");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

            Console.WriteLine("Completed process. Press ENTER to exit...");
            Console.ReadLine();
        }

        static async Task ProcessImageAsync(string inputImagePath, string outputImagePath, string mode)
        {
            using var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SubscriptionKey);

            string requestUri = $"{Endpoint}/computervision/imageanalysis:segment?api-version={ApiVersion}&mode={mode}";

            using var content = new ByteArrayContent(await File.ReadAllBytesAsync(inputImagePath));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            var response = await httpClient.PostAsync(requestUri, content);

            if (response.IsSuccessStatusCode)
            {
                var outputImage = await response.Content.ReadAsByteArrayAsync();
                await File.WriteAllBytesAsync(outputImagePath, outputImage);
                Console.WriteLine($"The {mode} of the image has been successfully.");
            }
            else
            {
                Console.WriteLine($"Error removing background: {response.ReasonPhrase}");
            }
        }

        static bool IsValidImage(string filePath)
        {
            try
            {
                using var image = System.Drawing.Image.FromFile(filePath);
                return image.RawFormat.Equals(ImageFormat.Jpeg) || image.RawFormat.Equals(ImageFormat.Png);
            }
            catch
            {
                return false;
            }
        }
    }
}