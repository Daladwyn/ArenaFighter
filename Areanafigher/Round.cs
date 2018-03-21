using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arenafighter
{
    class Round
    {
        private int RoundNumber { get; set; }
        private static Random aDice = new Random();

        public Round()
        {
            RoundNumber = 1;
        }

        public void FightARound(Gladiator playersGladiator, Gladiator opposingGladiator)
        {
            do
            { //print to console the characteristics of the two fighters
                Console.WriteLine($"\nBattle {playersGladiator.BattleNumber} Battleturn {RoundNumber}:");
                Console.WriteLine($"Your gladiator {playersGladiator.GladiatorName} \nweaponskill of {playersGladiator.Weaponskill}\nstrenght of {playersGladiator.Strenght}\ntoughness of {playersGladiator.Toughness}\nwounds equal to {playersGladiator.CurrentWounds}\nNumber of victories {playersGladiator.NumberOfVictories} victories.");
                Console.WriteLine($"\nOpposing gladiator is {opposingGladiator.GladiatorName}\nweaponskill of {opposingGladiator.Weaponskill}\nstrenght of {opposingGladiator.Strenght}\ntoughness of {opposingGladiator.Toughness}\nwounds equal to {opposingGladiator.CurrentWounds}.\n");
                opposingGladiator.CurrentWounds = CombatResult(playersGladiator, opposingGladiator);
                playersGladiator.CurrentWounds = CombatResult(opposingGladiator, playersGladiator);
                RoundNumber++;
                Console.ReadKey();
            } while ((playersGladiator.CurrentWounds > 0) && (opposingGladiator.CurrentWounds > 0));
        }
        /// <summary>
        /// Function that generates a random number between 1 and 6
        /// </summary>
        /// <returns>A random value</returns>
        private int RollADie() { return (aDice.Next(1, 7)); }

        /// <summary>
        /// Function that resolves a round of combat.
        /// </summary>
        /// <param name="aggressor is the fighter who tries to strike"></param>
        /// <param name="defender is the fighter that recives eventual damage"></param>
        /// <returns>The returning value is number of wounds the defender recives.</returns>
        private int CombatResult(Gladiator aggressor, Gladiator defender)
        {
            int hitRoll = RollADie(); // a random number is generated
            if (hitRoll <= aggressor.Weaponskill) //if generated number is less or equal to the agressors weaponskill damage is dealt
            {
                int causedWoundsToDefender = 0, damageToDefender;
                Console.WriteLine($"{aggressor.GladiatorName} strikes {defender.GladiatorName} as {hitRoll} is less or equal to {aggressor.GladiatorName}s weaponskill of {aggressor.Weaponskill}.");
                damageToDefender = aggressor.Strenght + RollADie(); //agressors damage is determined 
                Console.WriteLine($"{aggressor.GladiatorName} does {damageToDefender} damage to {defender.GladiatorName}");
                if ((causedWoundsToDefender = damageToDefender - defender.Toughness) < 0) //if aggressors damage is not enough to go throu defenders toughness no damage is done.
                {
                    Console.WriteLine($"{aggressor.GladiatorName} did not do enough damage as {defender.GladiatorName} toughness of {defender.Toughness} was greater than the inflicted damage.");
                    return defender.CurrentWounds;
                }
                else //if Aggressors damage is greater than defenders toughness damage is done.
                {
                    Console.WriteLine($"{defender.GladiatorName} have {defender.Toughness} in toughness and reduce number of wounds taken to {causedWoundsToDefender}.");
                    if ((defender.CurrentWounds <= causedWoundsToDefender) && defender.CurrentWounds == 1) //if defender have 1 remaining wound in which case a "s" will not be added to Wound in the message to player.
                    {
                        Console.WriteLine($"As {defender.GladiatorName} currently have {defender.CurrentWounds} wound and recives {causedWoundsToDefender} damage, {defender.GladiatorName} will perish");
                        defender.CurrentWounds = defender.CurrentWounds - causedWoundsToDefender;
                        return defender.CurrentWounds;
                    }
                    else if ((defender.CurrentWounds <= causedWoundsToDefender) && defender.CurrentWounds > 1)//If defender have more than 1 wound remaining a "s" will be added to wound in the message to the player.
                    {
                        Console.WriteLine($"As {defender.GladiatorName} currently have {defender.CurrentWounds} wounds and recives {causedWoundsToDefender} damage, {defender.GladiatorName} will perish");
                        defender.CurrentWounds = defender.CurrentWounds - causedWoundsToDefender;
                        return defender.CurrentWounds;
                    }
                    else if ((defender.CurrentWounds - causedWoundsToDefender) == 1)//if defender after damage is dealt have 1 remaining wound a "s" will not be added to Wound in the message to player.
                    {
                        Console.WriteLine($"As {defender.GladiatorName} currently have {defender.CurrentWounds} wounds and recives {causedWoundsToDefender} damage, {defender.GladiatorName} have {defender.CurrentWounds = defender.CurrentWounds - causedWoundsToDefender} wound remaining.");
                        return defender.CurrentWounds;
                    }
                    else if ((defender.CurrentWounds - causedWoundsToDefender) > 1) //if defender after damage is dealt have more than 1 remaining wound a "s" will be added to Wound in the message to player.
                    {
                        Console.WriteLine($"As {defender.GladiatorName} currently have {defender.CurrentWounds} wounds and recives {causedWoundsToDefender} damage, {defender.GladiatorName} have {defender.CurrentWounds = defender.CurrentWounds - causedWoundsToDefender} wounds remaining.");
                        return defender.CurrentWounds;
                    }
                }
                return defender.CurrentWounds;
            }
            else //if aggressors hitroll was more than aggressors weaponskill.
            {
                Console.WriteLine($"{aggressor.GladiatorName} did not manage to hit {defender.GladiatorName} and no damage was caused.");
                return defender.CurrentWounds;
            }
        }

    }
}

