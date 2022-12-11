using System;

namespace Slot_Machine
{
    public static class ConsoleUtility
    {
        #region Static Methods
        public static void WriteEnum<TEnum>() where TEnum : struct, Enum
        {
            Console.WriteLine($"\nAvailable {typeof(TEnum).Name}s");
            foreach (string enumEntryName in Enum.GetNames(typeof(TEnum)))
            {
                Console.WriteLine($"\t{enumEntryName}");
            }
        }
        
        public static TEnum ReadEnum<TEnum>(string message = "")where TEnum : struct, Enum
        {
            SelectEnum:
            WriteEnum<TEnum>();
            if (message == "")
            {
                Console.WriteLine($"\nPlease enter a valid {typeof(TEnum).Name}:");
            }
            else
            {
                Console.WriteLine(message);
            }
            string? consoleInput = Console.ReadLine();
            bool parseEnumSuccess = Enum.TryParse(consoleInput, out TEnum parsedEnum);
            if (!parseEnumSuccess)
            {
                Console.WriteLine("\nInvalid input, retry!\n");
                goto SelectEnum;
            }
            return parsedEnum;
        }

        public static int ReadInt(string message, int min = int.MinValue, int max = int.MaxValue)
        {
            if (message != "")
            {
                message = message + "\n";
            }
            do
            {
                if (message != "")
                {
                    Console.WriteLine(message);
                }
                string? consoleInput = Console.ReadLine();
                if (int.TryParse(consoleInput, out int inputInt) && inputInt >= min && inputInt <= max)
                {
                    return inputInt;
                }
                Console.WriteLine("\nInvalid input, retry!\n");
            } while (true);
        }

        public static long ReadLong(string message, long min = long.MinValue, long max = long.MaxValue)
        {
            if (message != "")
            {
                message = message + "\n";
            }
            do
            {
                if (message != "")
                {
                    Console.WriteLine(message);
                }
                string? consoleInput = Console.ReadLine();
                if (long.TryParse(consoleInput, out long inputLong) && inputLong >= min && inputLong <= max)
                {
                    return inputLong;
                }
                Console.WriteLine("\nInvalid input, retry!\n");
            } while (true);
        }

        public static float ReadFloat(string message, float min = float.MinValue, float max = float.MaxValue)
        {
            if (message != "")
            {
                message = message + "\n";
            }
            do
            {
                if (message != "")
                {
                    Console.WriteLine(message);
                }
                string? consoleInput = Console.ReadLine();
                if (float.TryParse(consoleInput, out float inputFloat) && inputFloat >= min && inputFloat <= max)
                {
                    return inputFloat;
                }
                Console.WriteLine("\nInvalid input, retry!\n");
            } while (true);
        }

        public static double ReadDouble(string message, double min = double.MinValue, double max = double.MaxValue)
        {
            if (message != "")
            {
                message = message + "\n";
            }
            do
            {
                if (message != "")
                {
                    Console.WriteLine(message);
                }
                string? consoleInput = Console.ReadLine();
                if (double.TryParse(consoleInput, out double inputDouble) && inputDouble >= min && inputDouble <= max)
                {
                    return inputDouble;
                }
                Console.WriteLine("\nInvalid input, retry!\n");
            } while (true);
        }

        public static bool ReadBool(string message)
        {
            if (message != "")
            {
                message = message + "\n";
            }
            do
            {
                if (message != "")
                {
                    Console.WriteLine(message);
                }
                char consoleInput = ReadChar("'y' for yes, 'n' for no", 'n', 'y');
                if ((char)consoleInput == 'y')
                {
                    return true;
                }
                if ((char)consoleInput == 'n')
                {
                    return false;
                }
            } while (true);
        }

        public static string ReadString(string message)
        {
            if (message != "")
            {
                message = message + "\n";
            }
            do
            {
                if (message != "")
                {
                    Console.WriteLine(message);
                }
                string? consoleInput = Console.ReadLine();
                if (consoleInput != null && consoleInput != "")
                {
                    return consoleInput;
                }
                Console.WriteLine("\nInvalid input, retry!\n");
            } while (true);
        }

        public static char ReadChar(string message)
        {
            if (message != "")
            {
                message = message + "\n";
            }
            do
            {
                if (message != "")
                {
                    Console.WriteLine(message);
                }
                string? consoleInput = Console.ReadLine();
                if (consoleInput != null && consoleInput.Length == 1)
                {
                    return consoleInput[0];
                }
                Console.WriteLine("\nInvalid input, retry!\n");
            } while (true);
        }

        public static char ReadChar(string message, params char[] validChars)
        {
            if (message != "")
            {
                message = message + "\n";
            }
            do
            {
                if (message != "")
                {
                    Console.WriteLine(message);
                }
                string? consoleInput = Console.ReadLine();
                if (consoleInput != null && consoleInput.Length == 1)
                {
                    foreach (char validChar in validChars)
                    {
                        if (consoleInput[0] == validChar)
                        {
                            return consoleInput[0];
                        }
                    }
                }
                Console.WriteLine("\nInvalid input, retry!\n");
            } while (true);
        }

        public static Action ReadAction(string[] descriptions, Action[] actions)
        {
            if (descriptions.Length != actions.Length)
            {
                throw new ArgumentException("The description and action arrays must be of the same length!");
            }
            
            do
            {
                Console.WriteLine("Please select an action:\n");
                for (int i = 0; i < descriptions.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {descriptions[i]}");
                }
                Console.WriteLine();
                int actionIndex = ReadInt("", 1, descriptions.Length) - 1;
                if (actionIndex >= 0 && actionIndex <= descriptions.Length)
                {
                    return actions[actionIndex];
                }
                Console.WriteLine("\nInvalid input, retry!\n");
            } while (true);
        }
        #endregion
    }
}
