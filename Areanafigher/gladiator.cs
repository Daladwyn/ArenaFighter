using Lexicon.CSharp.InfoGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Arenafighter
{

    class Gladiator
    {
        public Gladiator()
        {
            GladiatorName = nameGeneration.NextFullName();
            SlainOpponents = new List<string>();
            Weaponskill = RollADie();
            Strenght = RollADie();
            Toughness = RollADie();
            StartingWounds = (CurrentWounds = RollADie());
            RetirePlayerGladiator = "n";
            IsPlayerGladdiatorDead = "n";
            NumberOfVictories = 0;
            BattleNumber = 1;


        }
        public Gladiator(string characterName) : this() { GladiatorName = characterName; }

        //Here is the encapsulation of the variables
        static private InfoGenerator nameGeneration = new InfoGenerator(DateTime.Now.Millisecond);
        static Random aDice = new Random();
        internal string RetirePlayerGladiator { get; set; }
        internal string IsPlayerGladdiatorDead { get; set; }
        internal string GladiatorName { get; set; }
        internal int Weaponskill { get; set; }
        internal int Strenght { get; set; }
        internal int CurrentWounds { get; set; }
        internal int StartingWounds { get; set; }
        internal int Toughness { get; set; }
        internal int NumberOfVictories { get; set; }
        internal int BattleNumber { get; set; }
        public List<string> SlainOpponents { get; set; }
        /// <summary>
        /// This function generates a number between 1 and 6.
        /// </summary>
        /// <returns></returns>
        public int RollADie() { return (aDice.Next(1, 7)); }
        /// <summary>
        /// This function lists the names of slain fighters that the player have won over and the score for the player 
        /// </summary>
        /// <param name="defeatedFighters is a stringlist that expects a list of names."></param>
        internal void PrintSlainOpponents(List<string> defeatedFighters)
        {
            foreach (var opponent in defeatedFighters)
            {
                Console.WriteLine(opponent);
            }
            int score = (IsPlayerGladdiatorDead == "y") ? NumberOfVictories : NumberOfVictories = NumberOfVictories + 1;
            Console.WriteLine($"Your score is: {score}");
        }


    }
}
