using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomClassTemplate.Data;
using ZzukBot.Game.Statics;

namespace CustomClassTemplate.Objects
{
    internal class Spell
    {
        private readonly string name;
        private readonly int priority;
        private readonly bool isBuff;
        private readonly bool doesDamage;
        private readonly bool isInstant;
        private readonly bool isChanneled = false;
        private readonly Func<bool> isWanted;
        private readonly Action customAction;

        internal Spell(string name, int priority, bool isBuff, bool doesDamage, bool isInstant = false,
            bool isChanneled = false, Func<bool> isWanted = null, Action customAction = null)
        {
            this.name = name;
            this.priority = priority;
            this.isBuff = isBuff;
            this.doesDamage = doesDamage;
            this.isInstant = isInstant;
            this.isChanneled = isChanneled;
            this.isWanted = isWanted;
            this.customAction = customAction;
        }

        public override string ToString()
        {
            return name;
        }

        public int Priority
        {
            get { return this.priority; }
        }

        public bool IsBuff
        {
            get { return this.isBuff; }
        }

        public bool DoesDamage
        {
            get { return this.doesDamage; }
        }

        public bool IsInstant
        {
            get { return this.isInstant; }
        }

        public bool IsChanneled
        {
            get { return this.isChanneled; }
        }

        public bool IsWanted
        {
            get { return this.isWanted == null || this.isWanted.Invoke(); }
        }

        public void Cast()
        {
            if (customAction == null)
            {
                if (IsBuff)
                {
                    Helpers.TryBuff(name);
                }
                else
                {
                    Helpers.TryCast(name);
                }
            }
            else
            {
                customAction.Invoke();
            }
        } 
    }
}
