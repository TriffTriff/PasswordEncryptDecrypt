using System;
using System.Text;

namespace PasswordEncryptDecrypt
{
    public class Encrypt
    {
         readonly int[] plusMinusE = { };
        public static void ResetColors()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public Encrypt(int [] iArr)
        {
            plusMinusE = iArr;
            for(int i=0; i< iArr.Length; i++)
            {
                //Console.Write(iArr[i]+" ");
            } //Console.WriteLine();
        }
        public string Encryption(string s)
        {
            //split
            //char[] chr = s.ToCharArray();
            //encrypt
            int plusMinusPosition = 0;
            //System.out.println((char)65);  <-- from int, print get character value
            //int i = (int)'x'; <-- from char, get ascii value
            int[] iArr = new int[s.Length];
            for (int i = 0; i < s.Length; i ++)
            {
                byte j = Encoding.Default.GetBytes(s)[i];
                int k = j+plusMinusE[plusMinusPosition++];
                iArr[i] = k;
                if (plusMinusPosition == plusMinusE.Length) plusMinusPosition = 0;
                //Console.Write(k+" ");
            }
            //convert byteArr to 
            string str = "";
            for(int i=0; i < iArr.Length; i++)
            {
                str += (char)iArr[i];
            }
            //Console.WriteLine();
            return str;
        }
        public void Start()
        {
           
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Please enter a password to be encrypted:");
                ResetColors();
                string s = Console.ReadLine();
                if (s.Equals("exit") || s.Equals("quit")) { ResetColors(); break; }
                //encrypt, print out result:
                s = Encryption(s);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Encrypted Text: ");
                ResetColors();
                Console.Write(s);
                Console.WriteLine();
            }
        }
    }
}
