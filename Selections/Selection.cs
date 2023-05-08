using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenKush.Selections;

internal class Selection
{
    string[] SelectionsArray { get; }
    int Index { get; set; } = 0;
    (int x, int y) Offset { get; set; }

    internal Selection(string[] selection, (int x, int y) offset)
    {
        SelectionsArray = selection;
        Offset = offset;
    }

    internal string? StartYLine()
    {
        var (x, y) = Offset;

        for (int i = 0; i < SelectionsArray.Length; i++)
        {
            Console.SetCursorPosition(x, y + i);
            Console.Write(SelectionsArray[i]);
        }

        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("> " + SelectionsArray[0]);

        while (true)
        {
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.DownArrow)
            {
                if (Index == SelectionsArray.Length - 1) continue;

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(x, y + Index);
                Console.Write(SelectionsArray[Index] + "  ");

                Index++;

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(x, y + Index);
                Console.Write("> " + SelectionsArray[Index]);
            }
            else if (key == ConsoleKey.UpArrow)
            {
                if (Index == 0) continue;

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(x, y + Index);
                Console.Write(SelectionsArray[Index] + "  ");

                Index--;

                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.SetCursorPosition(x, y + Index);
                Console.Write("> " + SelectionsArray[Index]);
            }
            else if (key == ConsoleKey.Enter || key == ConsoleKey.X)
            {
                Console.ResetColor();
                var i = Index;
                Index = 0;
                return key == ConsoleKey.Enter ? SelectionsArray[i]
                    : null;
            }
        }
    }
    internal string? StartXLine()
    {
        var (x, y) = Offset;
        int k = 0;
        int j = 0;

        for (int i = 0; i < SelectionsArray.Length; i++)
        {
            Console.SetCursorPosition(x + i + k, y);
            Console.Write(SelectionsArray[i]);
            k += 20;
        }

        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("> " + SelectionsArray[0]);

        while (true)
        {
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.DownArrow)
            {
                if (Index == SelectionsArray.Length - 1) continue;

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(x + j, y);
                Console.Write(SelectionsArray[Index] + "  ");

                Index++;
                j += 20;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(x + j, y);
                Console.Write("> " + SelectionsArray[Index]);
            }
            else if (key == ConsoleKey.UpArrow)
            {
                if (Index == 0) continue;

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(x + j, y);
                Console.Write(SelectionsArray[Index] + "  ");

                Index--;
                j -= 20;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(x + j, y);
                Console.Write("> " + SelectionsArray[Index]);
            }
            else if (key == ConsoleKey.Enter || key == ConsoleKey.X)
            {
                Console.ResetColor();
                var i = Index;
                Index = 0;
                return key == ConsoleKey.Enter ? SelectionsArray[i]
                    : null;
            }
        }
    }
    internal string? StartBigLine()
    {
        var (x, y) = Offset;
        int k = 0;
        int j = 0;

        for (int i = 0; i < SelectionsArray.Length; i++)
        {
            Console.SetCursorPosition(x + i + k, y);
            var show = SelectionsArray[i].Split('\n');
            for (int item = 0; item < show.Length; item++)
            {
                Console.SetCursorPosition(43, 20 + item);
                Console.WriteLine(show[item]);
            }
            k += 20;
        }

        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        var show2 = SelectionsArray[0].Split('\n');
        for (int item = 0; item < show2.Length; item++)
        {
            Console.SetCursorPosition(43, 20 + item);
            Console.WriteLine(show2[item]);
        }

        while (true)
        {
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.RightArrow)
            {
                if (Index == SelectionsArray.Length - 1) continue;

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(x + j, y);
                var show3 = SelectionsArray[Index].Split('\n');
                for (int item = 0; item < show3.Length; item++)
                {
                    Console.SetCursorPosition(43, 20 + item);
                    Console.WriteLine(show3[item]);
                }

                Index++;
                j += 20;

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(x + j, y);
                var show4 = SelectionsArray[Index].Split('\n');
                for (int item = 0; item < show4.Length; item++)
                {
                    Console.SetCursorPosition(43, 20 + item);
                    Console.WriteLine(show4[item]);
                }
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                if (Index == 0) continue;

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(x + j, y);
                var show5 = SelectionsArray[Index].Split('\n');
                for (int item = 0; item < show5.Length; item++)
                {
                    Console.SetCursorPosition(43, 20 + item);
                    Console.WriteLine(show5[item]);
                }

                Index--;
                j -= 20;

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(x + j, y);
                var show6 = SelectionsArray[Index].Split('\n');
                for (int item = 0; item < show6.Length; item++)
                {
                    Console.SetCursorPosition(43, 20 + item);
                    Console.WriteLine(show6[item]);
                }
                Console.ResetColor();
            }
            else if (key == ConsoleKey.Enter || key == ConsoleKey.X)
            {
                var i = Index;
                Index = 0;
                return key == ConsoleKey.Enter ? SelectionsArray[i]
                    : null;
            }
        }
    }
}
