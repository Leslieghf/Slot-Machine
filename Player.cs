using System;
using System.Xml.Linq;

namespace Slot_Machine
{
    public class Player
    {
        #region Properties
        public string Name { get; private set; }
        #endregion

        #region Fields
        public int Balance;
        #endregion

        #region Constructors
        public Player()
        {
            string name = ConsoleUtility.ReadString("Please enter a name:");
            Name = name;
            Console.Clear();
            int balance = ConsoleUtility.ReadInt("Please enter a balance:", 0);
            Balance = balance;
            Console.Clear();
        }
        #endregion
    }
}
