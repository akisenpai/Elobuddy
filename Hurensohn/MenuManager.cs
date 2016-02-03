using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy.SDK.Menu;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace AddonTemplate
{
    class MenuManager
    {
        public static Menu HMenu,
            ComboMenu,
            HarassMenu,
            FleeMenu,
            LaneClearMenu,
            JungleClearMenu,
            MiscMenu,
            DrawingMenu;

        public static void Load()
        {
            Mainmenu();
            Combomenu();
            Harassmenu();
            Fleemenu();
            LaneClearmenu();
            JungleClearmenu();
            Miscmenu();
            Drawingmenu();
        }

        public static void Mainmenu()
        {
            HMenu = MainMenu.AddMenu("Hurensohn", "hurensohn");
            HMenu.AddGroupLabel("Welcome to my Hurensohn Addon have fun! :)");
            HMenu.AddGroupLabel("Made by Hurensohn *-*");
        }

        public static void Combomenu()
        {
            ComboMenu = HMenu.AddSubMenu("Combo", "Combo");
            ComboMenu.AddGroupLabel("Combo");
            ComboMenu.Add("ComboUseW", new CheckBox("Use W"));
            ComboMenu.Add("ComboUseE", new CheckBox("Use E"));
            ComboMenu.Add("ComboUseR", new CheckBox("Use R"));
            ComboMenu.Add("dragon", new CheckBox("Dragonmode", false));
        }

        public static void Harassmenu()
        {
            HarassMenu = HMenu.AddSubMenu("Harass", "Harass");
            HarassMenu.AddGroupLabel("Harass");
            HarassMenu.Add("UseEHarass", new CheckBox("Use E"));
        }

        public static void Fleemenu()
        {
            FleeMenu = HMenu.AddSubMenu("Flee", "Flee");
            FleeMenu.AddGroupLabel("Flee");
            FleeMenu.Add("FleeUseW", new CheckBox("Use W"));
            FleeMenu.Add("FleeUseE", new CheckBox("Use E"));
        }

        public static void LaneClearmenu()
        {
            LaneClearMenu = HMenu.AddSubMenu("LaneClear", "LaneClear");
            LaneClearMenu.AddGroupLabel("LaneClear");
            LaneClearMenu.Add("LCE", new CheckBox("Use E"));
        }

        public static void JungleClearmenu()
        {
            JungleClearMenu = HMenu.AddSubMenu("JungleClear", "JungleClear");
            JungleClearMenu.AddGroupLabel("JungleClear");
            JungleClearMenu.Add("JCE", new CheckBox("Use E"));
        }

        public static void Miscmenu()
        {
            MiscMenu = HMenu.AddSubMenu("Misc", "Misc");
            MiscMenu.AddGroupLabel("Misc");
            MiscMenu.Add("AutoQ", new Slider("Auto Q", 20));
            MiscMenu.AddGroupLabel("Utility");
            MiscMenu.Add("autolvl", new CheckBox("Activate Auto level"));
        }
            
        public static void Drawingmenu()
        {
            DrawingMenu = HMenu.AddSubMenu("Drawings", "Drawings");
            DrawingMenu.AddGroupLabel("Drawings");
            DrawingMenu.Add("DrawW", new CheckBox("Draw W"));
            DrawingMenu.Add("DrawE", new CheckBox("Draw E"));
            DrawingMenu.Add("DrawOnlyReady", new CheckBox("Draw Only if Spells are ready"));
        }
    }
}
