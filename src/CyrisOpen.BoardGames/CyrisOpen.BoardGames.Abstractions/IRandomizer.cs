namespace CyrisOpen.BoardGames.Abstractions
{
    public interface IRandomizer
    {   /// <summary>
        /// Generates a random integer within the specified range.
        /// </summary>
        /// <param name="min">The inclusive lower bound of the random number returned.</param>
        /// <param name="max">The exclusive upper bound of the random number returned.</param>
        /// <returns>A random integer between min (inclusive) and max (exclusive).</returns>
        int Next(int min, int max);


        /// <summary>
        /// Generates the next random integer.
        /// </summary>
        /// <returns>A random unsigned integer in the range of 0 to <see cref="int.MaxValue"/>.</returns>
        int Next();
    }
}
