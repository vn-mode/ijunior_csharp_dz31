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
            string wall = "#";
            int userPosX = 5;
            int userPosY = 5;

            string[,] map = CreateMap();
            DrawMap(map);

            while (isPlaying)
            {
                DrawUser(user, userPosX, userPosY);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    ChangeDirection(key, out int directionX, out int directionY);

                    if (CanMove(wall, map, userPosX, userPosY, directionX, directionY))
                    {
                        userPosX += directionX;
                        userPosY += directionY;
                    }
                }
            }
        }

        static void DrawUser(char user, int posX, int posY)
        {
            Console.SetCursorPosition(posY, posX);
            Console.Write(user);
        }

        static void ChangeDirection(ConsoleKeyInfo key, out int directionX, out int directionY)
        {
            directionX = 0;
            directionY = 0;

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    directionX = -1;
                    break;

                case ConsoleKey.DownArrow:
                    directionX = 1;
                    break;

                case ConsoleKey.LeftArrow:
                    directionY = -1;
                    break;

                case ConsoleKey.RightArrow:
                    directionY = 1;
                    break;
            }
        }

        static bool CanMove(string wall, string[,] map, int posX, int posY, int directionX, int directionY)
        {
            if (map[posX + directionX, posY + directionY] != wall)
            {
                Console.SetCursorPosition(posY, posX);
                Console.Write(" ");
                return true;
            }

            return false;
        }

        static string[,] CreateMap()
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
            return tempMap;
        }

        static void DrawMap(string[,] map)
        {
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
