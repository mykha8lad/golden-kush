using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenKush.Elements.Slots;

public class StrawberrySlot : ISlot
{
    public double Display() => 1;
}

public class PineappleSlot : ISlot
{
    public double Display() => 2;
}

public class СherrySlot : ISlot
{
    public double Display() => 3;
}

public class DrainSlot : ISlot
{
    public double Display() => 4;
}

public class SevenSlot : ISlot
{
    public double Display() => 5;
}
