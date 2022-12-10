using System;
using System.Xml.Linq;

namespace Slot_Machine
{
    public class Player
    {
        public string Name { get; private set; }
        public int Balance;

        public Player()
        {
            string name = ConsoleUtility.ReadString("Please enter a name:");
            Name = name;
            Console.Clear();
            int balance = ConsoleUtility.ReadInt("Please enter a balance:", 0);
            Balance = balance;
            Console.Clear();
        }
    }
}
