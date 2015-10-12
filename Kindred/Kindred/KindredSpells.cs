using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindred
{
    class KindredSpells
    {
        public static Spell.Skillshot privQ;
        public static Spell.Targeted privW, privE, privR,smite,ignite;
        public static Item youmus,botrk;
        public static Spell.Active heal;
        public void loadSpells()
        {
            privQ = new Spell.Skillshot(SpellSlot.Q, 470, SkillShotType.Linear);
            privW = new Spell.Targeted(SpellSlot.W, 800);
            privE = new Spell.Targeted(SpellSlot.E, 650);
            privR = new Spell.Targeted(SpellSlot.R, 700);
            if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Summoner1).Name.Contains("smite"))
                smite = new Spell.Targeted(SpellSlot.Summoner1, 570);
            else if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Summoner2).Name.Contains("smite"))
                smite = new Spell.Targeted(SpellSlot.Summoner2, 570);

            if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Summoner1).Name.Contains("dot"))
                ignite = new Spell.Targeted(SpellSlot.Summoner1, 580);
            else if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Summoner2).Name.Contains("dot"))
                ignite = new Spell.Targeted(SpellSlot.Summoner2, 580);

            if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Summoner1).Name.Contains("heal"))
                heal = new Spell.Active(SpellSlot.Summoner1);
            else if (ObjectManager.Player.Spellbook.GetSpell(SpellSlot.Summoner2).Name.Contains("heal"))
                heal = new Spell.Active(SpellSlot.Summoner2);
            youmus = new Item(3142);
            botrk = new Item(3153, 500);
        }
    }
}
