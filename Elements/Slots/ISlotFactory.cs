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
