using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenKush
{
    internal class GeneralPage
    {
        private string logo = @"
░██████╗░░█████╗░██╗░░░░░██████╗░███████╗███╗░░██╗  ██╗░░██╗██╗░░░██╗░██████╗██╗░░██╗
██╔════╝░██╔══██╗██║░░░░░██╔══██╗██╔════╝████╗░██║  ██║░██╔╝██║░░░██║██╔════╝██║░░██║
██║░░██╗░██║░░██║██║░░░░░██║░░██║█████╗░░██╔██╗██║  █████═╝░██║░░░██║╚█████╗░███████║
██║░░╚██╗██║░░██║██║░░░░░██║░░██║██╔══╝░░██║╚████║  ██╔═██╗░██║░░░██║░╚═══██╗██╔══██║
╚██████╔╝╚█████╔╝███████╗██████╔╝███████╗██║░╚███║  ██║░╚██╗╚██████╔╝██████╔╝██║░░██║
░╚═════╝░░╚════╝░╚══════╝╚═════╝░╚══════╝╚═╝░░╚══╝  ╚═╝░░╚═╝░╚═════╝░╚═════╝░╚═╝░░╚═╝";

        private void DisplayLogo()
        {
            var logoByLine = logo.Split('\n');
            for (int i = 0; i < logoByLine.Length; i++)
            {
                Console.SetCursorPosition(18, 3 + i);
                Console.WriteLine(logoByLine[i]);
            }
        }

        private Selection TitleScreen { get; } = new(new[]
        {
            "Play",
            "Settings",
            "Info",
            "Balance"
        }, (55, 13));
         
        public void Start()
        {
            Console.CursorVisible = false;
            Console.Clear();
            if (OperatingSystem.IsWindows())
                Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            DisplayLogo();

            var selection = TitleScreen.Start();

            if (selection == null) return;
            if (selection == "Play")
            {
                Box.Start();
                Box.ResetGame();
                Start();
            }
            else if (selection == "Settings")
            {
                Console.Clear();
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
}
