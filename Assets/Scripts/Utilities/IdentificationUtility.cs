using System;
using System.Linq;

namespace MultiPong.Utilities
{
    public static class IdentificationUtility
    {
        public static string GenerateSessionId()
        {
            return $"Session_{GenerateRandomCharacters(5)}{GetUtcNowTimestamp()}";
        }

        private static string GenerateRandomCharacters(int length)
        {
            const string CHARACTERS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            
            return new string(
                Enumerable.Repeat(CHARACTERS, length).Select(
                    s => s[random.Next(s.Length)]
                ).ToArray()
            );
        }

        private static string GetUtcNowTimestamp()
        {
            return ((DateTimeOffset)DateTimeOffset.UtcNow).ToUnixTimeSeconds().ToString();
        }
    }
}