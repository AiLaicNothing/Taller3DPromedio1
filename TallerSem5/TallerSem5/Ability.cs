using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerSem5
{
    internal class Ability
    {
        protected string name;
        protected float cost;
        protected float damage;
        public string Name 
        { 
            get { return name; } 
        }
        public float Cost
        {
            get {return cost;}
        }
        public float Damage
        {
            get { return damage; }
        }

        public virtual string GetInfo()
        {
            return "Text";
        }
        public virtual float AbilityAttack()
        {
            return damage;
        }
    }
}
