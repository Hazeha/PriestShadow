using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ZzukBot.ExtensionFramework.Classes;
using ZzukBot.Game.Statics;
using ZzukBot.Objects;
using CustomClassTemplate.Data;

namespace CustomClassTemplate.Objects
{
    internal class Spellbook
    {
        private static Spell lastSpell = new Spell(string.Empty, -1, false, false);

        private List<Spell> spells;


        //--Healing Spells--//
        //---------------------------------------------------------------------------------------------------------Shield--//
        public static readonly Spell Sheild = new Spell("Power Word: Shield", 1500, false, false,
            isWanted:
                () =>
                //--What Parametters to take care of before casting--//
                    Helpers.CanCast("Power Word: Shield") &&
                    Me.ManaPercent >= 20 && Target.HealthPercent >= 15 && (Me.HealthPercent <= 80 || Target.GotDebuff("Vampiric Embrace")) &&
                    !Me.GotDebuff("Weakened Soul"), customAction:
                () =>
                {
                    //--Custom Action - SelfCasting--//
                    Data.Helpers.TryBuff("Power Word: Shield");
                });
        //-----------------------------------------------------------------------------------------------------Lesser Heal--//
        public static readonly Spell LesserHeal = new Spell("Lesser Heal", 1500, false, false,
            isWanted:
                () =>
                //--What Parametters to take care of before casting--//
                    Helpers.CanCast("Lesser Heal") &&
                    Me.ManaPercent >= 15 && Me.HealthPercent <= 60 && !Helpers.CanCast("Flash Heal"), customAction:
                () =>
                {
                    //--Custom Action - SelfCasting--//
                    Data.Helpers.TryBuff("Lesser Heal");
                });
        //------------------------------------------------------------------------------------------------------Flash Heal--//
        public static readonly Spell FlashHeal = new Spell("Flash Heal", 1400, false, false,
            isWanted:
                () =>
                //--What Parametters to take care of before casting--//
                    Helpers.CanCast("Flash Heal") &&
                    Me.ManaPercent >= 15 && Me.HealthPercent <= 40, customAction:
                () =>
                {
                    //--Custom Action - SelfCasting--//
                    Data.Helpers.TryBuff("Flash Heal");
                });

        //--Dmg Spells--//
        //-------------------------------------------------------------------------------------------------------Mind Blast--//
        public static readonly Spell MindBlast = new Spell("Mind Blast", 700, false, true,
            isWanted:
                () =>
                //--What Parametters to take care of before casting--//
                    Helpers.CanCast("Mind Blast") &&
                    Me.ManaPercent >= 5 && Target.HealthPercent >= 10);
        //--------------------------------------------------------------------------------------------------------Mind Flay--//
        public static readonly Spell MindFlay = new Spell("Mind Flay", 850, false, true, false, isChanneled: true,
            isWanted:
                () =>
                //--What Parametters to take care of before casting--//
                    Helpers.CanCast("Mind Flay") && Target.GotDebuff("Shadow Word: Pain") && !Target.GotDebuff("Mind Flay") 
                    && Me.ManaPercent >= 10);
        //-------------------------------------------------------------------------------------------------Shadow Word: Pain--//
        public static readonly Spell SWP = new Spell("Shadow Word: Pain", 900, false, true, true, 
            isWanted:
                () =>
                //--What Parametters to take care of before casting--//
                    !Target.GotDebuff("Shadow Word: Pain") && lastSpell.Priority != 900 &&
                    Helpers.CanCast("Shadow Word: Pain"));
        //--------------------------------------------------------------------------------------------------Devouring Plague--//
        public static readonly Spell DevouringPlague = new Spell("Devouring Plague", 950, false, true, true,
            isWanted:
                () =>
                //--What Parametters to take care of before casting--//
                    Target.HealthPercent >= 60 && !Target.GotDebuff("Devouring Plague") &&
                    Helpers.CanCast("Devouring Plague"));
        //--------------------------------------------------------------------------------------------------Vampiric Embrace--//
        public static readonly Spell VampiricEmbrace = new Spell("Vampiric Embrace", 750, false, true, true,
           isWanted:
               () =>
               //--What Parametters to take care of before casting--//
                   !Target.GotDebuff("Vampiric Embrace") &&
                   Helpers.CanCast("Vampiric Embrace"));
        //-------------------------------------------------------------------------------------------------------------Smite--//
        public static readonly Spell Smite = new Spell("Smite", 1000, false, true,
            isWanted:
                () =>
                //--What Parametters to take care of before casting--//
                    !Helpers.CanCast("Mind Blast") && !Helpers.CanCast("Mind Flay") && !Helpers.CanWand());

