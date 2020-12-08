namespace MSmile.Api.Test
{
    using System;
    using System.Threading.Tasks;

    using MSmile.Api.Client;

    /// <summary>
    /// Test application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">Arguments.</param>
        static async Task Main(string[] args)
        {
            var c = new DifficultyLevelClient
            {
                BaseUrl = "http://192.168.0.10"
            };
            var result = await c.GetAllAllAsync();
            Console.ReadKey();
        }
    }
}
