using EloBuddy.SDK;
using EloBuddy;
using System.Linq;
using EloBuddy.SDK.Menu.Values;

namespace AddonTemplate.Modes
{
    public sealed class JungleClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on jungleclear mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear);
        }

        public override void Execute()
        {
            var monsters =
    EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.Position, E.Range)
        .Where(t => !t.IsDead && t.IsValid && !t.IsInvulnerable);

            foreach (var m in monsters)
            {
                if (MenuManager.JungleClearMenu["JCE"].Cast<CheckBox>().CurrentValue)
                {
                    E.Cast(m.Position);
                }
            }
        }
    }
}
