using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GoldenKush.Elements.Container;

public static class Box
{
    static int Width { get; set; }
    static int Height { get; set; }
    static string leverArm = @"
####WWWWWWWWWWWWWWWW@@@@WWW
#+::@####@WWWWWWWWWW##*=@WW
#:+:#******WWWWWWW#***=@WWW
=:*:#*****=WWWWW@==**WWWWWW
*+*:#=***#:WW@+:+@WWWWWWWWW
*==:##=##*#:=+#WWWWWWWWWWWW
*=*:#*####***WWWWWWWWWWWWWW
=#+:#*****#WWWWWWWWWWWWWWWW
#=::#=====#WWWWWWWWWWWWWWWW
@*::@@##@WWWWWWWWWWWWWWWWWW
";

    public static void DrawBox(
        int width, int height,
        int offsetX, int offsetY,
        string horizontal = "─", string vertical = "│",
        string ul_corner = "┌", string ur_corner = "┐",
        string ll_corner = "└", string lr_corner = "┘"
        )
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.SetCursorPosition(offsetX, offsetY);
        Console.Write(ul_corner);
        Console.SetCursorPosition(width * 2 + offsetX + 1, offsetY);
        Console.Write(ur_corner);
        Console.SetCursorPosition(offsetX, height + offsetY + 1);
        Console.Write(ll_corner);
        Console.SetCursorPosition(width * 2 + offsetX + 1, height + offsetY + 1);
        Console.Write(lr_corner);

        Console.SetCursorPosition(offsetX + 1, offsetY);
        Console.Write(horizontal.Repeat(width * 2));
        Console.SetCursorPosition(offsetX + 1, height + offsetY + 1);
        Console.Write(horizontal.Repeat(width * 2));

        for (int i = offsetY; i < height + offsetY; i++)
        {
            Console.SetCursorPosition(offsetX, i + 1);
            Console.Write(vertical);
            Console.SetCursorPosition(width * 2 + offsetX + 1, i + 1);
            Console.Write(vertical);
        }
        Console.ResetColor();
    }

    static void DisplayLevelArm()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        leverArm = leverArm.Replace("W", " ");
        var stringByLine = leverArm.Split('\n');
        for (int i = 0; i < stringByLine.Length; i++)
        {
            Console.SetCursorPosition(91, 6 + i);
            Console.WriteLine(stringByLine[i]);
        }
        Console.ResetColor();
    }

    internal static void DrawLineBoxes()
    {
        DrawBox(13, 13, 7, 4);
        DrawBox(13, 13, 35, 4);
        DrawBox(13, 13, 63, 4);
        DisplayLevelArm();
    }
}
