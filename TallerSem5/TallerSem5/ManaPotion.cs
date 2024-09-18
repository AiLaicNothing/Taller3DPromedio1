using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TallerSem5
{
    internal class ManaPotion: Items
    {
        public ManaPotion()
        {
            name = "FireBall";
            recoveryAmmount = 10f;
        }
        public override string GetInfo()
        {
            return $"{name}, recupera {recoveryAmmount} de mana";
        }

        public override float Recover(float variable)
        {
            return variable += recoveryAmmount;
        }
    }
}
