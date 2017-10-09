using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Runtime.InteropServices;
using System.Drawing;


namespace Labirynth
{
    class Program
    {
        static void Main(string[] args)
        {
            SetWindow();
            Console.OutputEncoding = Encoding.UTF8;
            char[,] lab1 = LoadLabirynth();
            Point playerPoint = getPlayerCoordinates(lab1);
            DrawLabirynth(playerPoint, lab1);
            Console.Write("\n"+playerPoint.X + ""+ playerPoint.Y);
            
            //char c = '\u2181';
            //Console.Write(c);
            //SetPleyer();

            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (lab1[playerPoint.X - 1, playerPoint.Y ] != 'X')
                        {
                            lab1[playerPoint.X, playerPoint.Y] = ' ';
                            lab1[playerPoint.X - 1, playerPoint.Y ] = '&';
                            DrawLabirynth(playerPoint,lab1);
                            playerPoint = getPlayerCoordinates(lab1);
                            Console.Write("\n" + playerPoint.X + "" + playerPoint.Y);
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (playerPoint.Y + 1 > 29)
                        {
                            Console.Write("\n\n" + "GRATULACJE WYSZEDŁEŚ Z LABIRYNTU!");
                        }
                        else
                        {
                            if (lab1[playerPoint.X, playerPoint.Y + 1] != 'X')
                            {
                                lab1[playerPoint.X, playerPoint.Y] = ' ';
                                lab1[playerPoint.X, playerPoint.Y + 1] = '&';
                                DrawLabirynth(playerPoint, lab1);
                                playerPoint = getPlayerCoordinates(lab1);
                                Console.Write("\n" + playerPoint.X + "" + playerPoint.Y);
                            }
                        }
                        
                        break;

                    case ConsoleKey.DownArrow:
                        if (lab1[playerPoint.X + 1, playerPoint.Y] != 'X')
                        {
                            lab1[playerPoint.X, playerPoint.Y] = ' ';
                            lab1[playerPoint.X + 1, playerPoint.Y] = '&';
                            DrawLabirynth(playerPoint, lab1);
                            playerPoint = getPlayerCoordinates(lab1);
                            Console.Write("\n" + playerPoint.X + "" + playerPoint.Y);
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (lab1[playerPoint.X , playerPoint.Y -1] != 'X')
                        {
                            lab1[playerPoint.X, playerPoint.Y] = ' ';
                            lab1[playerPoint.X, playerPoint.Y -1] = '&';
                            DrawLabirynth(playerPoint, lab1);
                            playerPoint = getPlayerCoordinates(lab1);
                            Console.Write("\n" + playerPoint.X + "" + playerPoint.Y);
                        }
                        break;
                }
            }


        }

        static void SetColors()
        {       
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear(); //Important!
        }

        static void SetWindowSize()
        {
           // Console.SetWindowSize(50, 30);
           // Console.SetBufferSize(50, 30);
        }

        static void SetWindow()
        {
            SetColors();
            SetWindowSize();
            Console.Title = "Labirynth Game";
        }

        static Point getPlayerCoordinates(char[,] lab1)
        {
            Point p = new Point();
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.Write(lab1[i, j]);
                    if (lab1[i, j] == '&')
                    {
                        p.X = i;
                        p.Y = j;
                    }
                }
                Console.Write("\n");
            }
            return p;
        }

        static void DrawLabirynth(Point playerPoint, char[,] lab1)
        {
            Console.Clear();
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    Console.Write(lab1[i, j]);
                    if (lab1[i, j] == '&')
                    {
                        playerPoint.X = i;
                        playerPoint.Y = j;
                    }
                }
                Console.Write("\n");
            }
        }

        static char[,] LoadLabirynth()
        {
            char[,] LabirynthOne = new char[30, 30];


            using (StreamReader readtext = new StreamReader("C:\\Users\\Pawel\\repozytoria\\LabirynthRepo\\Labirynth\\Labirynth\\labirynth.txt"))
            {
                string Map = readtext.ReadToEnd();
                //System.Console.Write(Map[32].ToString());
                Console.ReadLine();
                //Console.Write(Map);
                int a = 0, b = 0;
                char currentChar;
                for (int i = 0; i < Map.Length; i++)
                {
                    
                    switch (Map[i])
                    {
                        case '1': //ściana
                            currentChar ='X';//'\u2181';
                            break;
                        case '0':
                            currentChar = ' ';
                            break;
                        case 'X': //gracz
                            currentChar = '&';
                            break;
                        default:
                            currentChar = '@';
                            break;
                    }
                    if (currentChar != '@')
                    {
                        if (a < 29)
                        {
                            if (b < 30)
                            {
                                LabirynthOne[a, b] = currentChar;
                            }
                            else
                            {
                                b = 0;
                                LabirynthOne[a, b] = currentChar;
                                a++;

                            }
                        }
                        else
                        {
                            if (a == 29)
                            {
                                if (b < 30)
                                {
                                    LabirynthOne[a, b] = currentChar;
                                }
                            }
                        }
                        //LabirynthOne[a, b] = currentChar;
                        b++;
                    }
                }
            }
                
            
            
            //'\u2181'

            return LabirynthOne;

        }
    }
}
