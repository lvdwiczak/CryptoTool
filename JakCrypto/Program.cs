using System;

namespace JakCrypto
{
    internal class Program
    {
        internal static void Menu()
        {
            Console.WriteLine("Witaj w JakCrypto!");
            Console.WriteLine("1. Utwórz Szyfr");
            Console.WriteLine("2. Wybierz Plik Szyfrujacy ze sciezki");
            Console.WriteLine("3. Zaszyfruj Plik");
            Console.WriteLine("4. Zaszyfruj ciag znakow");
            Console.WriteLine("5. Exit");
        }
        internal static void CryptoChar()
        {
            Console.WriteLine("Witaj w JakCrypto! Podaj ilośc znakow szyfrujących");
            Console.WriteLine("1. 2 znaki");
            Console.WriteLine("2. 4 znaki");
            Console.WriteLine("3. 8 znaków");
            Console.WriteLine("4. 16 znaków");
        }
        internal static async Task SaveFileAsync(string[] Lines)
        { 
            await File.WriteAllLinesAsync("WriteLines.txt", Lines);
        }
        internal static async Task SaveFileTextAsync(string text)
        { 
            await File.WriteAllTextAsync("WriteText.txt", text);
        }
        static void Main(string[] args)
        {
            //Variables
            int Chars = 0;
            int RandNo = 0;
            string Path;
            string text;
            string CryptedText= "";
            string CryptoStringForChar;
            Random random = new Random();
            string[] Alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            string[] CryptoString = new string[26];

            //Code
            while (true) { 
            Menu();
            Console.WriteLine("Wybór:");
            string Choose = Console.ReadLine();
            if (Choose == "5") { break; }
                
            switch (Choose)
            {
                case "1":
                    CryptoChar();
                    string Choose2 = Console.ReadLine();

                    switch (Choose2)
                    {
                        case"1": 
                            Chars = 2; 
                            break;
                        case "2": 
                            Chars = 4; 
                            break;
                        case "3": 
                            Chars = 8;
                            break;
                        case "4": 
                            Chars = 16;
                            break;
                    }
                    Console.WriteLine();
                    for(int i = 0; i < CryptoString.Length;i++)
                    {
                        CryptoStringForChar = "";

                        for(int j = 0; j < Chars; j++)
                        {
                            RandNo = random.Next(1,100);
                            if (RandNo % 2 == 0)
                            {
                                RandNo = random.Next(26);
                                CryptoStringForChar += Alphabet[RandNo];
                            }
                            else
                            {
                                RandNo = random.Next(9);
                                CryptoStringForChar += RandNo.ToString();
                            }

                        }
                        CryptoString[i] = CryptoStringForChar;
                    }
                    SaveFileAsync(CryptoString);
                    break;
              case "2":
                        Console.WriteLine("Podaj ścieżkę pliku szyfrującego");
                        Console.WriteLine();
                        Path = Console.ReadLine();
                        CryptoString = System.IO.File.ReadAllLines(Path);
                        Console.WriteLine(CryptoString[1]);
                        break;
              case "3":
                        Console.WriteLine("Podaj ścieżkę pliku do zaszyfrowania:");
                        Console.WriteLine();
                        Path = Console.ReadLine();
                        text = System.IO.File.ReadAllText(Path);
                        char[] CharsToCrypt = text.ToCharArray();
          
                        for(int i = 0; i < CharsToCrypt.Length; i++)
                        {
                            for(int j = 0; j < Alphabet.Length; j++)
                            {
                                text = CharsToCrypt[i].ToString();
                                text.ToUpper();
                                if (text == Alphabet[j])
                                {
                                    CryptedText += CryptoString[j]; 
                                }
                            }
                        }
                        SaveFileTextAsync(CryptedText);
                        break;
              case "4":
                        text = Console.ReadLine();
                        char[] CharsToCrypt2 = text.ToCharArray();

                        for (int i = 0; i < CharsToCrypt2.Length; i++)
                        {
                            for (int j = 0; j < Alphabet.Length; j++)
                            {
                                text = CharsToCrypt2[i].ToString();
                                text.ToUpper();
                                if (text == Alphabet[j])
                                {
                                    CryptedText += CryptoString[j];
                                }
                            }
                        }
                        SaveFileTextAsync(CryptedText);
                        break;
                }
        }
        }
    }
}
