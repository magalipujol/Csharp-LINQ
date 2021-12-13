using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hola");
            var movies = new List<Movie>
            {
                new Movie { Title = "Blancanieves y los 7 gu",
                            Rating = 8.9f,
                            Year = 2001},
                new Movie { Title = "En busca de Gu",
                            Rating = 10.2f,
                            Year = 2013},
                new Movie { Title = "GUardianes de la gualaxia",
                            Rating = 2.7f,
                            Year = 1999},
                new Movie { Title = "Gu, mi villano favorito",
                            Rating = 5.9f,
                            Year = 2007},
            };

            var query = movies.Filter(m => m.Year > 2000);
            foreach (var movie in query)
            {
                Console.WriteLine(movie.Title);
            }
        }
    }
}
