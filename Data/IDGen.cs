using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace InventarioWebBE_FullStack.Data
{
    public static class IDGen
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static async Task<string> StringIDGen<T>(AppDbContext context, Func<T, string> idSelector, int length = 7) where T : class
        {
            string candidateId;
            bool exists;

            do
            {
                char[] result = new char[length];
                byte[] randomBytes = new byte[length];
                using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
                {
                    rng.GetBytes(randomBytes);
                }

                for (int i = 0; i < length; i++)
                {
                    result[i] = Chars[randomBytes[i] % Chars.Length];
                }

                candidateId = new string(result);

                // Check DB for duplicate
                exists = await context.Set<T>().AnyAsync(e => EF.Property<string>(e, "ID") == candidateId);

            } while (exists);

            return candidateId;
        }
    }
}
    