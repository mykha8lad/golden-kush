using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenKush
{
    internal static class Box
    {
        internal static int Width { get; set; } = 10;
        internal static int Height { get; set; } = 10;
        internal static double FallTime { get; set; } = 10;
        internal static bool EnableDropProjection { get; set; } = true;

        internal static (int x, int y) SideDisplayOffSet { get; } = (1, 0);    
        internal static bool IsDrawing { get; set; } = false;

        private static void DrawBox(
            int width, int height,
            int offsetX, int offsetY,
            string horizontal = "─", string vertical = "│",
            string ul_corner = "┌", string ur_corner = "┐",
            string ll_corner = "└", string lr_corner = "┘"
            )
        {
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
        }

        private static void DrawGameBoundaries()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            DrawBox(Width, Height, 0, 0);
            DrawBox(Width, Height, 23, 0);
            DrawBox(Width, Height, 46, 0);
        }

        internal static void Start()
        {
            ResizeWindow();
            Console.Clear();
            DrawGameBoundaries();
            DrawBackgroundBlocks(0);
        }

        static void ResizeWindow()
        {
            if (OperatingSystem.IsWindows())            
                Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
        }

        static void DrawBackgroundBlocks(int c)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < Height; i++)
            {
                Utilities.PlaceCursor(c, i);
                Console.Write("".Repeat(Width));
            }
        }

        internal static void ResetGame()
        {
            Console.Clear();
            Console.ResetColor();
            //Score = 0;
            /*IsDrawing = false;
            DroppedBlocks.Clear();*/
        }
    }
}
