using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Kindred
{
    class Addon
    {
        KindredMenu menu = new KindredMenu();
        KindredSpells spells = new KindredSpells();
        public string cVersion = "0.5";
        public void Load(EventArgs arg)
        {
            Chat.Print("| Kindred - NevaSeries | - Loaded!",System.Drawing.Color.Red);
            Chat.Print("Checking version [ ... ]", System.Drawing.Color.Yellow);
            if (!Player.Instance.ChampionName.Contains("Kindred"))
            {
                Chat.Print("This is a Kindred addon,you have " + Player.Instance.ChampionName, System.Drawing.Color.Orange);
                Chat.Print("Bye, no free elo for you ^^ ", System.Drawing.Color.Black);
                return;
            }
            if (new WebClient().DownloadString("http://pastebin.com/raw.php?i=khH0mDQh") != cVersion)
            {
                Chat.Print("Old version, update addon please!", System.Drawing.Color.Red);
                return;
            }
            else
                Chat.Print("You got the last version! " + cVersion,System.Drawing.Color.Blue);
            menu.loadMenu();
            spells.loadSpells();
            Game.OnTick += keys;
            Drawing.OnDraw += KindredDrawings.actives;
            Game.OnUpdate += Kindred.gameUpdate;
        }
        Kindred k = new Kindred();
        public void keys(EventArgs args)
        {
            if (Orbwalker.ActiveModesFlags == Orbwalker.ActiveModes.Combo)
                k.combo();
            if (Orbwalker.ActiveModesFlags == Orbwalker.ActiveModes.JungleClear)
                k.jungleClear();
            if (Orbwalker.ActiveModesFlags == Orbwalker.ActiveModes.LaneClear)
                k.laneClear();
            if (Orbwalker.ActiveModesFlags == Orbwalker.ActiveModes.Flee)
                k.Flee();
        }
    }
}
