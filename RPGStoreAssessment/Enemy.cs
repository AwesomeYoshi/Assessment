using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStoreAssessment
{
    class Enemy
    {
        public string attackerName;

        public virtual void BattleDialouge()
        {
            Console.WriteLine($"\nPrepare to die {Program.player.name}!!!");
        }

        public virtual void ShieldDialougue()
        {
            Console.WriteLine($"\nI see that you chose to shield this attack,{Program.player.name}");
        }
           
        
    }
}
