using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series_DIO
{
    internal class Program
    {
        static SerieRepository repository = new SerieRepository();

        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListSeries();
                        break;

                    case "2":
                        InsertSerie();
                        break;

                    case "3":
                        UpdateSerie();
                        break;

                    case "4":
                        DeleteSerie();
                        break;

                    case "5":
                        ViewSerie ();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Thanks for using our services.");
            Console.ReadLine();
        }

        private static void ListSeries()
        {
            Console.WriteLine("Series List");

            var list = repository.List();

            if (list.Count == 0)
            {
                Console.WriteLine("No Series Registered");
                return;
            }

            foreach (var serie in list)
            {
                var deleted = serie.GetDeleted();

                Console.WriteLine("#ID {0}: - {1} {2}", serie.GetTitle(), serie.GetTitle(), (deleted ? " * Deleted *" : ""));
            }
        }

        private static void InsertSerie()
        {
            Console.WriteLine("Insert New Serie");

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Choose a Genre in the options above: ");
            int genreChoose = int.Parse(Console.ReadLine());

            Console.Write("Insert the Title of the Serie: ");
            string serieTitle = Console.ReadLine();

            Console.Write("Insert the Year of the Serie: ");
            int serieYear = int.Parse(Console.ReadLine());

            Console.Write("Insert the Description of the Serie: ");
            string serieDescription = Console.ReadLine();

            Serie newSerie = new Serie(id: repository.NextId(),
                genre: (Genre)genreChoose,
                title: serieTitle,
                year: serieYear,
                description: serieDescription);

            repository.Insert(newSerie);
        }

        private static void UpdateSerie()
        {
            Console.Write("Insert the ID of the Serie: ");
            int serieIndex = int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre), i));
            }
            Console.Write("Choose a Genre in the options above: ");
            int genreChoose = int.Parse(Console.ReadLine());

            Console.Write("Insert the Title of the Serie: ");
            string serieTitle = Console.ReadLine();

            Console.Write("Insert the Year of the Serie: ");
            int serieYear = int.Parse(Console.ReadLine());

            Console.Write("Insert the Description of the Serie: ");
            string serieDescription = Console.ReadLine();

            Serie serieUpdate = new Serie(id: serieIndex,
                genre: (Genre)genreChoose,
                title: serieTitle,
                year: serieYear,
                description: serieDescription);

            repository.Update(serieIndex, serieUpdate);
        }

        private static void DeleteSerie()
        {
            Console.Write("Insert the ID of the Serie to be Deleted: ");
            int serieIndex = int.Parse(Console.ReadLine());

            repository.Delete(serieIndex);
        }

        private static void ViewSerie()
        {
            Console.Write("Enter Serie ID to View: ");
            int serieIndex = int.Parse(Console.ReadLine());

            var serie = repository.ReturnId(serieIndex);

            Console.WriteLine(serie);
        }

        private static string GetUserOption()
        {
            Console.WriteLine("Series DIO at your services!");
            Console.WriteLine("Enter a Option: ");
            Console.WriteLine();
            
            Console.WriteLine("1- List All Series");
            Console.WriteLine("2- Insert a New Serie");
            Console.WriteLine("3- Update a existing Serie");
            Console.WriteLine("4- Delete a Serie");
            Console.WriteLine("5- Visualize a Serie");
            Console.WriteLine("C- Clean Screen");
            Console.WriteLine("X- Exit");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            return userOption;
        }
    }
}
