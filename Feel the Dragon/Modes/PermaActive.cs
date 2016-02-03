using System.Diagnostics;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace AddonTemplate.Modes
{
    public sealed class PermaActive : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Since this is permaactive mode, always execute the loop
            return true;
        }

        public override void Execute()
        {
            if (Player.Instance.IsDead)
            {
                return;
            }

            if (Q.IsReady() && ObjectManager.Player.HealthPercent <= MenuManager.MiscMenu["AutoQ"].Cast<Slider>().CurrentValue)
            {
                Q.Cast();
            }
        }

        public static void LevelUpSpells()
        {
            if (!MenuManager.MiscMenu["autolvl"].Cast<CheckBox>().CurrentValue) return;

            var qL = ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Q).Level + Program.QOff;
            var wL = ObjectManager.Player.Spellbook.GetSpell(SpellSlot.W).Level + Program.WOff;
            var eL = ObjectManager.Player.Spellbook.GetSpell(SpellSlot.E).Level + Program.EOff;
            var rL = ObjectManager.Player.Spellbook.GetSpell(SpellSlot.R).Level + Program.ROff;
            if (qL + wL + eL + rL >= ObjectManager.Player.Level) return;
            int[] level = { 0, 0, 0, 0 };
            for (var i = 0; i < ObjectManager.Player.Level; i++)
            {
                level[Program.AbilitySequence[i] - 1] = level[Program.AbilitySequence[i] - 1] + 1;
            }
            if (qL < level[0]) ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.Q);
            if (wL < level[1]) ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.W);
            if (eL < level[2]) ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.E);
            if (rL < level[3]) ObjectManager.Player.Spellbook.LevelSpell(SpellSlot.R);
        }

        public static void Dragonmode()
        {
            if (MenuManager.ComboMenu["dragon"].Cast<CheckBox>().CurrentValue && ObjectManager.Player.HasUndyingBuff())
            {
                Player.SetModel("SRU_Dragon");
            }

            if (MenuManager.ComboMenu["dragon"].Cast<CheckBox>().CurrentValue && !ObjectManager.Player.HasUndyingBuff() && ObjectManager.Player.ManaPercent == 100)
            {
                Player.SetModel("ShyvanaKnightDragon");
            }

            if (MenuManager.ComboMenu["dragon"].Cast<CheckBox>().CurrentValue && !ObjectManager.Player.HasUndyingBuff() && ObjectManager.Player.ManaPercent < 100)
            {
                Player.SetModel("Tryndamere");
            }
        }
    }
}
