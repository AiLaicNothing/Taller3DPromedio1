using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerSem5
{
    internal class Items
    {
        protected string name;
        protected float recoveryAmmount;
        public string Name
        {
            get { return name; }
        }
        public float RecoveryAmmount
        {
            get { return recoveryAmmount; }
        }

        public virtual string GetInfo()
        {
            return "Text";
        }
        public virtual float Recover(float variable)
        {
            return recoveryAmmount;
        }
    }
}
