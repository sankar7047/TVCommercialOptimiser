using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Combinatorics.Collections;
using CommercialOptimiser.Core;
using CommercialOptimiser.Models;
using Newtonsoft.Json;

namespace CommercialOptimiser.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----- Welcome to TV Commercial Optimiser -----");

            var commercials = JsonConvert.DeserializeObject<IList<Commercial>>(Read("Commercials.json"));

            var breakRatings = JsonConvert.DeserializeObject<IList<Break>>(Read("Ratings.json"));

            if (commercials != null && commercials.Any() && breakRatings != null && breakRatings.Any())
            {
                try
                {
                    var service = CommercialOptimiserService.GetCommercialOptimiser(commercials, breakRatings);
                    var maximumRating = service.ObtainOptimisedRatings(3, 3, 3);

                    Console.WriteLine($"For the given commercials and ratings, the maximum ratings can be obtained by the following commercial comminations.\n");

                    foreach (var item in maximumRating)
                    {
                        Console.WriteLine("Break 1 - ");
                        foreach (var break1 in item.Break1)
                        {
                            Console.Write($"{break1.Name}, {break1.Type}, {break1.Demographic} ");
                        }

                        Console.WriteLine("\nBreak 2 - ");
                        foreach (var break2 in item.Break2)
                        {
                            Console.Write($"{break2.Name}, {break2.Type}, {break2.Demographic} ");
                        }

                        Console.WriteLine("\nBreak 3 - ");
                        foreach (var break3 in item.Break3)
                        {
                            Console.Write($"{break3.Name}, {break3.Type}, {break3.Demographic} ");
                        }
                        Console.WriteLine("\n");
                    }

                    Console.WriteLine($"The maximum rating obtained is {maximumRating.Key}");
                    
                }
                catch (InvalidInputException ex)
                {
                    Console.WriteLine($"{ex.Message} - Please try again with a valid input.");
                }

                Console.WriteLine("\nPress any key to exit.");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Method to read the json file and return the json string.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static string Read(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                try
                {
                    string json = file.ReadToEnd();

                    return json;
                }
                catch (Exception)
                {
                    Console.WriteLine("Problem reading file");

                    return null;
                }
            }
        }
    }
}
