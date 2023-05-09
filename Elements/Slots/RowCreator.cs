using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;

namespace GoldenKush.Elements.Slots;

class CasinoObjectFactory : ISlotFactory
{
    public ISlot CreateSlot()
    {
        Random random = new();
        int objectIndex = random.Next(0, 4);

        switch (objectIndex)
        {
            case 0:
                return new StrawberrySlot();
            case 1:
                return new PineappleSlot();
            case 2:
                return new СherrySlot();
            case 3:
                return new DrainSlot();
            case 4:
                return new SevenSlot();
            default:
                throw new ArgumentException("Invalid object index");
        }
    }
}

public class RowCreator
{
    public void CreateRows(ref double balance, ref double rate, int index)
    {
        ISlotFactory factory = new CasinoObjectFactory();
        double totalSum = rate / 2;
        double itemSum = 0;
        List<ISlot> allObjects = new List<ISlot>();
        Random random = new();
        int randomInt = random.Next(20);

        for (int i = 0; i < 3; i++)
        {
            ISlot obj = factory.CreateSlot();
            allObjects.Add(obj);
        }

        foreach (var item in allObjects)
        {
            Console.Write($"{item.Display()}\t\t\t\t");
            if (index == 9) itemSum += item.Display();
        }

        if (index == 9)
        {
            balance -= rate;
            if (rate < 9) itemSum -= 5;
            balance += totalSum += itemSum;

            if (randomInt % 3 == 0) balance -= 3;
        }
    }
}
