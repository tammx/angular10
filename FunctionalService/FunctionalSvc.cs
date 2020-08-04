using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace FunctionalService
{
    public class FunctionalSvc : IFunctionalSvc
    {
        public async Task<string> GetMd5Hash(MD5 md5Hash, string input)
        {
            string result = String.Empty;
            try
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                result = sBuilder.ToString();

            }
            catch (Exception ex)
            {
                Log.Error("Error while hash MD5 {Error} {StackTrace} {InnerException} {Source}",
                   ex.Message, ex.StackTrace, ex.InnerException, ex.Source);
            }
            return result;
        }
    }
}
