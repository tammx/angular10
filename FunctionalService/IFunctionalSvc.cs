using System.Security.Cryptography;
using System.Threading.Tasks;

namespace FunctionalService
{
    public interface IFunctionalSvc
    {
        Task<string> GetMd5Hash(MD5 md5Hash, string input);
    }
}
