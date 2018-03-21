using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arenafighter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variable initiations
            string chosenGladiatorName = "", illegalMenuChoise = "n";
            int menuOption = 0;

            //Print out welcome message and rules for the Arena
            Console.WriteLine("Welcome to the ARENA!");
            Console.WriteLine("In this game you get a generated gladiator that will fight other gladiators to the death. After a fight you will ");
            Console.WriteLine("be asked if you would like to retire your gladiator. If you retire your gladiator or if your gladiator");
            Console.WriteLine("perishes in the arena the game ends, and you get a score based on how many fights your gladiator survived.");
            Console.WriteLine("Good Luck!");
            do
            {//Here the player is to choose a name that contains letters or numbers.
                Console.Write("\nWhat would you like to name your Gladiator: ");
                chosenGladiatorName = Console.ReadLine();
                if (chosenGladiatorName == "")
                {
                    Console.WriteLine("You must type in a name.");
                }
            } while (chosenGladiatorName == "");
            //Create the players gladiator and assign the name choosen
            Gladiator playersGladiator = new Gladiator(chosenGladiatorName);
            do
            {//here is the ingame menu
                Console.Clear();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Fight in the arena.");
                Console.WriteLine("2. Retire your Gladiator");
                Console.WriteLine("3. Check your Gladiators stats");
                Console.WriteLine("You have {0} wins so far", playersGladiator.NumberOfVictories);
                menuOption = 0;
                //if text is given as answear a message is given that a number is required
                try { menuOption = Convert.ToInt32(Console.ReadLine()); }
                catch (FormatException)
                {
                    illegalMenuChoise = "y";
                    Console.WriteLine("Indecision will have you killed in the Arena. Please type a number.");
                    Console.ReadLine();
                }
                switch (menuOption) //here starts which option should be run based on which choise in the menu.
                {
                    case 1://Here starts a battle between the player and a to be generated gladiator
                        Console.Clear();
                        Console.WriteLine("BATTLE!!!!!");
                        Battle playerBattle = new Battle();
                        Console.WriteLine($"Battle {playersGladiator.BattleNumber}");
                        playerBattle.FightABattle(playersGladiator);
                        playersGladiator.BattleNumber++;
                        break;
                    case 2://this choise is if the player wish to retire the gladiator
                        playersGladiator.RetirePlayerGladiator = "y";
                        break;
                    case 3: //this choise shows the stats of the gladiator
                        Console.WriteLine("Your gladiator {0} have a weaponskill of {1},strenght of {2}, toughness of {3}, wounds equal to {4} and {5} victories.", playersGladiator.GladiatorName, playersGladiator.Weaponskill, playersGladiator.Strenght, playersGladiator.Toughness, playersGladiator.StartingWounds, playersGladiator.NumberOfVictories);
                        Console.ReadLine();
                        break;
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 0:
                        if (illegalMenuChoise == "y")// this is to prevent dubble messages that the menuchoise is not a number
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("This choise will get you killed in the Arena. Make another choise.");
                            Console.ReadLine();
                            break;
                        }
                    default:
                        break;
                }
            } while (playersGladiator.RetirePlayerGladiator != "y" && playersGladiator.IsPlayerGladdiatorDead != "y");//end if the players gladiator is retired or if the gladiator is dead

            if (playersGladiator.NumberOfVictories == 0 && playersGladiator.IsPlayerGladdiatorDead == "y")//if the gladiator didnt manage to win any battlerounds and died
            {
                Console.WriteLine("You did not manage to win any battles at the Arena, better luck next time!\nYour score is: 0.");
            }
            else if (playersGladiator.NumberOfVictories >= 1 && playersGladiator.IsPlayerGladdiatorDead == "y")//if the player gladiator won atleast one round but have died
            {
                Console.WriteLine($"Your gladiator {playersGladiator.GladiatorName} has won {playersGladiator.NumberOfVictories} matches over the following gladiators:");
                playersGladiator.PrintSlainOpponents(playersGladiator.SlainOpponents);
                Console.ReadLine();
            }
            else
            if (playersGladiator.RetirePlayerGladiator == "y" && playersGladiator.IsPlayerGladdiatorDead == "n")//if the players gladiator is alive and retired
            {
                Console.WriteLine($"Your gladiator {playersGladiator.GladiatorName} has retired and won {playersGladiator.NumberOfVictories} matches over the following gladiators:");
                playersGladiator.PrintSlainOpponents(playersGladiator.SlainOpponents);
            }
            Console.ReadLine();
        }
    }
}
