using System;

namespace Behelit.Core
{
    public interface IRandomService
    {
        string GenerateRandomString();
    }

    public class RandomService : IRandomService
    {
        public string GenerateRandomString()
        {
            var ran = new Random();
            var b = "abcdefghijklmnopqrstuvwxyz";
            var length = 6;

            var result = "";

            for (int i = 0; i < length; i++)
            {
                int a = ran.Next(26);
                result = result + b.Substring(a, 1);
            }

            return result;
        }
    }
}
