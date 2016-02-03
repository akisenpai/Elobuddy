using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace AddonTemplate.Modes
{
    public sealed class Combo : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on combo mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            // TODO: Add combo logic here
            // See how I used the Settings.UseQ here, this is why I love my way of using
            // the menu in the Config class!
            var target = TargetSelector.GetTarget(1000, DamageType.Physical);

            if (target == null) return;

            if (MenuManager.ComboMenu["ComboUseW"].Cast<CheckBox>().CurrentValue && W.IsReady() && !target.IsFacing(ObjectManager.Player))
            {
                W.Cast();
            }

            if (MenuManager.ComboMenu["ComboUseE"].Cast<CheckBox>().CurrentValue && E.IsReady())
            {
                E.Cast(target.Position);
            }

            if (MenuManager.ComboMenu["ComboUseR"].Cast<CheckBox>().CurrentValue)
            {
                Damagecheck();
            }
        }

        public static void Damagecheck()
        {
            var enemy = EntityManager.Heroes.Enemies.FindAll(x => x.Position.Distance(ObjectManager.Player) < 1000 && x.IsAttackingPlayer && !x.IsDead && x.IsValid && (x.GetSpellDamage(ObjectManager.Player, SpellSlot.Q) >= ObjectManager.Player.Health || x.GetSpellDamage(ObjectManager.Player, SpellSlot.W) >= ObjectManager.Player.Health || x.GetSpellDamage(ObjectManager.Player, SpellSlot.E) >= ObjectManager.Player.Health || x.GetSpellDamage(ObjectManager.Player, SpellSlot.R) >= ObjectManager.Player.Health) || (x.GetSpellDamage(ObjectManager.Player, SpellSlot.R) + x.GetSpellDamage(ObjectManager.Player, SpellSlot.E) + x.GetSpellDamage(ObjectManager.Player, SpellSlot.Q) + x.GetSpellDamage(ObjectManager.Player, SpellSlot.W) >= ObjectManager.Player.Health));

            foreach (var e in enemy)
            {
                if (SpellManager.R.IsReady())
                {
                    SpellManager.R.Cast();
                }

                if (!SpellManager.R.IsReady() && SpellManager.Q.IsReady() && !ObjectManager.Player.HasUndyingBuff()) 
                {
                    SpellManager.Q.Cast();
                }
            }
        }
    }
}

