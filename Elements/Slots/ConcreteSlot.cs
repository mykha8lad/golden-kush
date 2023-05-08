using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenKush.Elements.Slots;

public class StrawberrySlot : ISlot
{
    public void Display()
    {
        Console.Write("1\t\t\t\t");
    }
}

public class PineappleSlot : ISlot
{
    public void Display()
    {
        Console.Write("2\t\t\t\t");
    }
}

public class СherrySlot : ISlot
{
    public void Display()
    {
        Console.Write("2\t\t\t\t");
    }
}

public class DrainSlot : ISlot
{
    public void Display()
    {
        Console.Write("3\t\t\t\t");
    }
}

public class SevenSlot : ISlot
{
    public void Display()
    {
        Console.Write("4\t\t\t\t");
    }
}
