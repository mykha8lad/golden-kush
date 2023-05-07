using GoldenKush.Elements.Container;
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

    static Selection TitleScreen { get; } = new(new[]
    {
        Spin,
        @"
█▀▀ ▀▄▀ █ ▀█▀
██▄ █░█ █ ░█░",
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
        if (selection == Spin)
        {
            
        }
    }
}
