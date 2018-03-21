using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Areanafigher
{
    class Battle
    {
        string opposingGladiatorNameIs;
        int battleNumber;
        Gladiator opposingGladiator = new Gladiator();

        public Battle()
        {
            opposingGladiatorNameIs = opposingGladiator.gladiatorName;
            battleNumber = 1;
        }
        
        
        //private static Random aDice = new Random();
        //battleRound = 1
        //string
        //Gladiator opposingGladiator = new Gladiator();

        public void FightABattle(Gladiator playersGladiator)
        {
            Round round = new Round();
            do
            {
                round.FightARound(playersGladiator, opposingGladiator);
            }
            while (playersGladiator.currentWounds > 0 || opposingGladiator.currentWounds > 0);
            
        }
    }
        /////// <summary>
        /////// Function that generates a random number between 1 and 6
        /////// </summary>
        /////// <returns>A random value</returns>
        ////public int RollADie() { return (aDice.Next(1, 7)); }
    }