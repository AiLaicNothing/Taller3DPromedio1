using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace TallerSem5
{
    internal class HealPotion: Items
    {
        public HealPotion()
        {
            name = "FireBall";
            recoveryAmmount = 10f;
        }
        public override string GetInfo()
        {
            return $"{name}, recupera {recoveryAmmount} de vida";
        }

        public override float Recover(float variable)
        {
            return variable += recoveryAmmount;
        }

    }
}
