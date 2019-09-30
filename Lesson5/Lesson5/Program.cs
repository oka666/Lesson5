using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select the program you want to execute:");

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Press '1' if you want to run program 'WriteName'");
                Console.WriteLine("Press '2' if you want to run program 'SearchName'");
                Console.WriteLine("Press '3' to close the application");

                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        WriteName();
                        break;
                    case "2":
                        SearchName();
                        break;
                    case "3":
                        Environment.Exit(-1);
                        break;
                    default:
                        Console.WriteLine("Please make your choice");
                        break;
                }

            } }

        public static void WriteName()
        {
            int space = 0;
            var name = string.Empty;
            do
            {
                Console.WriteLine("Please enter First name, Last name and Surname::");
                name = Console.ReadLine().ToLower();

                var b = name.ToCharArray();

                space = 2;
                for (int i = 0; i < b.Length; i++)
                    if (b[i] == ' ') space--;
            }
            while (space != 0);


            var firstName = name.Substring(0, 1).ToUpper() + name.Substring(1, name.IndexOf(" "));

            var lastName = name.Substring(name.IndexOf(" ") + 1, name.LastIndexOf(" "));
            lastName = lastName.Substring(0, 1).ToUpper() + ".";

            var lengthSurname = name.Length - firstName.Length - lastName.Length + 2;
            var surname = name.Substring(lengthSurname + 1);
            Console.WriteLine(firstName + lastName + surname.Substring(0, 1).ToUpper() + ".");

            Console.ReadKey();
        }

            public static void SearchName()
        { 
            int space = 0;

            var name = string.Empty;
            char[] charArray;
            string[][] mas = new string[3][];
            mas[0] = new string[3];
            mas[1] = new string[3];
            mas[2] = new string[3];

            for (int i = 0; i < mas.Length; i++)
            {
                do
                {
                    Console.WriteLine($"Please enter First name{i}, Last name{i} and Surname{i}::");
                    name = Console.ReadLine().ToLower();

                    charArray = name.ToCharArray();

                    space = 2;
                    for (int j = 0; j < charArray.Length; j++)
                        if (charArray[j] == ' ') space--;
                }
                while (space != 0);

                var firstName = name.Substring(0, 1).ToUpper() + name.Substring(1, name.IndexOf(" ") - 1);

                var lastNameSurname = name.Substring(name.IndexOf(" ") + 1);
                var lastName = lastNameSurname.Substring(0, lastNameSurname.IndexOf(" "));
                lastName = lastName.Substring(0, 1).ToUpper() + lastName.Substring(1);

                var surname = lastNameSurname.Substring(lastNameSurname.IndexOf(" ") + 1);
                surname = surname.Substring(0, 1).ToUpper() + surname.Substring(1);

                for (int n = 0; n < 3; n++)
                {
                    mas[i][0] = firstName;
                    mas[i][1] = lastName;
                    mas[i][2] = surname;
                }
                Console.WriteLine();
            }

            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(mas[i][j]);
                    Console.Write(" ");

                }
                Console.WriteLine();
            }

            int[] searchArray = new int[9];
            int search = 0;
            int size = 0;

            Console.WriteLine("Please enter some word to find in array::");
            var word = Console.ReadLine();
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (mas[i][j].ToLower().Contains(word.ToLower()))
                    {
                        search++;
                        searchArray[size++] = i;
                    }
                }
                Console.WriteLine();
            }

            if (search == 0) return;

            for (int i = 0; i < searchArray.Length; i++)
            {
                if (i!=0 && searchArray[i-1] == searchArray[i]) continue;

                if (i !=0 && searchArray[i] == 0)
                    break;

                for (int j = 0; j < 3; j++)
                {
                    Console.Write(mas[searchArray[i]][j] + " ");
                }

                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
