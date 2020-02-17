using Android.Content;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(HebrewNumbers.Droid.FileStorage))]
namespace HebrewNumbers.Droid
{
    public class FileStorage : IFileStorage
    {
        private readonly Context _context = Android.App.Application.Context;
        public async Task<string> ReadAsStringAsync(string filename)
        {
            using (var asset = _context.Assets.Open(filename))
            using (var streamReader = new StreamReader(asset))
            {
                return await streamReader.ReadToEndAsync();
            }
        }

        public string ReadAsString(string filename)
        {
            using (var asset = _context.Assets.Open(filename))
            using (var streamReader = new StreamReader(asset))
            {
                return streamReader.ReadToEnd();
            }
        }
    }
}

