using GoldenKush.Elements;
using GoldenKush.Selections;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenKush;

internal class GeneralPage
{
    private string logo = @"
░██████╗░░█████╗░██╗░░░░░██████╗░███████╗███╗░░██╗  ██╗░░██╗██╗░░░██╗░██████╗██╗░░██╗
██╔════╝░██╔══██╗██║░░░░░██╔══██╗██╔════╝████╗░██║  ██║░██╔╝██║░░░██║██╔════╝██║░░██║
██║░░██╗░██║░░██║██║░░░░░██║░░██║█████╗░░██╔██╗██║  █████═╝░██║░░░██║╚█████╗░███████║
██║░░╚██╗██║░░██║██║░░░░░██║░░██║██╔══╝░░██║╚████║  ██╔═██╗░██║░░░██║░╚═══██╗██╔══██║
╚██████╔╝╚█████╔╝███████╗██████╔╝███████╗██║░╚███║  ██║░╚██╗╚██████╔╝██████╔╝██║░░██║
░╚═════╝░░╚════╝░╚══════╝╚═════╝░╚══════╝╚═╝░░╚══╝  ╚═╝░░╚═╝░╚═════╝░╚═════╝░╚═╝░░╚═╝";

    // Settings
    static InputSelection BalanceSettings { get; } = new(new Dictionary<string, string>
    {
        {"Balance", "0"},
        {"Rate", "3"},
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
    // Settings

    private void DisplayLogo()
    {
        var logoByLine = logo.Split('\n');
        for (int i = 0; i < logoByLine.Length; i++)
        {
            Console.SetCursorPosition(18, 3 + i);
            Console.WriteLine(logoByLine[i]);
        }
    }

    // Menu
    private Selection TitleScreen { get; } = new(new[]
    {
        "Play",
        "Settings",
        "Info",
        "Balance"
    }, (55, 13));
    // Menu

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
        else if (selection == "Settings")
        {
            Console.Clear();
            var balanceSettings = BalanceSettings.Start();
            ParseBalanceSettings(balanceSettings);
            Start();
        }
        else if (selection == "Info")
        {
            Console.Clear();
            Start();
        }
        else if (selection == "Balance")
        {
            Console.Clear();
            Start();
        };
    }
}
