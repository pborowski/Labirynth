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
using System.Drawing.Drawing2D;
using System.Threading;

//+----------------------------------+
//| LABIRYNTH GAME by Paweł Borowski |    
//| Console setup:                   |
//|    -czcionka rastrowa : 16x12    |
//|    -okno: 32 szer 34 wys         |
//+----------------------------------+

namespace Labirynth
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuScreen();
           
        }

        static void CheckCoins(int monety, char[,] lab1, int limit)
        {
            Point[] tab = getFinishCoordinates(lab1);
            if (monety == limit)
            {
                Console.SetCursorPosition(tab[0].Y,tab[0].X);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write('!');
                Console.SetCursorPosition(tab[1].Y, tab[1].X);
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write('!');
            }
                
        }

        static void Level1()
        {
            SetWindow();
            int coins = 0;
            Console.SetCursorPosition(0,0);
            char[,] lab1 = LoadLabirynth(1);
            Point playerPoint = getPlayerCoordinates(lab1);
            DrawLabirynth(playerPoint, lab1);
            playerPoint = getPlayerCoordinates(lab1);
            CheckCoins(coins, lab1,7);

            Console.SetCursorPosition(0, 30);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("LEVEL 1");

            Console.SetCursorPosition(0, 31);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("Monety: " + coins + "/7");

            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                coins = 7;
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (lab1[playerPoint.X - 1, playerPoint.Y] != 'X')
                        {
                            if (lab1[playerPoint.X - 1, playerPoint.Y] == '$')
                            {
                                coins++;

                            }
                            Console.SetCursorPosition(playerPoint.Y, playerPoint.X);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(' ');
                            Console.SetCursorPosition(playerPoint.Y, playerPoint.X - 1);
                            Console.ForegroundColor = ConsoleColor.Red;
                            //Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write('@');
                            lab1[playerPoint.X, playerPoint.Y] = ' ';
                            lab1[playerPoint.X - 1, playerPoint.Y] = '@';
                            //DrawLabirynth(playerPoint,lab1);
                            playerPoint = getPlayerCoordinates(lab1);
                            Console.SetCursorPosition(0, 31);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("Monety: " + coins + "/7");
                            CheckCoins(coins, lab1,7);
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (lab1[playerPoint.X, playerPoint.Y + 1] == '!' && coins == 7)
                        {
                            LevelEndScreen(1);
                        }
                        else if(lab1[playerPoint.X, playerPoint.Y + 1] != '!')
                        {
                            if (lab1[playerPoint.X, playerPoint.Y + 1] != 'X')
                            {
                                if (lab1[playerPoint.X, playerPoint.Y + 1] == '$')
                                {
                                    coins++;
                                }
                                Console.SetCursorPosition(playerPoint.Y, playerPoint.X);
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(' ');
                                Console.SetCursorPosition(playerPoint.Y + 1, playerPoint.X);
                                Console.ForegroundColor = ConsoleColor.Red;
                                //Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write('@');
                                lab1[playerPoint.X, playerPoint.Y] = ' ';
                                lab1[playerPoint.X, playerPoint.Y + 1] = '@';
                                //DrawLabirynth(playerPoint, lab1);
                                playerPoint = getPlayerCoordinates(lab1);
                                Console.SetCursorPosition(0, 31);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("Monety: " + coins + "/7");
                                CheckCoins(coins, lab1,7);
                            }
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (lab1[playerPoint.X + 1, playerPoint.Y] != 'X')
                        {
                            if (lab1[playerPoint.X + 1, playerPoint.Y] == '$')
                            {
                                coins++;
                            }
                            Console.SetCursorPosition(playerPoint.Y, playerPoint.X);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(' ');
                            Console.SetCursorPosition(playerPoint.Y, playerPoint.X + 1);
                            Console.ForegroundColor = ConsoleColor.Red;
                            //Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write('@');
                            lab1[playerPoint.X, playerPoint.Y] = ' ';
                            lab1[playerPoint.X + 1, playerPoint.Y] = '@';
                            //DrawLabirynth(playerPoint, lab1);
                            playerPoint = getPlayerCoordinates(lab1);
                            Console.SetCursorPosition(0, 31);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("Monety: " + coins + "/7");
                            CheckCoins(coins, lab1,7);
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (lab1[playerPoint.X, playerPoint.Y - 1] != 'X')
                        {
                            if (lab1[playerPoint.X, playerPoint.Y - 1] == '$')
                            {
                                coins++;
                            }
                            Console.SetCursorPosition(playerPoint.Y, playerPoint.X);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(' ');
                            Console.SetCursorPosition(playerPoint.Y - 1, playerPoint.X);
                            Console.ForegroundColor = ConsoleColor.Red;
                            //Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write('@');
                            lab1[playerPoint.X, playerPoint.Y] = ' ';
                            lab1[playerPoint.X, playerPoint.Y - 1] = '@';
                            //DrawLabirynth(playerPoint, lab1);
                            playerPoint = getPlayerCoordinates(lab1);
                            Console.SetCursorPosition(0, 31);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("Monety: " + coins + "/7");
                            CheckCoins(coins, lab1,7);
                        }
                        break;
                }
            }
            MenuScreen();
        }

        static void Leve2()
        {
            
            
                SetWindow();
                int coins = 0;
                char[,] lab1 = LoadLabirynth(2);
                Point playerPoint = getPlayerCoordinates(lab1);
                DrawLabirynth(playerPoint, lab1);
                playerPoint = getPlayerCoordinates(lab1);
                Console.SetCursorPosition(0, 30);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write("LEVEL 2");

            Console.SetCursorPosition(0, 31);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("Monety: " + coins + "/10");

            ConsoleKeyInfo keyInfo;
                while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                {
                    coins = 10;
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (lab1[playerPoint.X - 1, playerPoint.Y] == '#')
                            {
                                Console.SetCursorPosition(playerPoint.Y, playerPoint.X);
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(' ');
                                Console.SetCursorPosition(10,18);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write('@');
                                lab1[playerPoint.X, playerPoint.Y] = ' ';
                                lab1[18, 10] = '@';
                                playerPoint = getPlayerCoordinates(lab1);
                                Console.SetCursorPosition(0, 31);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("Monety: " + coins + "/10");
                                CheckCoins(coins, lab1,10);
                        }
                            else if (lab1[playerPoint.X - 1, playerPoint.Y] != 'X')
                            {
                                
                                if (lab1[playerPoint.X - 1, playerPoint.Y] == '$')
                                {
                                    coins++;

                                }
                                Console.SetCursorPosition(playerPoint.Y, playerPoint.X);
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(' ');
                                Console.SetCursorPosition(playerPoint.Y, playerPoint.X - 1);
                                Console.ForegroundColor = ConsoleColor.Red;
                                //Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write('@');
                                lab1[playerPoint.X, playerPoint.Y] = ' ';
                                lab1[playerPoint.X - 1, playerPoint.Y] = '@';
                                //DrawLabirynth(playerPoint,lab1);
                                playerPoint = getPlayerCoordinates(lab1);
                                Console.SetCursorPosition(0, 31);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("Monety: " + coins + "/10");
                                CheckCoins(coins, lab1,10);
                            }
                            break;

                        case ConsoleKey.RightArrow:
                                if (lab1[playerPoint.X, playerPoint.Y + 1] != 'X' && lab1[playerPoint.X, playerPoint.Y + 1] != '#')
                                {
                                    if (lab1[playerPoint.X, playerPoint.Y + 1] == '$')
                                    {
                                        coins++;
                                    }
                                    Console.SetCursorPosition(playerPoint.Y, playerPoint.X);
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write(' ');
                                    Console.SetCursorPosition(playerPoint.Y + 1, playerPoint.X);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    //Console.BackgroundColor = ConsoleColor.Red;
                                    Console.Write('@');
                                    lab1[playerPoint.X, playerPoint.Y] = ' ';
                                    lab1[playerPoint.X, playerPoint.Y + 1] = '@';
                                    //DrawLabirynth(playerPoint, lab1);
                                    playerPoint = getPlayerCoordinates(lab1);
                                    Console.SetCursorPosition(0, 31);
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.BackgroundColor = ConsoleColor.Red;
                                    Console.Write("Monety: " + coins + "/10");
                                    CheckCoins(coins, lab1,10);
                                }
                            break;

                        case ConsoleKey.DownArrow:
                        if (lab1[playerPoint.X+1, playerPoint.Y ] == '!' && coins == 10)
                        {
                            LevelEndScreen(2);
                        }
                        else if(lab1[playerPoint.X + 1, playerPoint.Y] != '!' && lab1[playerPoint.X + 1, playerPoint.Y] != '#')
                        if (lab1[playerPoint.X + 1, playerPoint.Y] != 'X')
                            {
                                if (lab1[playerPoint.X + 1, playerPoint.Y] == '$')
                                {
                                    coins++;
                                }
                                Console.SetCursorPosition(playerPoint.Y, playerPoint.X);
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(' ');
                                Console.SetCursorPosition(playerPoint.Y, playerPoint.X + 1);
                                Console.ForegroundColor = ConsoleColor.Red;
                                //Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write('@');
                                lab1[playerPoint.X, playerPoint.Y] = ' ';
                                lab1[playerPoint.X + 1, playerPoint.Y] = '@';
                                //DrawLabirynth(playerPoint, lab1);
                                playerPoint = getPlayerCoordinates(lab1);
                                Console.SetCursorPosition(0, 31);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("Monety: " + coins + "/10");
                                CheckCoins(coins, lab1,10);
                            }
                            break;

                        case ConsoleKey.LeftArrow:
                            if (lab1[playerPoint.X, playerPoint.Y - 1] != 'X')
                            {
                                if (lab1[playerPoint.X, playerPoint.Y - 1] == '$')
                                {
                                    coins++;
                                }
                                Console.SetCursorPosition(playerPoint.Y, playerPoint.X);
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(' ');
                                Console.SetCursorPosition(playerPoint.Y - 1, playerPoint.X);
                                Console.ForegroundColor = ConsoleColor.Red;
                                //Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write('@');
                                lab1[playerPoint.X, playerPoint.Y] = ' ';
                                lab1[playerPoint.X, playerPoint.Y - 1] = '@';
                                //DrawLabirynth(playerPoint, lab1);
                                playerPoint = getPlayerCoordinates(lab1);
                                Console.SetCursorPosition(0, 31);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.Write("Monety: " + coins + "/10");
                                CheckCoins(coins, lab1,10);
                            }
                            break;
                    }
                }
                MenuScreen();
        }

        static void SetColors()
        {       
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear(); //Important!
        }

        static void SetWindowSize()
        {
            
            Console.SetBufferSize(60,40);
            Console.SetWindowSize(32,34);
        }

        static void SetWindow()
        {
            Console.SetWindowPosition(0,0);   
            Console.OutputEncoding = Encoding.UTF8;
            SetColors();
            SetWindowSize();
            Console.Title = "Labirynth Game";
        }

        static void ChooseLevelScreen()
        {
            Console.Clear();
            SetWindow();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            int option = 8;
            Console.Write("+-----------------------------+\n");
            Console.Write("|                             |\n");
            Console.Write("|    LABIRYNTH GAME           |\n");
            Console.Write("|        by Pawel Borowski    |\n");
            Console.Write("|                             |\n");
            Console.Write("+-----------------------------+\n");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            //Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(0, 8);
            Console.Write("*");
            Console.SetCursorPosition(2, 8);
            Console.Write("Level 1");
            Console.SetCursorPosition(2, 9);
            Console.Write("Level 2");
            Console.SetCursorPosition(2, 10);
            Console.Write("Back");
            Console.SetCursorPosition(0, 8);
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (option > 8)
                        {
                            Console.SetCursorPosition(0, option);
                            Console.Write(" ");
                            Console.SetCursorPosition(0, option - 1);
                            Console.Write("*");
                            option--;
                        }
                        break;

                    case ConsoleKey.Enter:
                        switch (Console.CursorTop)
                        {
                            case 8:
                                Level1();
                                break;
                            case 9:
                                Leve2();
                                break;
                            case 10:
                                //back
                                MenuScreen();
                                break;
                        }

                        break;

                    case ConsoleKey.DownArrow:
                        if (option < 10)
                        {
                            Console.SetCursorPosition(0, option);
                            Console.Write(" ");
                            Console.SetCursorPosition(0, option + 1);
                            Console.Write("*");
                            option++;
                        }
                        break;

                }

            }

        }

        static void MenuScreen()
        {
            Console.Clear();
            SetWindow();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor=ConsoleColor.Yellow;
            int option = 8;
            Console.Write("+-----------------------------+\n");
            Console.Write("|                             |\n");
            Console.Write("|    LABIRYNTH GAME           |\n");
            Console.Write("|        by Pawel Borowski    |\n");
            Console.Write("|                             |\n");
            Console.Write("+-----------------------------+\n");
            Console.BackgroundColor = ConsoleColor.DarkGray;
            //Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(0, 8);
            Console.Write("*");
            Console.SetCursorPosition(2,8);
            Console.Write("New Game");
            Console.SetCursorPosition(2, 9);
            Console.Write("Choose Level");
            Console.SetCursorPosition(2, 10);
            Console.Write("Exit");
            Console.SetCursorPosition(0, 8);
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (option > 8)
                        {
                            Console.SetCursorPosition(0, option);
                            Console.Write(" ");
                            Console.SetCursorPosition(0,option-1);
                            Console.Write("*");
                            option--;
                        }
                        break;

                    case ConsoleKey.Enter:
                        switch (Console.CursorTop)
                        {
                            case 8:
                                Level1();
                                break;
                            case 9:
                                ChooseLevelScreen();
                                break;
                            case 10:
                                //exit
                                Environment.Exit(0);
                                break;
                        }
                            
                        break;

                    case ConsoleKey.DownArrow:
                        if (option < 10)
                        {
                            Console.SetCursorPosition(0, option);
                            Console.Write(" ");
                            Console.SetCursorPosition(0, option + 1);
                            Console.Write("*");
                            option++;
                        }
                        break;

                }

            }
        }

        static void LevelEndScreen(int previousLevel) //wyświetlanie ekranu końca gry
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            IntPtr hCurrentWindow = Process.GetCurrentProcess().MainWindowHandle;
            Graphics g = Graphics.FromHwnd(hCurrentWindow);
            g.DrawRectangle(new Pen(Color.Red, 3), 22, 22, 400, 100);
            g.Dispose();
            Console.SetCursorPosition(3, 3);
            //Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (previousLevel == 1)
            {
                Console.Write("UKONCZYLES POZIOM 1! :)");
                Console.SetCursorPosition(12, 7);
                Console.Write("next =>");
                ConsoleKeyInfo keyInfo;
                while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.RightArrow:
                            Leve2();
                            break;
                    }
                }
            }
            else
            {
                Console.Write("ZWYCIESTWO! :)");
                Console.SetCursorPosition(15, 8);
                Console.Write("menu =>");
                ConsoleKeyInfo keyInfo;
                while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                {
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.RightArrow:
                            MenuScreen();
                            break;
                    }
                }
            }
            
            Console.ReadLine();
        }

        static Point getPlayerCoordinates(char[,] lab1) //odnajdowanie położenia gracza
        {
            Point p = new Point();
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (lab1[i, j] == '@')
                    {
                        p.X = i;
                        p.Y = j;
                    }
                }
            }
            return p;
        }
        static Point[] getFinishCoordinates(char[,] lab1) //odnajdowanie położenia mety
        {
            Point[] tab = new Point[2];
            int ind=0;
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    if (lab1[i, j] == '!')
                    {
                        
                        tab[ind] = new Point(i, j);
                        ind++;
                    }
                }
            }
            return tab;
        }


        static void DrawLabirynth(Point playerPoint, char[,] lab1) //rysowanie labiryntu w konsoli
        {
            Console.Clear();
            
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 30; j++)
                {
                    switch (lab1[i, j])
                    {
                        case '@':
                            //Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Red;
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
                        case '!':
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            break;
                        case '$':
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.BackgroundColor = ConsoleColor.White;
                            break;
                        case '#':
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.BackgroundColor= ConsoleColor.DarkCyan;
                            break;
                    }
                    Console.Write(lab1[i, j]);
                }
                Console.Write("\n");
            }
        }
        static char[,] LoadLabirynth(int id) //odczyt labiryntu z pliku tekstowego
        {
            char[,] LabirynthOne = new char[30, 30];

            char [,]LabirynthTwo = new char[30,30];

            try
            {
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
                                currentChar = 'X';//'\u2181';
                                break;
                            case '0':
                                currentChar = ' ';
                                break;
                            case 'X': //gracz
                                currentChar = '@';
                                break;
                            case '!':
                                currentChar = '!';
                                break;
                            case '$':
                                currentChar = '$';
                                break;
                            default:
                                currentChar = '&';
                                break;
                        }
                        if (currentChar != '&')
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
                            b++;
                        }
                    }
                }
            }
            catch
            {
                
            }
            
            try
            {
                using (StreamReader readtext = new StreamReader("C:\\Users\\Pawel\\repozytoria\\LabirynthRepo\\Labirynth\\Labirynth\\labirynth2.txt"))
                {
                    string Map = readtext.ReadToEnd();
                    int a = 0, b = 0;
                    char currentChar;
                    for (int i = 0; i < Map.Length; i++)
                    {

                        switch (Map[i])
                        {
                            case '1': //ściana
                                currentChar = 'X';//'\u2181';
                                break;
                            case '0':
                                currentChar = ' ';
                                break;
                            case 'X': //gracz
                                currentChar = '@';
                                break;
                            case '!':
                                currentChar = '!';
                                break;
                            case '$':
                                currentChar = '$';
                                break;
                            case '#':
                                currentChar = '#';
                                break;
                            default:
                                currentChar = '&';
                                break;
                        }
                        if (currentChar != '&')
                        {
                            if (a < 29)
                            {
                                if (b < 30)
                                {
                                    LabirynthTwo[a, b] = currentChar;
                                }
                                else
                                {
                                    b = 0;
                                    LabirynthTwo[a, b] = currentChar;
                                    a++;

                                }
                            }
                            else
                            {
                                if (a == 29)
                                {
                                    if (b < 30)
                                    {
                                        LabirynthTwo[a, b] = currentChar;
                                    }
                                }
                            }
                            b++;
                        }
                    }
                }
            }
            catch
            {
                
            }
           
            if (id == 1)
            {
                return LabirynthOne;
            }
            else
            {
                return LabirynthTwo;
            }
        }
    }
}
