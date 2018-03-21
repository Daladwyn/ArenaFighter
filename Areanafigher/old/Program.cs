using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Areanafigher
{
    class Program
    {
       
        /// <summary>
        /// Function that prints the collected data of which round and turn and which combatant dealt what amount of damage  
        /// </summary>
        /// <param name="printLog recieves a list"></param>
        //static void PrintBattleLog(List<string> deadGladiators, int numberOfVictories, int isPlayerGladiatorRetired, List<string> printLog)
        //{
        //    foreach (string deadOpponent in deadGladiators)
        //    {
        //        Console.WriteLine("You have vanquished: {0}", deadOpponent);
        //    }
        //    Console.WriteLine("Your score is: {0}", numberOfVictories + isPlayerGladiatorRetired);
        //    for (int element = 0; printLog.Count > element; element = element + 4)
        //    {
        //        Console.Write("\nBattleround: {0}\tBattleturn: {1}\tFighter: {2} does {3} damage.", printLog[element], printLog[element + 1], printLog[element + 2], printLog[element + 3]);
        //    }
        //}
        static void Main(string[] args)
        {
            //Variable initiations
            string chosenGladiatorName = "", illegalMenuChoise = "n";
            int menuOption = 0 ;
            
            //List<string> vanquishedOpponents = new List<string>();
            //List<string> battleLog = new List<>();
            
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
                Console.WriteLine("You have {0} wins so far", playersGladiator.numberOfVictories);
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
                        Console.WriteLine("BATTLE!!!!!");
                        Battle battle = new Battle();
                        battle.FightABattle(playersGladiator);
                        break;
                    case 2://this choise is if the player wish to retire the gladiator
                        playersGladiator.retirePlayerGladiator = "y";
                        break;
                    case 3: //this choise shows the stats of the gladiator and the opponent
                        Console.WriteLine("Your gladiator {0} have a weaponskill of {1},strenght of {2}, toughness of {3}, wounds equal to {4} and {5} victories.", playersGladiator.gladiatorName, playersGladiator.weaponskill, playersGladiator.strenght, playersGladiator.toughness, playersGladiator.startingWounds, playersGladiator.numberOfVictories);
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
            } while (playersGladiator.retirePlayerGladiator != "y" && playersGladiator.isPlayerGladdiatorDead != "y");//end if the players gladiator is retired or if the gladiator is dead
            if (playersGladiator.numberOfVictories == 0 && playersGladiator.isPlayerGladdiatorDead == "y")//if the gladiator didnt manage to win any battlerounds and died
            {
                Console.WriteLine("You did not manage to win any battles at the Arena, better luck next time!");
            }
            else if (playersGladiator.numberOfVictories >= 1 && playersGladiator.isPlayerGladdiatorDead == "y")//if the player gladiator won atleast one round but have died
            {
                Console.WriteLine($"Your gladiator {playersGladiator.gladiatorName} has won {playersGladiator.numberOfVictories} matches over the following gladiators:");
                //PrintBattleLog(vanquishedOpponents, numberOfVictories, 1, battleLog);//print out the result for each round and turn and who did how much damage
                Console.ReadLine();
            }
            else
            if (playersGladiator.retirePlayerGladiator == "y" && playersGladiator.isPlayerGladdiatorDead == "n")//if the players gladiator is alive and retired
            {
                Console.WriteLine($"Your gladiator {playersGladiator.gladiatorName} has retired and won {playersGladiator.numberOfVictories} matches over the following gladiators:");
                //PrintBattleLog(vanquishedOpponents, numberOfVictories, 1, battleLog);//print out the result for each round and turn and who did how much damage
            }
            Console.ReadLine();
        }
    }
}
