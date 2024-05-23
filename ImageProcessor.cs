using System.Drawing.Imaging;
using System.Text;

namespace MTSBankTestAssignment
{
    public static class ImageProcessor
    {
        private static string _outputPath = string.Empty;
        public static void ConvertImage(string filePath, string format)
        {
            format = CheckFormat(format);

            try
            {
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(filePath);
                _outputPath = Path.Combine(Path.GetDirectoryName(filePath), fileNameWithoutExtension + format);
                
                File.Move(filePath, _outputPath);
            }

            catch { throw new Exception("Ошибка файла"); }
        }

        public static StringBuilder GetBase64() => new(Convert.ToBase64String(File.ReadAllBytes(_outputPath)));
   
        private static string CheckFormat(string format)
        {
            if (!format.StartsWith(".")) { format = "." + format; }

            var encoder = ImageCodecInfo.GetImageEncoders().FirstOrDefault(c => c.FilenameExtension.Contains(format, StringComparison.OrdinalIgnoreCase))
                ?? throw new Exception("Такой формат не является форматом изображения");
            return format;
        }
    }
}
