using System;

namespace Slot_Machine
{
    public class GameMode
    {
        public readonly string Name;
        public readonly int MinBet;
        public readonly int MaxBet;
        public readonly float BetMultiplier;
        public readonly float WinProbability;

        public GameMode(string name, int minBet, int maxBet, float betMultiplier, float winProbability)
        {
            Name = name;
            MinBet = minBet;
            MaxBet = maxBet;
            BetMultiplier = betMultiplier;
            WinProbability = winProbability;
        }

        public void PlayRound(SlotMachine host, Player player, out bool playAgain)
        {
            Console.Clear();
            int bet = ReadPlayerBet(player);
            Console.WriteLine("Spinning...\n");
            int[] reels = new int[3];
            bool playerWon;
            
            Random random = new Random();
            int randomNumber = random.Next(0, 100);
            if (randomNumber < (host.SelectedGameMode.WinProbability * 100))
            {
                reels[0] = random.Next(0, 10);
                reels[1] = reels[0];
                reels[2] = reels[0];
                playerWon = true;
            }
            else
            {
                reels[0] = random.Next(0, 10);
                do
                {
                    reels[1] = random.Next(0, 10);
                } while (reels[1] == reels[0]);
                do
                {
                    reels[2] = random.Next(0, 10);
                } while (reels[2] == reels[1]);
                playerWon = false;
            }
            
            Console.WriteLine($"{reels[0]} {reels[1]} {reels[2]}\n");
            if (playerWon)
            {
                int winnings = (int)(bet * host.SelectedGameMode.BetMultiplier);
                Console.WriteLine($"You won {winnings}!\n");
                player.Balance += winnings;
            }
            else
            {
                Console.WriteLine($"You lost {bet}!\n");
                player.Balance -= bet;
            }
            Console.WriteLine("Press any key to continue!");
            Console.ReadKey();
            Console.Clear();
            
            if (player.Balance < MinBet)
            {
                Console.WriteLine("You do not have enough money anymore to play this Game Mode!\n");
                Console.WriteLine("Press any key to continue!");
                Console.ReadKey();
                Console.Clear();
                playAgain = false;
                return;
            }
            
            bool replay = ConsoleUtility.ReadBool("Do you want to play again?");
            if (replay)
            {
                Console.Clear();
                playAgain = true;
            }
            else
            {
                Console.WriteLine("Thank you for playing!\n");
                Console.WriteLine("Press any key to continue!");
                Console.ReadKey();
                Console.Clear();
                playAgain = false;
            }
        }

        private int ReadPlayerBet(Player player)
        {
            Console.Clear();
            do
            {
                int bet = ConsoleUtility.ReadInt($"Please enter a bet between {MinBet} and {MaxBet}:", MinBet, MaxBet);
                if (bet <= player.Balance)
                {
                    Console.Clear();
                    return bet;
                }
                Console.WriteLine("You don't have enough money!");
                Console.ReadKey();
                Console.Clear();
            } while (true);
        }

        public override string ToString()
        {
            return $"{Name}:\n\t Min Bet: {MinBet}\t\t Max Bet: {MaxBet}\t\t Win Multiplier: {BetMultiplier}\t\t Win Probability: {WinProbability}";
        }
    }
}
