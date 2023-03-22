using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenKush
{
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

        internal string? Start()
        {
            var (x, y) = Offset;

            for (int i = 0; i < SelectionsArray.Length; i++)
            {
                Console.SetCursorPosition(x, y + i);                
                Console.Write(SelectionsArray[i]);
            }

            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Cyan;            
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

                    Console.ForegroundColor = ConsoleColor.Cyan;
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

                    Console.ForegroundColor = ConsoleColor.Cyan;
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
    }
}
