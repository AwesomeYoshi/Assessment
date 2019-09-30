using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStoreAssessment
{
    class Dragon:Enemy
    {
        public int attack;
        public int health;

        public override void BattleDialouge()
        {
            Console.WriteLine($"Hello {Program.player.name}, Nice to meet you. I am a dragon and my name is {attackerName}. I have {health} health and {attack} damage");
        }
    }
}
