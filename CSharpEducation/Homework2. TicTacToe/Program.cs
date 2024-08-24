using System;

class Program
{
    static void Main()
    {
        char[] map = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        int players = 1;
        int result = 0;
        int changeCourse;


        while (result == 0)
        {
        result = Win();
        if (result == 1)
        {
            Console.WriteLine("Победа игрока X");
        }
        else if (result == 2)
        {
            Console.WriteLine("Победа игрока 0");
        }
        else if (result == -1)
        {
            Console.WriteLine("Ничья");
        }
            if (result != 0) { break; }

            Console.Clear();
            Console.WriteLine("Игра Крестики нолики 1 игрок - X, 2 игрок - 0");
            Console.WriteLine();
            DrawMap();


            Console.Write($"Игрок {players}, выберите клетку: ");
            changeCourse = Convert.ToInt32(Console.ReadLine()) - 1;

            if (changeCourse < 0 || changeCourse > 8 || map[changeCourse] == 'X' || map[changeCourse] == '0' || Convert.ToString(changeCourse) == "")
            {
                Console.WriteLine("Данный ход невозможен, попробуй другой");
                Console.ReadLine();
                continue;
            }

            map[changeCourse] = players == 1 ? 'X' : '0';
            players = (players % 2) + 1;
        }


        void DrawMap()
        {
            Console.WriteLine($" {map[0]} | {map[1]} | {map[2]}");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {map[3]} | {map[4]} | {map[5]}");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {map[6]} | {map[7]} | {map[8]}");
        }


        int Win()
        {
            int[,] rulesWin =
            {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 },
            { 0, 3, 6 },
            { 1, 4, 7 },
            { 2, 5, 8 },
            { 0, 4, 8 },
            { 2, 4, 6 },
            };

            for (int i = 0; i < rulesWin.GetLength(0); i++)
            {
                if (map[rulesWin[i, 0]] == 'X' && map[rulesWin[i, 1]] == 'X' && map[rulesWin[i, 2]] == 'X')
                {
                    return 1;
                }
                else if (map[rulesWin[i, 0]] == '0' && map[rulesWin[i, 1]] == '0' && map[rulesWin[i, 2]] == '0')
                {
                    return 2;
                }
            }
            return 0;
        }
    }
}