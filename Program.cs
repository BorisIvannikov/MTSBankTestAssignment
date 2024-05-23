using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography.X509Certificates;
using MTSBankTestAssignment;

internal class Program
{
    private static async Task Main(string[] args)
    {
        await CompleteTestAssignment();
    }

    private static async Task CompleteTestAssignment()
    {
        var filePath = Console.ReadLine();
        var format = Console.ReadLine();   
        try
        {
            ImageProcessor.ConvertImage(filePath, format);
            var base64Image = ImageProcessor.GetBase64();
            (string, int) response = await HttpsProcessor.SendPostRequestAsync(base64Image);
            FileProcessor.SaveToFile(response.Item1, response.Item2);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
}
}