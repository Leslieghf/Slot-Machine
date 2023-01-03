using System;

namespace Slot_Machine
{
    public class SlotMachine
    {
        #region Properties
        public GameMode SelectedGameMode
        {
            get
            {
                return selectedGameMode;
            }
        }
        #endregion

        #region Fields
        private List<GameMode> availableGameModes;
        private GameMode selectedGameMode;
        private Player currentPlayer;
        #endregion

        #region Constructors
        public SlotMachine()
        {
            availableGameModes = new List<GameMode>();
            availableGameModes.Add(new GameMode("Starburst", 200, 10000, 10.0f, 0.1f));
            availableGameModes.Add(new GameMode("Book of Dead", 50, 2000, 4.0f, 0.25f));
            availableGameModes.Add(new GameMode("Gonzo's Quest", 5, 100, 2.5f, 0.4f));
            availableGameModes.Add(new GameMode("Book of Ra", 1, 50, 2.0f, 0.5f));
            currentPlayer = new Player();
            WriteMainMenuView();
        }
        #endregion

        #region Methods
        private void WriteMainMenuView()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the Slot Machine, {currentPlayer.Name}!\n");
            Console.WriteLine($"You current balance is: {currentPlayer.Balance}\n");
            SelectMainMenuOption();
            WriteGameMenuView();
        }

        private void WriteGameMenuView()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to {selectedGameMode.Name}, {currentPlayer.Name}!\n");
            string[] optionDescriptions = new string[] { "Play", "Change Game Mode", "Exit" };
            Action[] optionActions = new Action[] { Play, ChangeGameMode, Exit };
            Action selectedMenuAction = ConsoleUtility.ReadAction(optionDescriptions, optionActions);
            Console.Clear();
            selectedMenuAction();
        }

        private void WriteAvailableMainMenuOptions()
        {
            Console.WriteLine("Available options:\n");
            for (int i = 0; i < availableGameModes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableGameModes[i].Name}:\t\tMin Bet: {availableGameModes[i].MinBet}  |  Max Bet: {availableGameModes[i].MaxBet}");
            }
            Console.WriteLine($"{availableGameModes.Count + 1}. Quit Playing");
            Console.WriteLine();
        }

        private void SelectMainMenuOption()
        {
            WriteAvailableMainMenuOptions();
            do
            {
                int optionIndex = ConsoleUtility.ReadInt("Please select a valid Game Mode", 1, availableGameModes.Count + 1) - 1;
                if (optionIndex == (availableGameModes.Count))
                {
                    Console.WriteLine("\nThank you for playing!\n");
                    Console.WriteLine("Press any key to quit!");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                GameMode gameMode = availableGameModes[optionIndex];
                if (gameMode.MinBet <= currentPlayer.Balance)
                {
                    selectedGameMode = gameMode;
                    Console.WriteLine();
                    return;
                }
                Console.WriteLine("\nYou do not have enough money to play this Game Mode, retry!\n");
            } while (true);
        }

        private void Play()
        {
            bool playAgain;
            do
            {
                selectedGameMode.PlayRound(this, currentPlayer, out playAgain);
            } while (playAgain);
            WriteMainMenuView();
        }

        private void ChangeGameMode()
        {
            SelectMainMenuOption();
            WriteGameMenuView();
        }

        private void Exit()
        {
            WriteMainMenuView();
        }
        #endregion
    }
}
