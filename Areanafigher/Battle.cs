using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arenafighter
{
    class Battle
    {
        public Battle()
        {
        }

        internal string OpposingGladiatorName { get; set; }

        public void FightABattle(Gladiator playersGladiator)
        {
            Gladiator opposingGladiator = new Gladiator(); //create a new gladiator
            playersGladiator.SlainOpponents.Add(opposingGladiator.GladiatorName); //store the name of opposing gladiator so a message can be printed of eventual wins or losses.
            Round round = new Round();
            do
            {
                round.FightARound(playersGladiator, opposingGladiator);
                if (playersGladiator.CurrentWounds <= 0) //if the players gladiator dies you get a message of the lost fight
                {
                    Console.WriteLine($"Oh No!! You lost to {opposingGladiator.GladiatorName}!!");
                    playersGladiator.IsPlayerGladdiatorDead = "y";
                    Console.ReadLine();
                }
                else if (opposingGladiator.CurrentWounds <= 0) //if the generated gladiator dies you get a message of your win
                {
                    Console.WriteLine($"You won against {opposingGladiator.GladiatorName}!! Congratulations!!");
                    playersGladiator.NumberOfVictories++;
                    playersGladiator.CurrentWounds = playersGladiator.StartingWounds;//the players hitpoints is restored
                    opposingGladiator.IsPlayerGladdiatorDead = "y";
                    Console.ReadLine();
                }
            } while (playersGladiator.IsPlayerGladdiatorDead == "n" && opposingGladiator.IsPlayerGladdiatorDead == "n");
        }
    }
}