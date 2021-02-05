using System.Text.RegularExpressions;

namespace DXP.SmartConnect.Ecom.Core.Services
{
    public class BaseService
    {
        protected BaseService()
        {

        }

        protected static string RemoveSpecialChars(string input)
        {
            if (!string.IsNullOrEmpty(input))
                return Regex.Replace(input, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
            return input;
        }
    }
}
