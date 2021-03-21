using System;

namespace encryptor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Focus::Encryptor";
            ConsoleColor white = ConsoleColor.White;
            ConsoleColor red = ConsoleColor.Red;
            ConsoleColor green = ConsoleColor.Green;
            Console.WriteLine("FocusCrypt [Version 1.3.2.1]");
            Console.WriteLine("https://www.github.com/focuscrypt/encryptor");
            Console.ForegroundColor = green;
            Console.WriteLine("Women's Rights Matters.");
            Console.WriteLine();
            Console.ForegroundColor = white;
        start:
            Console.Write("Create a Password:");
            string pass = string.Empty;
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;
                if (key == ConsoleKey.Backspace && pass.Length > 0)
                {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    pass += keyInfo.KeyChar;
                }
            } while (key != ConsoleKey.Enter);
            Console.WriteLine();
            if (string.IsNullOrWhiteSpace(pass))
            {
                Console.ForegroundColor = red;
                Console.WriteLine("Please set a password!");
                Console.ForegroundColor = white;
                Console.WriteLine();
                goto start;
            }
            Console.ForegroundColor = green;
            Console.WriteLine("You have created a password.");
            Console.ForegroundColor = white;
            Console.WriteLine();
        second:
            Console.Write("Enter a plain text:");
            string ptext = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ptext))
            {
                Console.ForegroundColor = red;
                Console.WriteLine("Please enter any text.");
                Console.ForegroundColor = white;
                Console.WriteLine();
                goto second;
            }
            Console.ForegroundColor = green;
            Console.WriteLine("Ok.");
            Console.ForegroundColor = white;
            Console.WriteLine("The encryption process has started. Please wait...");
            Console.WriteLine("The encryption process is complete. Result:");
            Console.ForegroundColor = green;
            Console.WriteLine();
            Console.WriteLine("-----");
            Console.ForegroundColor = white;
            Console.WriteLine(Focus.Encrypt(ptext, pass));
            Console.ForegroundColor = green;
            Console.WriteLine("-----");
            Console.WriteLine();
            Console.ForegroundColor = white;
            Console.WriteLine("Don't forget to copy the encrypted text!");
            Console.Write("Do you want to do another encryption?(y/n)");
            string c = Console.ReadLine();
            if (c == "y")
            {
                Console.WriteLine();
                goto start;
            }
            Console.Write("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
