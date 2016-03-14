using ZzukBot.Game.Statics;

namespace CustomClassTemplate.Data
{
    internal static class Helpers
    {
        public static void PrintToChat(string parMessage)
        {
            Lua.Instance.Execute("DEFAULT_CHAT_FRAME:AddMessage('EmuPriest: " + parMessage + "')");
        }

        public static void TryCast(string parSpell, int parWait = 10)
        { 
            if (CanCast(parSpell))
            {
                Spell.Instance.StopWand();
                Spell.Instance.CastWait(parSpell, parWait);
            }
        }

        public static void TryBuff(string parSpell)
        {
            if (ShouldBuffSelf(parSpell))
            {
                Lua.Instance.Execute("CastSpellByName('" + parSpell + "',1);");
            }
        }

        public static bool ShouldBuffSelf(string parSpell)
        {
            return (CanCast(parSpell) && !ObjectManager.Instance.Player.GotAura(parSpell));
        }


        public static bool CanCast(string parSpell)
        {
            return ZzukBot.Game.Statics.Spell.Instance.IsSpellReady(parSpell) && ZzukBot.Game.Statics.Spell.Instance.GetSpellRank(parSpell) != 0;
        }

        public static bool CanWand()
        {
            return ObjectManager.Instance.Player.IsWandEquipped();
        }
    }
}
