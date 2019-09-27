using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGStoreAssessment
{
    class Enemy
    {
        public string attckerName;

        public virtual void BattleDialouge()
        {
            Console.WriteLine($"\n Prepare to die {Program.player.name}!!!");
        }
            
        
    }
}
