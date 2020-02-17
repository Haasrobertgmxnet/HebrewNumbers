using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(HebrewNumbers.UWP.FileStorage))]
namespace HebrewNumbers.UWP
{
    public class FileStorage : IFileStorage
    {
        public async Task<string> ReadAsStringAsync(string filename)
        {
            var path = AppContext.BaseDirectory + filename;

            if (File.Exists(path))
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    return await streamReader.ReadToEndAsync();
                }
            }
            return string.Empty;
        }

        public string ReadAsString(string filename)
        {
            var path = AppContext.BaseDirectory + filename;

            if (File.Exists(path))
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    return streamReader.ReadToEnd();
                }
            }
            return string.Empty;
        }
    }
}


