using System;
using System.Text;

namespace PasswordEncryptDecrypt
{
    public class Decrypt
    {
         int[] plusMinusE;
        //reverse of Encrypt:
        //readonly int[] plusMinusD = {-1, -2, -1, 0, -3, 4, -6, -2,-5, 1};
         int[] plusMinusD = { };
        public static void ResetColors()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        //because of the pointer to program's original plusMinus Arr, need to reset the arr every time we reset the loop
        //in program class:
        public int[] SwapSigns(int [] iArr)
        {
            for(int i=0; i < plusMinusE.Length; i++)
            {
                if (iArr[i] > 0 || iArr[i] <0) iArr[i] = -iArr[i];
                //Console.Write(iArr[i] + " ");
            } //Console.WriteLine();
            return iArr;
        }
        public Decrypt(int []iArr)
        {
            this.plusMinusE = iArr;
            plusMinusD = SwapSigns(plusMinusE);
        }
        public string Decryption(string s)
        {
            //split
            //char[] chr = s.ToCharArray();
            //encrypt
            int plusMinusPosition = 0;
            //System.out.println((char)65);  <-- from int, print get character value
            //int i = (int)'x'; <-- from char, get ascii value
            int[] iArr = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                byte j = Encoding.Default.GetBytes(s)[i];
                int k = j + plusMinusD[plusMinusPosition++];
                iArr[i] = k;
                if (plusMinusPosition == plusMinusD.Length) plusMinusPosition = 0;
                //Console.Write(k+" ");
            }
            //convert byteArr to 
            string str = "";
            for (int i = 0; i < iArr.Length; i++)
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter a password to be decyrpted:");
                ResetColors();
                string s = Console.ReadLine();
                if (s.Equals("exit") || s.Equals("quit")) { ResetColors(); break; }
                s = Decryption(s);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Decrypted Text: ");
                ResetColors();
                Console.Write(s);
                Console.WriteLine();
            }
        }
    }
}
