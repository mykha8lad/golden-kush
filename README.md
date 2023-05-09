# __Golden Kush__ :slot_machine::moneybag:
## Golden Kush is a console application created for entertainment purposes, in the context of the __Casino__. The application was written by me as a term paper on the subject "Microsoft .NET Platform and C# Language Programming".
# __Diagram Golden Kush Project__
[![photo-2023-05-09-13-06-17.jpg](https://i.postimg.cc/m2hvQHDh/photo-2023-05-09-13-06-17.jpg)](https://postimg.cc/zVZ2N3T1)
# __Project Structure__
[![8.jpg](https://i.postimg.cc/bYgxXqbj/8.jpg)](https://postimg.cc/Rq36K5XP)
# __Project Map__ :world_map:
> # [<span style="color:red;">Project.cs</span>](https://github.com/mykha8lad/golden-kush/blob/main/Program.cs)
> # [<span style="color:red;">GeneralPage.cs</span>](https://github.com/mykha8lad/golden-kush/blob/main/GeneralPage.cs)
> # [<span style="color:red;">Game.cs</span>](https://github.com/mykha8lad/golden-kush/blob/main/Game.cs)
> # Elements :file_folder:
>> # Container :file_folder:
>>> # [<span style="color:red;">Box.cs</span>](https://github.com/mykha8lad/golden-kush/blob/main/Elements/Container/Box.cs)
>>> # [<span style="color:red;">Utilities.cs</span>](https://github.com/mykha8lad/golden-kush/blob/main/Elements/Container/Utilities.cs)
>> # Slots :file_folder:
>>> # [<span style="color:red;">ConcreteSlot.cs</span>](https://github.com/mykha8lad/golden-kush/blob/main/Elements/Slots/ConcreteSlot.cs)
>>> # [<span style="color:red;">ISlot.cs</span>](https://github.com/mykha8lad/golden-kush/blob/main/Elements/Slots/ISlot.cs)
>>> # [<span style="color:red;">ISlotFactory.cs</span>](https://github.com/mykha8lad/golden-kush/blob/main/Elements/Slots/ISlotFactory.cs)
>>> # [<span style="color:red;">RowCreator.cs</span>](https://github.com/mykha8lad/golden-kush/blob/main/Elements/Slots/RowCreator.cs)
> # Selections :file_folder:
>> # [<span style="color:red;">InputSelection.cs</span>](https://github.com/mykha8lad/golden-kush/blob/main/Selections/InputSelection.cs)
>> # [<span style="color:red;">Selection.cs</span>](https://github.com/mykha8lad/golden-kush/blob/main/Selections/Selection.cs)
## When opening the application, we see a menu window that looks like this
[![1.jpg](https://i.postimg.cc/g04G4LC5/1.jpg)](https://postimg.cc/R36rZhVQ)
## The welcome window has three menu items
* ### Play
* ### Balance
* ### Info
## Let's start with __Info__. By clicking on it, we will see an information window providing information about the author and the application. There are also additional key handlers that allow you to navigate to certain resources when you click to interact with the author
[![2.jpg](https://i.postimg.cc/63hQG10k/2.jpg)](https://postimg.cc/njCxy2N2)
## In the __Balance__ menu item, the user has the opportunity to change the balance and the bet value, which affects the winning odds
[![3.jpg](https://i.postimg.cc/qvcW0VvH/3.jpg)](https://postimg.cc/3kRtCqGt)
___
## Now let's move on to the most interesting, to the __Play__ menu item. When pressed, a window opens, which is the main gaming area, in which we can highlight information about the user's balance, as well as the rate. Below the window are three slots and an impromptu gaming lever. There are also two options for directly starting the game, and exiting back to the main menu. As well as instructions for navigation.
[![4.jpg](https://i.postimg.cc/9QTwQb6h/4.jpg)](https://postimg.cc/sMjgnYf6)
[![5.jpg](https://i.postimg.cc/sXfMKrvj/5.jpg)](https://postimg.cc/NyVGfZ6S)
## When you click the __Spin__ item, a session is launched that spins random numbers, and then these values are processed by the algorithm, including the bet. The win rate is calculated.
[![6.jpg](https://i.postimg.cc/sg6fyhXr/6.jpg)](https://postimg.cc/gxhbHr8S)
# We can observe the balance change in the session window itself.
[![7.jpg](https://i.postimg.cc/JnT55K7F/7.jpg)](https://postimg.cc/BLKFqTK5)
# Hope you find this interesting
