using System;

namespace GenericGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Room Game!");
            RoomGame game = new RoomGame();

            System.Console.WriteLine("Navigate the different rooms.  CTRL-C to quit:");
            while(true) {
                game.ChooseRoom();
            }
        }
    }
}
