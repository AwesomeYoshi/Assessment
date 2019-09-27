using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStoreAssessment
{
    class Bandit:Enemy
    {
        public int attack;
        public int health;

        public override void BattleDialouge()
        {
            Console.WriteLine($"Hello {Program.player.name}, Nice to meet you. My name is {attckerName}. I have {health} health and {attack} damage");
        }
    }
}
