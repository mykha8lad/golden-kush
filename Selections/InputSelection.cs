using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenKush.Selections;

class InputSelection
{
    KeyValuePair<string, string>[] Selections { get; }
    int Index { get; set; } = 0;
    (int x, int y) Offset { get; set; }

    internal InputSelection(Dictionary<string, string> selection, (int x, int y) offset)
    {
        Selections = selection.ToArray();
        Offset = offset;
    }

    internal Dictionary<string, string> Start()
    {
        var (x, y) = Offset;

        for (int i = 0; i < Selections.Length; i++)
        {
            Console.SetCursorPosition(x, y + i);
            Console.Write(Selections.GetKVPString(i));
        }

        Console.SetCursorPosition(x, y + Selections.Length + 1);
        Console.Write("Press Tab to input.");

        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("> " + Selections.GetKVPString(0));

        while (true)
        {
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.DownArrow)
            {
                if (Index == Selections.Length - 1) continue;

                Console.ResetColor();
                Console.SetCursorPosition(x, y + Index);
                Console.Write(Selections.GetKVPString(Index) + "  ");

                Index++;

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(x, y + Index);
                Console.Write("> " + Selections.GetKVPString(Index));
            }
            else if (key == ConsoleKey.UpArrow)
            {
                if (Index == 0) continue;

                Console.ResetColor();
                Console.SetCursorPosition(x, y + Index);
                Console.Write(Selections.GetKVPString(Index) + "  ");

                Index--;

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(x, y + Index);
                Console.Write("> " + Selections.GetKVPString(Index));
            }
            else if (key == ConsoleKey.Enter || key == ConsoleKey.X)
            {
                Console.ResetColor();
                Index = 0;
                return Selections
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            }
            else if (key == ConsoleKey.Tab)
            {
                Console.SetCursorPosition(x, y + Selections.Length);
                Console.Write("Input: ");

                var input = Console.ReadLine();

                Console.SetCursorPosition(x, y + Selections.Length);
                Console.Write("       " +
                    " ".Repeat(input is null ? 0 : input.Length));

                if (input is null) continue;

                var kvp = Selections[Index];

                Console.SetCursorPosition(x, y + Index);
                Console.Write(" ".Repeat(
                    Selections.GetKVPString(Index).Length + 2
                    ));

                Selections[Index] = new KeyValuePair<string, string>(kvp.Key, input);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.SetCursorPosition(x, y + Index);
                Console.Write("> " + Selections.GetKVPString(Index));
            }
        }
    }
}
