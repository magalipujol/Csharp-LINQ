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

            // if I have multiple ways of ordering, it's incorrect to use two orderBy
            // this is how I would do it if I used the extension method syntax
            // var query = cars.OrderByDescending(c => c.Combined).ThenBy(c => c.Name);
            var query =
                from car in cars
                orderby car.Combined descending, car.Name ascending
                select car;

            foreach (var car in query.Take(10))
            {
                Console.WriteLine($"{ car.Name } : { car.Combined }");
            }
        }

        // this is a file processor
        private static List<Car> ProcessFile(string path)
        {
            // to use the ReadAllLines method I have to use System.IO
            // I give a path to a file and returns an array of string
            // each string represents a line in the fuel.csv file
            // the methods after (path) are linq mehtods, with use System.Linq
            // TODO i think that the line.Length > 1 is not working
            return File.ReadAllLines(path)
                    .Skip(1)
                    .Where(line => line.Length > 1)
                    .Select(Car.ParseFromCsv)
                    .ToList();
            // i used the extension method syntax, but I could use query syntax like this:
            // var query = from line in File.ReadAllLines(path).Skip(1) where line.Length > 1 select Car.ParseFromCsv(line);
            // return query.ToList();

        }
    }
}
