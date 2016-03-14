using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomClassTemplate.Settings
{
    class CustomClassSettings
    {

        public volatile int RangedAttackRange = 27;
        public volatile int MeleeAttackRange = 4;
        public string FoodName = "";
        public string DrinkName = "";



        private CustomClassSettings()
        {

        }

        internal static CustomClassSettings Values { get; set; } = new CustomClassSettings();

        internal void Load()
        {
            Values = ZzukBot.Settings.OptionManager.Get(Data.Statics.SettingsName).LoadFromJson<CustomClassSettings>() ??
                     this;
        }

        internal void Save()
        {
            ZzukBot.Settings.OptionManager.Get(Data.Statics.SettingsName).SaveToJson(this);
        }
    }
}
