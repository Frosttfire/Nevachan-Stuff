using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindred
{
    class Kindred
    {
        private KindredMenu spells = new KindredMenu();
        public static AIHeroClient gTarget = null;
        private static Kindred k = new Kindred();
        public static void gameUpdate(EventArgs args)
        {
            if(KindredSpells.smite != null)
            k.smite();
            if(KindredSpells.heal != null)
            k.Heal();
            if (KindredSpells.ignite != null)
            k.ignite();
            if (KindredSpells.privR.IsReady())
            k.activatorR();
            k.ks(KindredMenu.ksQ(), KindredMenu.ksW(), KindredMenu.ksE(),KindredMenu.ksSmite());
            Player.SetSkinId(KindredMenu.skinId());
        }
        public void ignite()
        {
            var autoIgnite = TargetSelector.GetTarget(KindredSpells.ignite.Range, DamageType.True);
            if (autoIgnite != null && autoIgnite.Health <= DamageLibrary.GetSpellDamage(Player.Instance, autoIgnite, KindredSpells.ignite.Slot) || autoIgnite != null && autoIgnite.HealthPercent <= KindredMenu.spellsHealignite())
                KindredSpells.ignite.Cast(autoIgnite);
        }
        public void Heal()
        {
            if (KindredSpells.heal.IsReady() && Player.Instance.HealthPercent <= KindredMenu.spellsHealhp())
                KindredSpells.heal.Cast();
        }
        public void smite()
        {
          var unit =ObjectManager.Get<Obj_AI_Base>().Where(a =>KindredVariables.MinionNames.Contains(a.BaseSkinName) && DamageLibrary.GetSummonerSpellDamage(Player.Instance,a,DamageLibrary.SummonerSpells.Smite) >= a.Health  &&KindredMenu.smitePage[a.BaseSkinName].Cast<CheckBox>().CurrentValue && KindredSpells.smite.IsInRange(a)).OrderByDescending(a => a.MaxHealth).FirstOrDefault();
          if (unit != null && KindredSpells.smite.IsReady())
              KindredSpells.smite.Cast(unit);

        }
        public void activatorR()
        {
            if (ObjectManager.Player.CountEnemiesInRange(Player.Instance.AttackRange) >= KindredMenu.utilitiesRenemys() || ObjectManager.Player.HealthPercent <= KindredMenu.utilitiesRhp())
                KindredSpells.privR.Cast(Player.Instance);
        }
        public void ks(bool Q, bool W, bool E,bool Smite)
        {
            var target = TargetSelector.GetTarget(KindredSpells.privW.Range, DamageType.Physical);
            if (target == null)
                return;
            if (Q && KindredSpells.privQ.IsReady())
            {
                if (KindredSpells.privQ.IsInRange(target) && DamageLibrary.GetSpellDamage(Player.Instance, target, SpellSlot.Q) <= 10)
                    KindredSpells.privQ.Cast(target);
            }
            if (W && KindredSpells.privW.IsReady())
            {
                if (KindredSpells.privW.IsInRange(target) && DamageLibrary.GetSpellDamage(Player.Instance, target, SpellSlot.W) <= 10)
                    KindredSpells.privW.Cast(target);
            }
            if (E && KindredSpells.privE.IsReady())
            {
                if (KindredSpells.privE.IsInRange(target) && DamageLibrary.GetSpellDamage(Player.Instance, target, SpellSlot.E) <= 10)
                    KindredSpells.privE.Cast(target);
            }
            if (Smite && KindredSpells.smite != null && KindredSpells.smite.IsReady() && DamageLibrary.GetSpellDamage(Player.Instance, target, KindredSpells.smite.Slot) <= 0)
                KindredSpells.smite.Cast(target);
        }
        public void combo()
        {
            var target = TargetSelector.GetTarget(ObjectManager.Player.AttackRange + KindredSpells.privQ.Range + 70, DamageType.Physical);
            if (target == null)
                return;
            gTarget = target;
            if(KindredSpells.privR.IsReady() && ObjectManager.Player.CountEnemiesInRange(ObjectManager.Player.AttackRange) >= KindredMenu.minRcombo())            
                KindredSpells.privR.Cast(Player.Instance);
            if ((ObjectManager.Player.CountEnemiesInRange(ObjectManager.Player.AttackRange) >= KindredMenu.itemsYOUMUSSenemys() || Player.Instance.HealthPercent >= KindredMenu.itemsYOUMUSShp()) && KindredSpells.youmus.IsReady())
                KindredSpells.youmus.Cast();
            if (Player.Instance.HealthPercent <= KindredMenu.itemsBOTRKhp() && KindredSpells.botrk.IsReady())
                KindredSpells.botrk.Cast(target);
            if (KindredSpells.privQ.IsReady() && KindredMenu.useQ())
            {
                if (ObjectManager.Player.Distance(target.Position) <= ObjectManager.Player.GetAutoAttackRange() && Player.Instance.HealthPercent <= KindredMenu.minQcombo() || ObjectManager.Player.CountEnemiesInRange(ObjectManager.Player.AttackRange) >= KindredMenu.minQaggresive())
                Player.CastSpell(SpellSlot.Q, -1*(target.Position));
                else if (ObjectManager.Player.Distance(target.Position) >= (ObjectManager.Player.GetAutoAttackRange() + KindredSpells.privQ.Range))
                    Player.CastSpell(SpellSlot.Q, target.Position);
                else
                Player.CastSpell(SpellSlot.Q, Game.CursorPos);
            }
            if (KindredSpells.privE.IsReady() && KindredMenu.useE())
                KindredSpells.privE.Cast(target);
            if (KindredSpells.privW.IsReady() && KindredMenu.useW())
                KindredSpells.privW.Cast(target);
            if (KindredSpells.smite.IsReady() && KindredMenu.useSmiteCombo())
                KindredSpells.smite.Cast(target);
        }
        public void jungleClear()
        {
            var minions = ObjectManager.Get<Obj_AI_Minion>().Where(minion => minion.IsValid && KindredVariables.MinionNames.Any(name => minion.Name.StartsWith(name)) && !KindredVariables.MinionNames.Any(name => minion.Name.Contains("Mini")) && !KindredVariables.MinionNames.Any(name => minion.Name.Contains("Spawn") && Player.Instance.IsInAutoAttackRange(minion)));
            var objAiMinions = minions as Obj_AI_Minion[] ?? minions.ToArray();
            Obj_AI_Minion sMinion = objAiMinions.FirstOrDefault();
            if (sMinion == null)
                return;
            if (KindredSpells.privQ.IsReady() && KindredMenu.useQjungle())
                Player.CastSpell(SpellSlot.Q, -1 * (sMinion.Position));
            if (KindredSpells.privW.IsReady() && KindredMenu.useWjungle())
                KindredSpells.privW.Cast(sMinion);
            if (KindredSpells.privE.IsReady() && KindredMenu.useEjungle())
                KindredSpells.privE.Cast(sMinion);
            if (KindredSpells.smite.IsReady() && KindredMenu.useSmitejungle())
                KindredSpells.smite.Cast(sMinion);
        }
        public void laneClear()
        {
            var minions = ObjectManager.Get<Obj_AI_Minion>().Where(minion => minion.IsValid() && Player.Instance.IsInAutoAttackRange(minion)).FirstOrDefault();
            if (minions == null)
                return;
            if (KindredSpells.privQ.IsReady() && KindredMenu.useQlc())
                Player.CastSpell(SpellSlot.Q, Game.CursorPos);
            if (KindredSpells.privW.IsReady() && KindredMenu.useWlc())
                KindredSpells.privW.Cast(minions);
            if (KindredSpells.privE.IsReady() && KindredMenu.useElc())
                KindredSpells.privE.Cast(minions);
        }
        public void Flee()
        {
            var target = TargetSelector.GetTarget(ObjectManager.Player.AttackRange + KindredSpells.privQ.Range, DamageType.Physical);
            if (target != null)
            {
                if (KindredSpells.privQ.IsReady() && KindredMenu.fleeSmart() && KindredMenu.MinmanaFlee() <= Player.Instance.ManaPercent)
                {
                    if (ObjectManager.Player.Distance(target.Position) <= ObjectManager.Player.GetAutoAttackRange() && Player.Instance.HealthPercent <= KindredMenu.minQcombo() || ObjectManager.Player.CountEnemiesInRange(ObjectManager.Player.AttackRange) >= KindredMenu.minQaggresive())
                        Player.CastSpell(SpellSlot.Q, -1 * (target.Position));
                    else if (ObjectManager.Player.Distance(target.Position) >= (ObjectManager.Player.GetAutoAttackRange() + KindredSpells.privQ.Range))
                        Player.CastSpell(SpellSlot.Q, target.Position);
                    else
                        Player.CastSpell(SpellSlot.Q, Game.CursorPos);
                }
            }
            else
            {
               if (KindredSpells.privQ.IsReady() && KindredMenu.MinmanaFlee() >= Player.Instance.ManaPercent)
                Player.CastSpell(SpellSlot.Q, Game.CursorPos);
            }

        }

    }
}
