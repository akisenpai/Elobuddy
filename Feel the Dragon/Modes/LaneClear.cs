using EloBuddy.SDK;
using EloBuddy;
using System.Linq;
using EloBuddy.SDK.Menu.Values;

namespace AddonTemplate.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            // Only execute this mode when the orbwalker is on laneclear mode
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            var minions =
                EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.Position,
                    Q.Range).Where(
                        m => !m.IsDead && m.IsValid && !m.IsInvulnerable);

            foreach (var m in minions)
            {
                if (MenuManager.LaneClearMenu["LCE"].Cast<CheckBox>().CurrentValue)
                {
                    E.Cast(m.Position);
                }
            }
        }
    }
}
