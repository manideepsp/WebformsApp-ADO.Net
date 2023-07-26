using System;

namespace BLL
{
    /// <summary>
    /// The random number generator.
    /// </summary>
    internal class RandomNumberGenerator
    {
        /// <summary>
        /// Generates a random 6 digit number.
        /// </summary>
        /// <returns>An int.</returns>
        public static int GenerateRandom6DigitNumber()
        {
            Random random = new Random();
            return random.Next(100000, 999999);
        }
    }
}
