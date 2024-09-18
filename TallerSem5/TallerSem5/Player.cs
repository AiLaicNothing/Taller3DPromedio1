using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerSem5
{
    internal class Player
    {
        public string name;
        public float hp;
        public float mana;
        public float damage;

        public Player(string name, float hp, float mana, float damage)
        {
            this.name = name;
            this.hp = hp;
            this.mana = mana;
            this.damage = damage;
        }

        public virtual string GetInfo()
        {
            return $"{name}, {hp} puntos de vida, {mana} puntos de mana y {damage} puntos de daño";
        }

        public virtual float GetDamaged(float damage)
        {
            return hp -=damage;
        }
    }
}
