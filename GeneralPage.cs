using GoldenKush.Elements;
using GoldenKush.Selections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GoldenKush;

internal class GeneralPage
{
    string logo = @"
░██████╗░░█████╗░██╗░░░░░██████╗░███████╗███╗░░██╗  ██╗░░██╗██╗░░░██╗░██████╗██╗░░██╗
██╔════╝░██╔══██╗██║░░░░░██╔══██╗██╔════╝████╗░██║  ██║░██╔╝██║░░░██║██╔════╝██║░░██║
██║░░██╗░██║░░██║██║░░░░░██║░░██║█████╗░░██╔██╗██║  █████═╝░██║░░░██║╚█████╗░███████║
██║░░╚██╗██║░░██║██║░░░░░██║░░██║██╔══╝░░██║╚████║  ██╔═██╗░██║░░░██║░╚═══██╗██╔══██║
╚██████╔╝╚█████╔╝███████╗██████╔╝███████╗██║░╚███║  ██║░╚██╗╚██████╔╝██████╔╝██║░░██║
░╚═════╝░░╚════╝░╚══════╝╚═════╝░╚══════╝╚═╝░░╚══╝  ╚═╝░░╚═╝░╚═════╝░╚═════╝░╚═╝░░╚═╝";

    string textByInfo = @"
This application was developed by a techie
named Mykhailichenko Vlad. Unfortunately, or maybe 
fortunately, Golden Kush will not help you choose
a good cannabis variety, Golden Kush is something
nice, but if you still decide to combine nice
with pleasure, write and drop your ideas here -->

Press Enter to return";

    string linkByInfo = @"
    Press G to open GitHub

    Press T to open Telegram

    Press I to open Instagram
";


    // Balance
    static InputSelection BalanceSettings { get; } = new(new Dictionary<string, string>
    {
        {"Balance", $"{Game.Balance}"},
        {"Rate", $"{Game.Rate}"},
    }, (20, 7));

    static void ParseBalanceSettings(Dictionary<string, string> settings)
    {
        var styles =
            NumberStyles.AllowThousands |
            NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite;

        if (int.TryParse(settings["Balance"],
            styles,
            null,
            out int balance)) Game.Balance = balance;

        if (int.TryParse(settings["Rate"],
            styles,
            null,
            out int rate)) Game.Rate = rate;
    }

    void DisplayLogo()
    {
        var logoByLine = logo.Split('\n');
        for (int i = 0; i < logoByLine.Length; i++)
        {
            Console.SetCursorPosition(18, 3 + i);
            Console.WriteLine(logoByLine[i]);
        }
    }

    // Info
    void DisplayLink()
    {
        var linkByColumn = linkByInfo.Split('\n');
        for (int i = 0; i < linkByColumn.Length; i++)
        {
            Console.SetCursorPosition(80, 8 + i);
            Console.WriteLine(linkByColumn[i]);
        }
    }

    void DisplayInfo()
    {
        var textInfo = textByInfo.Split('\n');
        for (int i = 0; i < textInfo.Length; i++)
        {
            Console.SetCursorPosition(18, 5 + i);
            Console.WriteLine(textInfo[i]);
        }

        DisplayLink();

        ConsoleKeyInfo keyInfo;
        do
        {
            keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.G)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("https://github.com/mykha8lad") { UseShellExecute = true });
            }
            if (keyInfo.Key == ConsoleKey.T)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("https://t.me/@xyzenok") { UseShellExecute = true });
            }
            if (keyInfo.Key == ConsoleKey.I)
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo("https://instagram.com/pepelnatelo?igshid=ZGUzMzM3NWJiOQ==") { UseShellExecute = true });
            }
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                return;
            }
        } while (keyInfo.Key != ConsoleKey.Escape);

        Console.Read();
    }

    // Menu
    Selection TitleScreen { get; } = new(new[]
    {
        "Play",
        "Balance",
        "Info",
    }, (57, 16));

    public void Start()
    {
        Console.CursorVisible = false;
        Console.Clear();
        if (OperatingSystem.IsWindows())
        {
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.Title = "Golden Kush";
        }
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        DisplayLogo();
        Console.ResetColor();

        var selection = TitleScreen.StartYLine();

        if (selection == null) return;
        if (selection == "Play")
        {
            Console.Clear();
            Game.Start();
            Start();
        }
        else if (selection == "Info")
        {
            Console.Clear();
            DisplayInfo();
            Start();
        }
        else if (selection == "Balance")
        {
            Console.Clear();
            var balanceSettings = BalanceSettings.Start();
            ParseBalanceSettings(balanceSettings);
            Start();
        };
    }
}
