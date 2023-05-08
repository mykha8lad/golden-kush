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
    internal static int Balance { get; set; } = 0;
    internal static int Rate { get; set; } = 3;
    internal static bool EnableDropProjection { get; set; } = true;

    static string Spin = @"
█▀ █▀█ █ █▄░█
▄█ █▀▀ █ █░▀█";
    static string Exit = @"
█▀▀ ▀▄▀ █ ▀█▀
██▄ █░█ █ ░█░";

    static Selection TitleScreen { get; } = new(new[]
    {
        Spin,
        Exit,
    }, (47, 23));

    static InputSelection BalanceSettings { get; } = new(new Dictionary<string, string>
    {
        {"Balance", "0"},
        {"Rate", "3"},
    }, (20, 7));

    internal static void Start()
    {
        Console.Clear();
        Box.DrawLineBoxes();
        Console.SetCursorPosition(18, 0);
        Console.WriteLine("To change the rate and balance, go to the \"Settings\" section");
        Console.SetCursorPosition(15, 3);
        Console.WriteLine($"Balance: {Balance}");
        Console.SetCursorPosition(73, 3);
        Console.WriteLine($"Rate: {Rate}");
        Console.SetCursorPosition(28, 24);
        Console.WriteLine("Use < and > on your keyboard to navigate");
        var selection = TitleScreen.StartBigLine();

        if (selection == null) return;
        if (selection == Spin && Balance > 0)
        {
            RowCreator rowCreator;
            for (int i = 0; i < 7; i++)
            {
                rowCreator = new();
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
                    rowCreator.CreateRows();
                    Thread.Sleep(10 * h);
                }
            }
            Balance -= Rate;
            Console.Read();
            if (selection == Exit) return;
            else Start();
        }        
    }
}
