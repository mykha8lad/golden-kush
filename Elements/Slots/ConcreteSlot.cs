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
        Console.WriteLine("Strawberry");
    }
}

public class PineappleSlot : ISlot
{
    public void Display()
    {
        Console.WriteLine("Pineapple");
    }
}

public class СherrySlot : ISlot
{
    public void Display()
    {
        Console.WriteLine("Cherry");
    }
}

public class DrainSlot : ISlot
{
    public void Display()
    {
        Console.WriteLine("Drain");
    }
}

public class SevenSlot : ISlot
{
    public void Display()
    {
        Console.WriteLine("Seven");
    }
}
