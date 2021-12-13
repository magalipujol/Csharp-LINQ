using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessFile("fuel.csv");
            foreach (var car in cars)
            {
                Console.WriteLine(car.Name);
            }
        }

        // this is a file processor
        private static List<Car> ProcessFile(string path)
        {
            // to use the ReadAllLines method I have to use System.IO
            // I give a path to a file and returns an array of string
            // each string represents a line in the fuel.csv file
            // the methods after (path) are linq mehtods, with use System.Linq
            return File.ReadAllLines(path)
                    .Skip(1)
                    .Where(line => line.Length > 1)
                    .Select(Car.ParseFromCsv)
                    .ToList();
        }
    }
}
