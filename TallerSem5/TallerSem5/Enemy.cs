using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerSem5
{
    internal class Enemy
    {
        public string name;
        public float hp;
        public float damage;

        public bool isdead;

        public Enemy(string name, float hp, float damage)
        {
            this.name = name;
            this.hp = hp;
            this.damage = damage;
        }

        public virtual string GetInfo()
        {
            return $"{name}, tiene {hp} puntos de vida y {damage} puntos de daño ";
        }

        public virtual float GetDamaged(float playerDamage)
        {
            return hp -=playerDamage;
        }
    }
}