        //--Buff Spells--//
        //---------------------------------------------------------------------------------------------Power Word: Fortitude--//
        public static readonly Spell PowerWordFort = new Spell("Power Word: Fortitude", 10, true, false,
            isWanted:
                () =>
                    Helpers.ShouldBuffSelf("Power Word: Fortitude"));
        //--------------------------------------------------------------------------------------------------------Shadowform--//
        public static readonly Spell Shadowform = new Spell("Shadowform", 7, true, false,
            isWanted:
                () =>
                    Helpers.CanCast("Shadowform"));
        //--------------------------------------------------------------------------------------------------------Inner Fire--//
        public static readonly Spell InnerFire = new Spell("Inner Fire", 9, true, false,
            isWanted:
                () =>
                    Helpers.ShouldBuffSelf("Inner Fire"));
        //-----------------------------------------------------------------------------------------------------Divine Spirit--//
        public static readonly Spell DivineSpirit = new Spell("Divine Spirit", 12, true, false,
            isWanted:
                () =>
                    Helpers.ShouldBuffSelf("Divine Spirit"));
        //--------------------------------------------------------------------------------------------------Shadow Protection--//
        public static readonly Spell ShadowProtection = new Spell("Shadow Protection", 13, true, false,
            isWanted:
                () =>
                    Helpers.ShouldBuffSelf("Shadow Protection"));

        //--If No Mana--//
        //--------------------------------------------------------------------------------------------------------Shoot Wand--//
        public static readonly Spell Wand = new Spell("Shoot", 300, false, false, true, true, isWanted: () =>
        {
            return Helpers.CanWand() && Me.ManaPercent <= 30 && (Target.GotDebuff("Shadow Word: Pain") || !Helpers.CanCast("Shadow Word: Pain"));
        }, customAction: () => ZzukBot.Game.Statics.Spell.Instance.StartWand());

        //-------------------------------------------------------------------------------------------------------------------//
        public Spellbook()
        {
            this.spells = new List<Spell>();
            this.InitializeSpellbook();
        }
        //-------------------------------------------------------------------------------------------------------------------//
        public IEnumerable<Spell> GetDamageSpells()
        {
            return Cache.Instance.GetOrStore("damageSpells", () => this.spells.Where(s => !s.IsBuff));
        }
        //-------------------------------------------------------------------------------------------------------------------//
        public IEnumerable<Spell> GetBuffSpells()
        {
            return Cache.Instance.GetOrStore("buffSpells", () => this.spells.Where(s => s.IsBuff && !s.DoesDamage));
        }
        //-------------------------------------------------------------------------------------------------------------------//
        public void UpdateLastSpell(Spell spell)
        {
            lastSpell = spell;
        }
        //-------------------------------------------------------------------------------------------------------------------//
        private void InitializeSpellbook()
        {
            foreach (var property in this.GetType().GetFields())
            {
                spells.Add(property.GetValue(property) as Spell);
            }

            spells = spells.OrderBy(s => s.Priority).ToList();
        }
        //-------------------------------------------------------------------------------------------------------------------//
        private static WoWUnit Me
        {
            get { return ObjectManager.Instance.Player; }
        }
        //-------------------------------------------------------------------------------------------------------------------//
        private static WoWUnit Target
        {
            get { return ObjectManager.Instance.Target; }
        }
        //-------------------------------------------------------------------------------------------------------------------//
        private static WoWUnit Pet
        {
            get { return ObjectManager.Instance.Pet; }
        }
        //-------------------------------------------------------------------------------------------------------------------//
    }
}
