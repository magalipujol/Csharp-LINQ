using System;
using System.Collections.Generic;
using System.Linq;
//using Features.Linq;


namespace Features
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //In Lambda expressions, the last parameter is the return type
            //Func<int, int> square = x => x * x;
            //Console.WriteLine(square(4));
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee { Id = 1, Name = "Gugu"},
                new Employee { Id = 2, Name = "Guguis"},
                new Employee { Id = 3, Name = "Agus"}
            };

            //I could also use IEnumerable<Employee> instead of var
            var sales = new List<Employee>()
            {
                new Employee { Id = 3, Name = "gugipuki"}
            };

            Console.WriteLine("Employees with 4 letters");
            //query and query2 are equivalent
            var query = developers.Where(e => e.Name.Length == 4)
                                         .OrderBy(e => e.Name);

            var query2 = from developer in developers
                         where developer.Name.Length == 4
                         orderby developer.Name
                         select developer;

            foreach (var employee in query2)
            {
                Console.WriteLine(employee.Name);
            }
            //this is another way of doing the code above
            //foreach (var employee in developers.Where(
            //    e => e.Name.Length == 4)
            //    .OrderBy(e => e.Name))
            //{
            //    Console.WriteLine(employee.Name);
            //}

            //Console.WriteLine(sales.Count());
            //IEnumerator<Employee> enumerator = developers.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current.Name);
            //}
        }

    }
}
