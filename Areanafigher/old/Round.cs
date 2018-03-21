using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Areanafigher
{
    class Round
    {
        private int roundNumber, damageToPlayerGladiator, damageToOpponentGladiator, playersGladiatorHitRoll = 0, opposingGladiatorHitRoll = 0;
        private static Random aDice = new Random();

        public Round()
        {
            roundNumber = 1;
        }

        public void FightARound(Gladiator playersGladiator, Gladiator opposingGladiator)
        {
            for (int battleTurn = 1; (playersGladiator.currentWounds >= 1) && (opposingGladiator.currentWounds >= 1); battleTurn++)
            {
                Console.WriteLine($"Battleturn {battleTurn}:");
                playersGladiatorHitRoll = RollADie(); //both gladiators get a random number in their aim to hit their opponent
                opposingGladiatorHitRoll = RollADie();
                Console.WriteLine($"Your gladiator {playersGladiator.gladiatorName} have a weaponskill of {playersGladiator.weaponskill},strenght of {playersGladiator.strenght}, toughness of {playersGladiator.toughness}, wounds equal to {playersGladiator.startingWounds} and {playersGladiator.numberOfVictories} victories.");
                Console.WriteLine($"Opposing gladiator is {opposingGladiator.gladiatorName} and have a weaponskill of {opposingGladiator.weaponskill},strenght of {opposingGladiator.strenght}, toughness of {opposingGladiator.toughness}, wounds equal to {opposingGladiator.startingWounds}.");

                CombatResult(playersGladiator, opposingGladiator, playersGladiatorHitRoll);
                CombatResult(opposingGladiator, playersGladiator, opposingGladiatorHitRoll);

                if (playersGladiator.currentWounds < 1) //if the players gladiator dies you get a message
                {
                    Console.WriteLine("Oh No!! You lost to {0}!!", opposingGladiator.gladiatorName);
                    playersGladiator.isPlayerGladdiatorDead = "y";
                    Console.ReadLine();
                }
                else if (opposingGladiator.currentWounds < 1) //if the generated gladiator dies you get a message
                {
                    Console.WriteLine("You won against {0}!! Congratulations!!", opposingGladiator.gladiatorName);
                    playersGladiator.numberOfVictories++;
                    playersGladiator.currentWounds = playersGladiator.startingWounds;//the players hitpoints is restored
                                                                                     //battleRound++;
                    Console.ReadLine();
                    //vanquishedOpponents.Add(opposingGladiator.gladiatorName);//add the name of dead opponent to a list 
                    //opposingGladiator = CreateNewGladiator();// create a new opponent
                }
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Function that generates a random number between 1 and 6
        /// </summary>
        /// <returns>A random value</returns>
        private int RollADie() { return (aDice.Next(1, 7)); }

        private void CombatResult(Gladiator aggressor, Gladiator defender, int hitRoll)
        {
            if (aggressor.weaponskill >= hitRoll)
            {
                Console.WriteLine($"{aggressor.gladiatorName} strikes {defender.gladiatorName} as {playersGladiatorHitRoll} is less or equal to {aggressor.gladiatorName}s weaponskill of {aggressor.weaponskill}.");
                damageToOpponentGladiator = aggressor.strenght + RollADie();
                Console.WriteLine($"{aggressor.gladiatorName} does {damageToOpponentGladiator} damage to {defender.gladiatorName}");
                defender.currentWounds = defender.currentWounds - (defender.toughness - damageToOpponentGladiator);
                Console.WriteLine($"{defender.gladiatorName} have {defender.toughness} in toughness and reduce number of wounds taken to {defender.toughness - damageToOpponentGladiator}.");
                Console.WriteLine($"{defender.gladiatorName} have {defender.currentWounds} remaining");
            }
            else
            {
                Console.WriteLine($"{aggressor.gladiatorName} did not manage to hit {defender.gladiatorName} and no damage was caused.");
            }
        }

    }
}

