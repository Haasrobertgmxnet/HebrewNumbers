using System.Threading.Tasks;

namespace HebrewNumbers
{
    public interface IFileStorage
    {
        Task<string> ReadAsStringAsync(string filename);

        string ReadAsString(string filename);
    }
}
