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
            // the select is not necessary
            // var query = cars.Where(c => c.Manufacturer == "BMW" && c.Year == 2016).OrderByDescending(c => c.Combined).ThenBy(c => c.Name).Select(c => c);
            var query =
                from car in cars
                where car.Manufacturer == "BMW" && car.Year == 2016
                orderby car.Combined descending, car.Name ascending
                select car;

            // if I want to show only the top car in the query I would use this
            // this returns only a Car, not an iterable of Cars
            // not the most efficient query because orders after selecting the ones that I care about
            var top = cars.OrderByDescending(c => c.Combined)
                          .ThenBy(c => c.Name)
                          .Select(c => c)
                          .FirstOrDefault(c => c.Manufacturer == "aaa" && c.Year == 2016);
            if (top != null)
            {
                Console.WriteLine(top.Name);
            }

            // if I need to know if there is data with an specific condition I can use any, all or contains
            var BMWboolAll = cars.All(c => c.Manufacturer == "BMW"); // false
            var BMWboolAny = cars.Any(c => c.Manufacturer == "BMW"); // true

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
