using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Labirynth
{
    class Program
    {
        static void Main(string[] args)
        {
            SetWindow();
            Console.OutputEncoding = Encoding.UTF8;
            char[,] lab1 = LoadLabirynth();
            //char c = '\u2181';
            //Console.Write(c);
            //SetPleyer();

            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.Write(lab1[i,j]);
                }
                Console.Write("\n");
            }
            Console.ReadLine();
            Console.Write(lab1[0,1]);
            /*ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        break;

                    case ConsoleKey.RightArrow:
                        break;

                    case ConsoleKey.DownArrow:
                        break;

                    case ConsoleKey.LeftArrow:
                        break;
                }
            }*/


        }

        static void SetColors()
        {       
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear(); //Important!
        }

        static void SetWindowSize()
        {
            Console.SetWindowSize(50, 30);
            Console.SetBufferSize(50, 30);
        }

        static void SetWindow()
        {
            SetColors();
            SetWindowSize();
            Console.Title = "Labirynth Game";
        }

        static void SetPlayer()
        {
            
        }

        static char[,] LoadLabirynth()
        {
            char[,] LabirynthOne = new char[30, 30];


            using (StreamReader readtext = new StreamReader("C:\\Users\\Pawel\\repozytoria\\LabirynthRepo\\Labirynth\\Labirynth\\labirynth.txt"))
            {
                string Map = readtext.ReadToEnd();
                Console.Write(Map);
                int a = 0, b = 0;
                for (int i = 0; i < Map.Length; i++)
                {
                    char currentChar;
                    if (Map[i] == 1)
                    {
                        currentChar = '\u2181';
                    }
                    else
                    {
                        if (Map[i] == 0)
                        {
                            currentChar = ' ';
                        }
                        else
                        {
                            currentChar = 'x';
                        }
                    }
                        
                    if (a <= 30)
                    {
                        if (b <= 30)
                        {
                            LabirynthOne[a, b] = currentChar;
                        }
                        else
                        {
                            b = 0;
                            a++;
                            LabirynthOne[a, b] = currentChar;
                        }
                    }
                    LabirynthOne[a, b] = currentChar;
                    b++;
                }
            }
                
            
            
            //'\u2181'

            return LabirynthOne;

        }
    }
}
