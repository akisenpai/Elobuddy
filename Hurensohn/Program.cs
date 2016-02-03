using System;
using EloBuddy;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace AddonTemplate
{
    public static class Program
    {
        // Change this line to the champion you want to make the addon for,
        // watch out for the case being correct!
        public const string ChampName = "Tryndamere";

        public static int[] AbilitySequence;

        public static int QOff = 0, WOff = 0, EOff = 0, ROff = 0;

        public static void Main(string[] args)
        {
            // Wait till the loading screen has passed
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            // Verify the champion we made this addon for
            if (Player.Instance.ChampionName != ChampName)
            {
                // Champion is not the one we made this addon for,
                // therefore we return
                return;
            }

            // Initialize the classes that we need
            MenuManager.Load();
            SpellManager.Initialize();
            ModeManager.Initialize();

            Modes.PermaActive.LevelUpSpells();
            AbilitySequence = new[] { 1, 3, 2, 1, 1, 4, 1, 3, 1, 3, 4, 3, 3, 2, 2, 4, 2, 2 };
            // Listen to events we need
            Drawing.OnDraw += OnDraw;
        }

        private static void OnDraw(EventArgs args)
        {
            if (MenuManager.DrawingMenu["DrawE"].Cast<CheckBox>().CurrentValue)
            {
                if (!(MenuManager.DrawingMenu["DrawOnlyReady"].Cast<CheckBox>().CurrentValue && !SpellManager.E.IsReady()))
                {
                    Circle.Draw(Color.Red, SpellManager.E.Range, ObjectManager.Player.Position);
                }
            }
            if (MenuManager.DrawingMenu["DrawQ"].Cast<CheckBox>().CurrentValue)
            {
                if (!(MenuManager.DrawingMenu["DrawOnlyReady"].Cast<CheckBox>().CurrentValue && !SpellManager.Q.IsReady()))
                {
                    Circle.Draw(Color.Red, SpellManager.Q.Range, ObjectManager.Player.Position);
                }
            }
        }
    }
}
