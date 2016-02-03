using EloBuddy.SDK;
using EloBuddy;
using EloBuddy.SDK.Menu.Values;

namespace AddonTemplate.Modes
{
    public sealed class Flee : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on flee mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Flee);
        }

        public override void Execute()
        {
            var target = TargetSelector.GetTarget(1000, DamageType.Physical);

            if (target == null) return;


            if (MenuManager.FleeMenu["FleeUseE"].Cast<CheckBox>().CurrentValue && E.IsReady())
            {
                E.Cast(Game.CursorPos);
            }

            if (MenuManager.FleeMenu["FleeUseW"].Cast<CheckBox>().CurrentValue && W.IsReady() && !ObjectManager.Player.IsFacing(target))
            {
                W.Cast();
            }
        }
    }
}
