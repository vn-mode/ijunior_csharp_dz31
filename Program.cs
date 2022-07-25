using System;

namespace vn_mode_csharp_dz31
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            bool isPlaying = true;
            char user = '@';
            int userX = 5, userY = 5;
            int userDX = 0, userDY = 0;
            string[,] map;
            DrawMap(out map);

            while (isPlaying)
            {
                Console.SetCursorPosition(userY, userX);
                Console.Write(user);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:
                            userDX = -1; userDY = 0;
                            break;
                        case ConsoleKey.DownArrow:
                            userDX = 1; userDY = 0;
                            break;
                        case ConsoleKey.LeftArrow:
                            userDX = 0; userDY = -1;
                            break;
                        case ConsoleKey.RightArrow:
                            userDX = 0; userDY = 1;
                            break;
                    }
                    if (map[userX + userDX, userY + userDY] != "#")
                    {
                        Console.SetCursorPosition(userY, userX);
                        Console.Write(" ");
                        userX += userDX;
                        userY += userDY;
                        Console.SetCursorPosition(userY, userX);
                        Console.Write(user);
                    }
                }
            }
            
            static void DrawMap(out string[,] map)
            {
                    string[,] tempMap = new string[,]
                {
                    { "#","#","#","#","#","#","#","#","#","#"},
                    { "#"," "," "," "," "," "," "," "," ","#"},
                    { "#","#","#","#","#","#","#"," ","#","#"},
                    { "#"," "," "," "," "," "," "," "," ","#"},
                    { "#","#"," ","#","#","#","#","#","#","#"},
                    { "#","#"," "," "," "," "," "," "," ","#"},
                    { "#","#"," ","#","#"," "," "," "," ","#"},
                    { "#","#"," ","#"," ","#","#","#","#","#"},
                    { "#"," "," "," "," "," "," "," "," ","#"},
                    { "#","#","#","#","#","#","#","#","#","#"},
                };
                map = tempMap;
                for (int i = 0; i < map.GetLength(0); i++)
                {
                    for (int j = 0; j < map.GetLength(1); j++)
                    {
                        Console.Write(map[i, j]);
                    }
                    Console.WriteLine();
                }

            }

        }
    }
}

