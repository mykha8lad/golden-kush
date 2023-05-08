using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenKush.Elements.Slots;

public interface ISlotFactory
{
    ISlot CreateSlot();
}

/*public class StrawberrySlotFactory : ISlotFactory
{
    public ISlot CreateSlot()
    {
        return new StrawberrySlot();
    }
}

public class PineappleSlotFactory : ISlotFactory
{
    public ISlot CreateSlot()
    {
        return new PineappleSlot();
    }
}

public class СherrySlotFactory : ISlotFactory
{
    public ISlot CreateSlot()
    {
        return new СherrySlot();
    }
}

public class DrainSlotFactory : ISlotFactory
{
    public ISlot CreateSlot()
    {
        return new DrainSlot();
    }
}

public class SevenSlotFactory : ISlotFactory
{
    public ISlot CreateSlot()
    {
        return new SevenSlot();
    }
}*/

