using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTSBankTestAssignment
{
    internal class FileProcessor
    {
        private const string _filePath = "response.txt"; // допустим в папку с программой
        public static void SaveToFile(string responseBody, int statusCode)
        {
            using var writer = new StreamWriter(_filePath);
            writer.WriteLine($"HTTP Status Code: {statusCode}");
            writer.WriteLine(responseBody);
        }
    }
}
