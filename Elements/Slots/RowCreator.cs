using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldenKush.Elements.Slots;

class CasinoObjectFactory : ISlotFactory
{
    public ISlot CreateSlot()
    {
        // Генерируем случайное число для выбора объекта
        Random random = new Random();
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
    public void CreateRows()
    {
        ISlotFactory factory = new CasinoObjectFactory();

        List<ISlot> allObjects = new List<ISlot>();
        
        for (int i = 0; i < 3; i++)
        {
            ISlot obj = factory.CreateSlot();
            allObjects.Add(obj);
        }

        foreach (var item in allObjects)
        {
            ISlot obj = item;
            item.Display();
        }
    }
}
