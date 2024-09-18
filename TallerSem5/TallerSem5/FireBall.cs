using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerSem5
{
    internal class FireBall:Ability
    {
        public FireBall() 
        {
            name = "FireBall";
            cost = 10f;
            damage = 20;
        }

        public override string GetInfo()
        {
            return $"{name}, coste {cost} de mana, inflige {damage} de daño al enemigo";
        }

        public override float AbilityAttack()
        {
            return -damage;
        }
    }
}
