using System;
using System.IO;

namespace Cinema_FileHandling_Console
{
    class Program
    {
        public class movie
        {
            public string title, agerating, genre, rating;
        }
        static void Main(string[] args)
        {
            movie[] mymovies = new movie[99];

            int num;

            string response = "N", path = "C:\\Users\\Not_R\\OneDrive\\Documents\\Comp.Proj\\Visual Studio\\Movies.txt";

            while (response != "E")
            {
                Console.WriteLine("Enter New Movie(N), View Past Entries(P), Clear Entries(C) or Exit(E)?");
                response = Console.ReadLine();

                switch (response)
                {
                    case "N":
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            Console.WriteLine("Enter Movie Title");
                            sw.WriteLine(Console.ReadLine());
                            Console.WriteLine("Enter Age Rating");
                            sw.WriteLine(Console.ReadLine());
                            Console.WriteLine("Enter Genre");
                            sw.WriteLine(Console.ReadLine());
                            Console.WriteLine("Enter Rating");
                            sw.WriteLine(Console.ReadLine());
                        }
                        break;

                    case "P":
                        using (StreamReader sr = new StreamReader(path))
                        {
                            movie movie = new movie();
                            string x = sr.ReadLine();
                            for (int i = 0; i < 396; i++)
                            {
                                num = i % 4;
                                switch (num)
                                {
                                    case 0:
                                        movie.title = sr.ReadLine();
                                        mymovies[i / 4] = movie;
                                        break;
                                    case 1:
                                        movie.genre = sr.ReadLine();
                                        mymovies[i / 4] = movie;
                                        break;
                                    case 2:
                                        movie.agerating = sr.ReadLine();
                                        mymovies[i / 4] = movie;
                                        break;
                                    case 3:
                                        movie.rating = sr.ReadLine();
                                        mymovies[i / 4] = movie;
                                        break;

                                }
                            }

                              for (int n = 0; n < 99; n++)
                            {
                                if (mymovies[n].title == null)
                                    break;

                                Console.WriteLine("Title: " + mymovies[n].title);
                                Console.WriteLine("Age Rating: " + mymovies[n].agerating);
                                Console.WriteLine("Genre: " + mymovies[n].genre);
                                Console.WriteLine("Audience Rating (#/10): " + mymovies[n].rating);
                                Console.WriteLine(Environment.NewLine);
                            }
                        }
                        break;

                    case "C":
                        using (StreamWriter writer = new StreamWriter(path))
                        {
                            writer.WriteLine();
                        }
                            break;

                    case "E":
                        Console.WriteLine("Thank You");
                        break;
                }
            }

            Console.Read();

        }
    }
}
