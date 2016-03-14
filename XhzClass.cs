using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Forms;
using CustomClassTemplate.Gui;
using CustomClassTemplate.Objects;
using CustomClassTemplate.Settings;
using ZzukBot.Constants;
using ZzukBot.ExtensionFramework.Classes;
using ZzukBot.Game.Statics;
using ZzukBot.Mem;
using ZzukBot.Objects;

// XhzPriest - Credits to z0mg and Emu

namespace CustomClassTemplate
{
    [Export(typeof(CustomClass))]
    public class EmuClass : CustomClass
    {
        //-----------------------------------------------------------------------------------------------------------------------//
        private Form CCGui = new CCGui();
        private Spellbook spellbook;
        //-------------------------------The WoW class the CustomClass is designed for-------------------------------------------//
        public override Enums.ClassId Class => Enums.ClassId.Priest;
        //-------------------------------Should be called when the CC is loaded--------------------------------------------------//
        public override bool Load()
        {
            this.spellbook = new Spellbook();
            CustomClassSettings.Values.Load();
            return true;
        }
        //-------------------------------Should be called when the CC is unloaded-------------------------------------------------//
        public override void Unload()
        {
        }
        //-------------------------------Should be called when the botbase is pulling an unit-------------------------------------//
        public override void OnPull()
        {
            try
            {
                WoWUnit targetUnit = ObjectManager.Instance.Target;
                if (targetUnit == null) return;


                var damageSpells = this.spellbook.GetDamageSpells();

                foreach (var spell in damageSpells)
                {
                    if (spell.IsWanted)
                    {
                        spell.Cast();
                        spellbook.UpdateLastSpell(spell);
                        break;
                    }
                }
            }
            catch (Exception e)
            {

            }
        }
        //-------------------------------Should be called when the botbase is fighting an unit------------------------------------//
        public override void OnFight()
        {
            try
            {
                WoWUnit targetUnit = ObjectManager.Instance.Target;
                if (targetUnit == null) return;

                var damageSpells = this.spellbook.GetDamageSpells();

                foreach (var spell in damageSpells)
                {
                    if (spell.IsWanted)
                    {
                        spell.Cast();
                        spellbook.UpdateLastSpell(spell);
                        break;
                    }
                }
            }
            catch(Exception e)
            {
                
            }
        }
        //-------------------------------Should be called when the botbase is resting-------------------------------------------//
        public override void OnRest()
        {
            //This needs to be tested & cleaned up
            MainThread.Instance.Invoke(() =>
            {
                try
                {
                    if (!ObjectManager.Instance.Player.IsDrinking)
                    {
                        ObjectManager.Instance.Items.FirstOrDefault(i => i.Name == CustomClassSettings.Values.DrinkName)
                            .Use();
                        ZzukBot.Helpers.Wait.For("DrinkPriest", 500);
                    }
                    if (!ObjectManager.Instance.Player.IsEating)
                    {
                        ObjectManager.Instance.Items.FirstOrDefault(i => i.Name == CustomClassSettings.Values.FoodName)
                            .Use();
                        ZzukBot.Helpers.Wait.For("EatPriest", 500);
                    }
                }
                catch
                {

                }
            });
        }
        //-------------------------------Returns true when the character is done buffing-------------------------------------------//
        public override bool OnBuff()
        {
            try
            {
                var buffs = this.spellbook.GetBuffSpells();

                foreach (var spell in buffs)
                {
                    if (spell.IsWanted)
                    {
                        spell.Cast();
                        return false;
                    }
                }
            }
            catch (Exception e)
            {

            }
            return true;
        }
        //-------------------------------Should be called to show the settings form-----------------------------------------------//
        public override void ShowGui()
        {
            CCGui.Dispose();
            CCGui = new CCGui();
            CCGui.Show();
        }
        //-------------------------------The name of the CC-----------------------------------------------------------------------//
        public override string Name => "XhzPriest";
        //-------------------------------The author of the CC---------------------------------------------------------------------//
        public override string Author => "z0mg - Emu - Xhz";
        //-------------------------------The version of the CC--------------------------------------------------------------------//
        public override int Version => 1;
        //-------------------------------The current combat distance--------------------------------------------------------------//
        public override float CombatDistance => Data.Statics.CombatDistance;

    }
}
