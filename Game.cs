using GoldenKush.Elements.Container;
using GoldenKush.Elements.Slots;
using GoldenKush.Selections;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GoldenKush;

internal static class Game
{
    internal static double Balance = 100;
    internal static double Rate = 3;
    internal static bool EnableDropProjection { get; set; } = true;

    static string Spin = @"
█▀ █▀█ █ █▄░█
▄█ █▀▀ █ █░▀█";
    static string Exit = @"
█▀▀ ▀▄▀ █ ▀█▀
██▄ █░█ █ ░█░";

    static string secondLogo = @"
         █▀▀ ▄▀█ █▀ █ █▄░█ █▀█
         █▄▄ █▀█ ▄█ █ █░▀█ █▄█

█▀▀ █▀█ █░░ █▀▀ █▀▀ █▄░█   █▀▀ █░█ █▀ █░█
█▄█ █▄█ █▄▄ █▄█ ██▄ █░▀█   █▄▄ █▄█ ▄█ █▀█";

    static Selection TitleScreen { get; } = new(new[]
    {
        Spin,
        Exit,
    }, (47, 23));

    internal static void Start()
    {
        Console.Clear();
        Box.DrawLineBoxes();

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.SetCursorPosition(29, 24);
        Console.WriteLine("Use < and > on your keyboard to navigate");
        Console.SetCursorPosition(15, 3);
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"Balance: {Balance:F2}");
        Console.SetCursorPosition(73, 3);
        Console.WriteLine($"Rate: {Rate}");
        Console.ForegroundColor = ConsoleColor.DarkYellow;

        var secondLogoByLine = secondLogo.Split('\n');
        for (int i = 0; i < secondLogoByLine.Length; i++)
        {
            Console.SetCursorPosition(74, 24 + i);
            Console.WriteLine(secondLogoByLine[i]);
        }
        Console.ResetColor();

        var selection = TitleScreen.StartBigLine();

        if (selection == null) return;
        if (selection == Spin && Balance > 0)
        {
            RowCreator rowCreator;
            rowCreator = new();
            for (int i = 0; i < 7; i++)
            {
                for (int h = 0; h < 10; h++)
                {
                    for (int f = 0; f < 3; f++)
                    {
                        int left = 8;
                        for (int j = 0; j < 26; j++)
                        {
                            Console.SetCursorPosition(left, 10);
                            Console.Write(" ");
                            left++;
                        }
                        left += 2;
                    }
                    Console.SetCursorPosition(17, 10);
                    rowCreator.CreateRows(ref Balance, ref Rate, h);
                    Thread.Sleep(10 * h);
                }
            }

            if (selection == Exit) return;
            else Start();
        }
    }
}
