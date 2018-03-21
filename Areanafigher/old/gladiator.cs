using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Areanafigher
{
    class Gladiator
    {
        public string retirePlayerGladiator , isPlayerGladdiatorDead ;
        static private InfoGenerator nameGeneration = new InfoGenerator(DateTime.Now.Millisecond);
        public string gladiatorName;
        public int weaponskill , strenght ,toWound , currentWounds, startingWounds, toughness, numberOfVictories;
        static Random aDice = new Random();

        public Gladiator()
        {
            gladiatorName = nameGeneration.NextFullName();
            weaponskill = RollADie();
            strenght = RollADie();
            toughness = RollADie();
            startingWounds = (currentWounds = RollADie());
            retirePlayerGladiator = "n";
            isPlayerGladdiatorDead = "n";
            numberOfVictories = 0;

        }
        public Gladiator(string characterName) : this() { gladiatorName = characterName; }

        public Gladiator NewGladiator()
        {
            Gladiator newFreshGladiator = new Gladiator();
            return newFreshGladiator;
        }

        public int RollADie() { return (aDice.Next(1, 7)); }
    }
}
