using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindred
{
    class KindredMenu
    {
        public static Menu myMenu,comboMenu,jungleMenu,drawingsMenu,itemsMenu,smitePage,lcPage,spellsPage,fleePage,utilitiesPage,ksPage,skinPage;
        public void loadMenu()
        {
            mainPage();
            comboPage();
            junglePage();
            laneClearPage();
            drawingsPage();
            itemsPage();
            SmitePage();
            SpellsPage();
            FleePage();
            UtilitiesPage();
            KsPage();
            SkinPage();
        }
        public void mainPage()
        {
            myMenu= MainMenu.AddMenu("NevaSeries", "main");
            myMenu.AddLabel(" | Advanced Kindred Addon | By Nevachana");
            myMenu.AddLabel(" ~ Press Space for Combo");
            myMenu.AddLabel(" ~ Press Z for LaneClear");
            myMenu.AddLabel(" ~ Press V for JungleClear");
            myMenu.AddLabel(" ~ Press T for Flee");
        }
        public void SkinPage()
        {
            skinPage = myMenu.AddSubMenu("Skin Settings", "skin");
            skinPage.AddGroupLabel("Skin settings");
            skinPage.AddSeparator();
            skinPage.Add("skin.Id", new Slider("Skin Editor", 0, 0, 15));
        }
        public void comboPage()
        {
           comboMenu = myMenu.AddSubMenu("Combo settings", "Combo");
           comboMenu.AddGroupLabel("Combo settings");
           comboMenu.AddSeparator();
           comboMenu.Add("combo.Q", new CheckBox("Use Q"));
           comboMenu.Add("combo.W", new CheckBox("Use W"));
           comboMenu.Add("combo.E", new CheckBox("Use E"));
           comboMenu.Add("combo.Smite", new CheckBox("Use Smite"));
           comboMenu.Add("combo.Botrk", new CheckBox("Use Botrk"));
           comboMenu.Add("combo.Youmus", new CheckBox("Use Youmuss"));
           comboMenu.AddSeparator();
           comboMenu.AddGroupLabel("Utilities Settings");
           comboMenu.AddSeparator();
           comboMenu.Add("combo.Rmin", new Slider("Min enemies in range for R", 3, 1, 5));
           comboMenu.Add("combo.Qmin", new Slider("Play safe when HP (%) is lower than", 60, 1, 100));
           comboMenu.Add("combo.QminAG", new Slider("Play safe when enemies in range", 3, 1, 5));
        }
        public void laneClearPage()
        {
            lcPage= myMenu.AddSubMenu("Lane Clear Settings", "laneclear");
            lcPage.AddGroupLabel("Lane clear settings");
            lcPage.AddSeparator();
            lcPage.Add("lc.Q", new CheckBox("Use Q"));
            lcPage.Add("lc.W", new CheckBox("Use W"));
            lcPage.Add("lc.E", new CheckBox("Use E"));
        }
        public void junglePage()
        {
            jungleMenu = myMenu.AddSubMenu("Jungle Settings","Jungle");
            jungleMenu.AddGroupLabel("Jungle settings");
            jungleMenu.AddSeparator();
            jungleMenu.Add("jungle.Q", new CheckBox("Use Q jungle"));
            jungleMenu.Add("jungle.W", new CheckBox("Use E jungle"));
            jungleMenu.Add("jungle.E", new CheckBox("Use W jungle "));
            jungleMenu.Add("jungle.Smite", new CheckBox("Smite for sustain"));
        }
        public void drawingsPage()
        {
            drawingsMenu = myMenu.AddSubMenu("Drawings Settings", "Drawings");
            drawingsMenu.AddGroupLabel("Drawing skills");
            drawingsMenu.AddSeparator();
            drawingsMenu.Add("draw.Q", new CheckBox("Draw Q range"));
            drawingsMenu.Add("draw.W", new CheckBox("Draw W range"));
            drawingsMenu.Add("draw.E", new CheckBox("Draw E range"));
            drawingsMenu.Add("draw.R", new CheckBox("Draw R range"));
            drawingsMenu.AddSeparator();
            drawingsMenu.AddGroupLabel("Drawing Utilies");
            drawingsMenu.AddSeparator();
            drawingsMenu.Add("draw.Target", new CheckBox("Draw target"));
        }
        public void itemsPage()
        {
            itemsMenu = myMenu.AddSubMenu("Items Settings", "Items");
            itemsMenu.AddGroupLabel("Items usage");
            itemsMenu.AddSeparator();
            itemsMenu.AddGroupLabel("Youmuss");
            itemsMenu.Add("items.Youmuss.HP", new Slider("Use Youmuss if HP is lower than (%)", 60, 1, 100));
            itemsMenu.Add("items.Youmuss.Enemys", new Slider("Use Youmuss if enemies in range", 2, 1, 5));
            itemsMenu.AddSeparator();
            itemsMenu.AddGroupLabel("Botrk");
            itemsMenu.Add("items.Botrk.HP", new Slider("Use Botrk if HP is lower than (%)", 30, 1, 100));        
        }
        public void SmitePage()
        {
            smitePage = myMenu.AddSubMenu("Smite Settings", "Smite");
            smitePage.AddGroupLabel("Smite settings");
            smitePage.AddSeparator();
            smitePage.Add("SRU_Red", new CheckBox("Smite Red"));
            smitePage.Add("SRU_Blue", new CheckBox("Smite Blue"));
            smitePage.Add("SRU_Dragon", new CheckBox("Smite Dragon"));
            smitePage.Add("SRU_Baron", new CheckBox("Smite Baron"));
            smitePage.Add("SRU_Gromp", new CheckBox("Smite Gromp"));
            smitePage.Add("SRU_Murkwolf", new CheckBox("Smite Wolf"));
            smitePage.Add("SRU_Razorbeak", new CheckBox("Smite Bird"));
            smitePage.Add("SRU_Krug", new CheckBox("Smite Golem"));
            smitePage.Add("Sru_Crab",new CheckBox("Smite Crab"));
        }
        public void SpellsPage()
        {
            spellsPage = myMenu.AddSubMenu("Spells Settings", "spells");
            spellsPage.AddGroupLabel("Spells settings");
            spellsPage.AddSeparator();
            spellsPage.AddGroupLabel("Heal settings");
            spellsPage.Add("spells.Heal.Hp", new Slider("Use Heal when HP is lower than (%)", 30, 1, 100));
            spellsPage.AddGroupLabel("Ignite settings");
            spellsPage.Add("spells.Ignite.Focus", new Slider("Use Ignite when target HP is lower than (%)", 10, 1, 100));
            spellsPage.Add("spells.Ignite.Kill", new CheckBox("Use Ignite if killable"));
        }
        public void FleePage()
        {
            fleePage = myMenu.AddSubMenu("Flee Settings", "flee");
            fleePage.AddGroupLabel("Flee settings");
            fleePage.AddSeparator();
            fleePage.Add("flee.Smart.Q", new CheckBox("Smart Flee"));
            fleePage.Add("flee.Min.Mana", new Slider("Min mana for using Q", 30, 1, 100));
        }
        public void UtilitiesPage()
        {
            utilitiesPage = myMenu.AddSubMenu("Utilities Settings", "utilities");
            utilitiesPage.AddGroupLabel("Utilities settings");
            utilitiesPage.AddLabel("Note: this will be auto-activated");
            utilitiesPage.AddGroupLabel("R settings");
            utilitiesPage.AddSeparator();
            utilitiesPage.Add("tools.R.Enemys", new Slider("Auto R if there are enemies in range", 3, 0, 5));
            utilitiesPage.Add("tools.R.Hp", new Slider("Auto R if hp is lower than", 20, 1, 100));
        }
        public void KsPage()
        {
            ksPage = myMenu.AddSubMenu("KS settings", "ks");
            ksPage.AddGroupLabel("KS settings");
            ksPage.AddSeparator();
            ksPage.Add("ks.Q", new CheckBox("KS using Q"));
            ksPage.Add("ks.W", new CheckBox("KS using W"));
            ksPage.Add("ks.E", new CheckBox("KS using E"));
            ksPage.Add("ks.Smite", new CheckBox("KS using Smite"));
        }

        public static float itemsYOUMUSShp()
        {
            return itemsMenu["items.Youmuss.HP"].Cast<Slider>().CurrentValue;
        }
        public static float itemsYOUMUSSenemys()
        {
            return itemsMenu["items.Youmuss.Enemys"].Cast<Slider>().CurrentValue;
        }
        public static float itemsBOTRKhp()
        {
            return itemsMenu["items.Botrk.HP"].Cast<Slider>().CurrentValue;
        }


        public static bool useQjungle()
        {
            return jungleMenu["jungle.Q"].Cast<CheckBox>().CurrentValue;
        }
        public static bool useWjungle()
        {
            return jungleMenu["jungle.W"].Cast<CheckBox>().CurrentValue;
        }
        public static bool useEjungle()
        {
            return jungleMenu["jungle.E"].Cast<CheckBox>().CurrentValue;
        }
        public static bool useSmitejungle()
        {
            return jungleMenu["jungle.Smite"].Cast<CheckBox>().CurrentValue;
        }


        public static float minQaggresive()
        {
            return comboMenu["combo.QminAG"].Cast<Slider>().CurrentValue;
        }
        public static float minQcombo()
        {
            return comboMenu["combo.Qmin"].Cast<Slider>().CurrentValue;
        }
        public static float minRcombo()
        {
            return comboMenu["combo.Rmin"].Cast<Slider>().CurrentValue;
        }
        public static bool useSmiteCombo()
        {
            return comboMenu["combo.Smite"].Cast<CheckBox>().CurrentValue;
        }
        public static bool useQ()
        {
           return comboMenu["combo.Q"].Cast<CheckBox>().CurrentValue;
        }
        public static bool useW()
        {
            return comboMenu["combo.W"].Cast<CheckBox>().CurrentValue;
        }
        public static bool useE()
        {
            return comboMenu["combo.E"].Cast<CheckBox>().CurrentValue;
        }
        public static bool useR()
        {
            return comboMenu["combo.R"].Cast<CheckBox>().CurrentValue;
        }
        public static bool useBotrk()
        {
            return comboMenu["combo.Botrk"].Cast<CheckBox>().CurrentValue;
        }
        public static bool useYoumuss()
        {
            return comboMenu["combo.Youmus"].Cast<CheckBox>().CurrentValue;
        }


        public static bool drawingsQ()
        {
            return drawingsMenu["draw.Q"].Cast<CheckBox>().CurrentValue;
        }
        public static bool drawingsW()
        {
            return drawingsMenu["draw.W"].Cast<CheckBox>().CurrentValue;
        }
        public static bool drawingsE()
        {
            return drawingsMenu["draw.E"].Cast<CheckBox>().CurrentValue;
        }
        public static bool drawingsR()
        {
            return drawingsMenu["draw.R"].Cast<CheckBox>().CurrentValue;
        }

        public static bool drawingsTarget()
        {
            return drawingsMenu["draw.Target"].Cast<CheckBox>().CurrentValue;
        }

        public static bool useQlc()
        {
            return lcPage["lc.Q"].Cast<CheckBox>().CurrentValue;
        }
        public static bool useWlc()
        {
            return lcPage["lc.W"].Cast<CheckBox>().CurrentValue;
        }
        public static bool useElc()
        {
            return lcPage["lc.E"].Cast<CheckBox>().CurrentValue;
        }

        public static float spellsHealhp() 
        {
            return spellsPage["spells.Heal.Hp"].Cast<Slider>().CurrentValue;
        }
        public static float spellsHealignite()
        {
            return spellsPage["spells.Ignite.Focus"].Cast<Slider>().CurrentValue;
        }

        public static bool fleeSmart()
        {
            return fleePage["flee.Smart.Q"].Cast<CheckBox>().CurrentValue;
        }
        public static float MinmanaFlee()
        {
            return fleePage["flee.Min.Mana"].Cast<Slider>().CurrentValue;
        }

        public static float utilitiesRenemys()
        {
            return utilitiesPage["tools.R.Enemys"].Cast<Slider>().CurrentValue;
        }
        public static float utilitiesRhp()
        {
            return utilitiesPage["tools.R.Hp"].Cast<Slider>().CurrentValue;
        }

        public static bool ksQ()
        {
            return ksPage["ks.Q"].Cast<CheckBox>().CurrentValue;
        }
        public static bool ksW()
        {
            return ksPage["ks.W"].Cast<CheckBox>().CurrentValue;
        }
        public static bool ksE()
        {
            return ksPage["ks.E"].Cast<CheckBox>().CurrentValue;
        }
        public static bool ksSmite()
        {
            return ksPage["ks.Smite"].Cast<CheckBox>().CurrentValue;
        }

        public static int skinId()
        {
            return skinPage["skin.Id"].Cast<Slider>().CurrentValue;
        }
    }
}
