using BattleArena.Items;
using BattleArena.Pawn;
using BattleArena.Singleton;
using BattleArena.Observer;
using System;

namespace BattleArena
{
    class Program
    {
        static void Main(string[] args)
        {
            Log log = Log.GetInstanceStatic;
            Equip equipment = new Equip();
            Achievements subscriber = new Achievements();

            UserIO userinteraction = new UserIO();

            Random randomNumberGenerator = new Random();

            /// generate/initialize playerslist by loop to be flexible for number of players
            /// this way player names are assigned before weapon initialization (necessary for logging)
            /// choice of weapon outsourced to class Equip
            /// player can be subscribed with their health values
            int numberOfHeroes = 2;
            Hero[] playerList = new Hero[numberOfHeroes];
            for (int i = 0; i < numberOfHeroes; ++i)
            {
                string player = $"Player {i}";
                log.GetPlayerName(player);
                playerList[i] = new Hero(player, equipment.EquipHero(randomNumberGenerator));
                subscriber.Subscribe(player, playerList[i].Health);
            }

            
            bool run = true;

            while (run)
            {
                userinteraction.ClearScreen();
                userinteraction.PrintPlayerInformation(playerList);

                foreach (Hero currentHero in playerList)
                {
                    // Additional information for logging.
                    log.GetPlayerName(currentHero.Name);        
                    bool action = false;
                    do
                    {
                        int userinput = -1;
                        do
                        {
                            userinteraction.PrintFightMenu(currentHero.Name);
                            userinput = userinteraction.GetUserIput();
                        } while (userinput < 0 || userinput > 5);

                        switch (userinput)
                        {
                            case 0:
                                // Exit game.
                                run = false;
                                userinteraction.ExitGame();
                                log.PrintLogFile();
                                return;
                            case 1:
                                if (currentHero.Name == "Player 1")
                                {
                                    action = currentHero.Action(playerList[1]);
                                }
                                else
                                {
                                    action = currentHero.Action(playerList[0]);
                                }
                                break;

                            case 2:
                                action = currentHero.AddLeprechaun();
                                break;
                            case 3:
                                action = currentHero.AddTinyGoblin(randomNumberGenerator);
                                break;
                            case 4:
                                action = currentHero.AddMediumGoblin(randomNumberGenerator);
                                break;
                            case 5:
                                action = currentHero.AddBigGoblin(randomNumberGenerator);
                                break;

                            default:
                                break;
                        }

                        if (!action)
                        {
                            userinteraction.ClearScreen();
                            userinteraction.PrintPlayerInformation(playerList);
                            Console.WriteLine("\nNot enought money");
                        }
                    } while (!action);

                    currentHero.UpdateCoins();

                    if (currentHero.Name == "Player 1")
                    {
                        currentHero.UseGoblins(playerList[1]);
                    }
                    else
                    {
                        currentHero.UseGoblins(playerList[0]);
                    }
                    
                    // Get damage to notify and log data.
                    subscriber.GetEnumCompareValue(currentHero.Name, currentHero.Health);
                }

                // End condition.
                if (playerList[0].Health <= 0)
                {
                    userinteraction.EndGame(playerList[0].Name);
                    run = false;
                }
                else if (playerList[1].Health <= 0)
                {
                    userinteraction.EndGame(playerList[1].Name);
                    run = false;
                }                
            }
        }
    }
}
