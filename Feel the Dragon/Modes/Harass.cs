using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;


namespace AddonTemplate.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on harass mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            // TODO: Add harass logic here
            // See how I used the Settings.UseQ and Settings.Mana here, this is why I love
            // my way of using the menu in the Config class!
            var target = TargetSelector.GetTarget(1000, DamageType.Physical);

            if (target == null) return;


            if (MenuManager.HarassMenu["HarassUseE"].Cast<CheckBox>().CurrentValue && E.IsReady())
            {
                E.Cast(target.Position);
            }
        }
    }
}
