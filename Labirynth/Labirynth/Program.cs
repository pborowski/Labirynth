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
using System.Threading;


namespace Labirynth
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lol();
            SetWindow();
            Console.SetBufferSize(50,40);
            Console.OutputEncoding = Encoding.UTF8;
            char[,] lab1 = LoadLabirynth();
            Point playerPoint = getPlayerCoordinates(lab1);
            DrawLabirynth(playerPoint, lab1);
            playerPoint = getPlayerCoordinates(lab1);
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
                            Console.SetCursorPosition(playerPoint.Y, playerPoint.X);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(' ');
                            Console.SetCursorPosition(playerPoint.Y, playerPoint.X -1);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            //Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write('&');
                            lab1[playerPoint.X, playerPoint.Y] = ' ';
                            lab1[playerPoint.X - 1, playerPoint.Y ] = '&';
                            //DrawLabirynth(playerPoint,lab1);
                            playerPoint = getPlayerCoordinates(lab1);
                            Console.SetCursorPosition(0, 30);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("\n" + playerPoint.X + "" + playerPoint.Y);
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (playerPoint.Y + 1 > 29)
                        {
                            LevelEndScreen();
                        }
                        else
                        {
                            if (lab1[playerPoint.X, playerPoint.Y + 1] != 'X')
                            {
                                Console.SetCursorPosition(playerPoint.Y, playerPoint.X);
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(' ');
                                Console.SetCursorPosition(playerPoint.Y +1, playerPoint.X);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                //Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write('&');
                                lab1[playerPoint.X, playerPoint.Y] = ' ';
                                lab1[playerPoint.X, playerPoint.Y + 1] = '&';
                                //DrawLabirynth(playerPoint, lab1);
                                playerPoint = getPlayerCoordinates(lab1);
                                Console.SetCursorPosition(0, 30);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("\n" + playerPoint.X + "" + playerPoint.Y);
                            }
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (lab1[playerPoint.X + 1, playerPoint.Y] != 'X')
                        {
                            Console.SetCursorPosition(playerPoint.Y, playerPoint.X);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(' ');
                            Console.SetCursorPosition(playerPoint.Y, playerPoint.X + 1);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            //Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write('&');
                            lab1[playerPoint.X, playerPoint.Y] = ' ';
                            lab1[playerPoint.X + 1, playerPoint.Y] = '&';
                            //DrawLabirynth(playerPoint, lab1);
                            playerPoint = getPlayerCoordinates(lab1);
                            Console.SetCursorPosition(0, 30);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("\n" + playerPoint.X + "" + playerPoint.Y);
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (lab1[playerPoint.X , playerPoint.Y -1] != 'X')
                        {
                            Console.SetCursorPosition(playerPoint.Y, playerPoint.X);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(' ');
                            Console.SetCursorPosition(playerPoint.Y - 1, playerPoint.X);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            //Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write('&');
                            lab1[playerPoint.X, playerPoint.Y] = ' ';
                            lab1[playerPoint.X, playerPoint.Y -1] = '&';
                            //DrawLabirynth(playerPoint, lab1);
                            playerPoint = getPlayerCoordinates(lab1);
                            Console.SetCursorPosition(0,30);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("\n" + playerPoint.X + "" + playerPoint.Y);
                        }
                        break;
                }
            }


        }

        static void SetColors()
        {       
            Console.BackgroundColor = ConsoleColor.DarkGray;
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


        static void LevelEndScreen()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            IntPtr hCurrentWindow = Process.GetCurrentProcess().MainWindowHandle;
            Graphics g = Graphics.FromHwnd(hCurrentWindow);
            g.DrawRectangle(new Pen(Color.Red, 3), 0, 0, 300, 500);
            g.Dispose();
            Console.SetCursorPosition(4, 3);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Gratulacje! Wyszedłeś z labiryntu :)");
            Console.ReadLine();
        }

        static Point getPlayerCoordinates(char[,] lab1)
        {
            Point p = new Point();
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (lab1[i, j] == '&')
                    {
                        p.X = i;
                        p.Y = j;
                    }
                }
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
                    switch (lab1[i, j])
                    {
                        case '&':
                            //Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            playerPoint.X = i;
                            playerPoint.Y = j;
                            break;
                        case 'X':
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            break;
                        case ' ':
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                    Console.Write(lab1[i, j]);
                }
                Console.Write("\n");
            }
//            IntPtr hCurrentWindow = Process.GetCurrentProcess().MainWindowHandle;
//            Graphics g = Graphics.FromHwnd(hCurrentWindow);
//            g.DrawRectangle(new Pen(Color.Red, 3), 0, 0, 300, 580);
//            g.Dispose();
        }

        static char[,] LoadLabirynth()
        {
            char[,] LabirynthOne = new char[30, 30];


            using (StreamReader readtext = new StreamReader("C:\\Users\\Pawel\\repozytoria\\LabirynthRepo\\Labirynth\\Labirynth\\labirynth.txt"))
            {
                string Map = readtext.ReadToEnd();
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
