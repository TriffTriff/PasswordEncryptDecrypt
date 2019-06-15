using System;

//called passwordencryptdecrypt but you can use it for anything!
namespace PasswordEncryptDecrypt
{
    class Program
    {
        //array will be cycled through on encryption.
        //each number represents what will happen to the ascii value 
        //of that character: plus1, plus2, minus4, etc.
        //the array values are reversed in decrypt.cs
        public static int[] plusMinus = { 1, 2, 1, 0, 3, -4, 6, 2, 5, -1 };
        public static void ResetColors()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void ResetArr()
        {
            int [] plusMinusRestore = { 1, 2, 1, 0, 3, -4, 6, 2, 5, -1 };
            plusMinus = plusMinusRestore;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                //reseting the array after changes from 
                ResetArr();
                Console.WriteLine("Enter 'e' for encrypt, enter 'd' for decrypt:");
                try
                {
                    string s = Console.ReadLine();
                    if (s.Equals("exit") || s.Equals("quit"))
                        break;
                    char c = s.ToCharArray()[0];
                    if (c.Equals('e'))
                    {
                        Encrypt en = new Encrypt(plusMinus); en.Start();
                    }
                    else if (c.Equals('d'))
                    {
                        Decrypt de = new Decrypt(plusMinus); de.Start();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Entry was not typed correctly.");
                        ResetColors();
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(e+" Entry was not typed correctly.");
                    continue;
                }
            }
        }
    }
}
