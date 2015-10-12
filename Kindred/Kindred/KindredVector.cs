using EloBuddy;
using EloBuddy.SDK;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindred
{
    class KindredVector
    {
        public static Vector2 buildVector(float x, float y)
        {
            return new Vector2(x, y);
        }
        public static Obj_AI_Minion GetNearest(Vector3 pos)
        {
            var minions = ObjectManager.Get<Obj_AI_Minion>().Where(minion => minion.IsValid && KindredVariables.MinionNames.Any(name => minion.Name.StartsWith(name)) && !KindredVariables.MinionNames.Any(name => minion.Name.Contains("Mini")) && !KindredVariables.MinionNames.Any(name => minion.Name.Contains("Spawn")));
            var objAiMinions = minions as Obj_AI_Minion[] ?? minions.ToArray();
            Obj_AI_Minion sMinion = objAiMinions.FirstOrDefault();
            double? nearest = null;
            foreach (Obj_AI_Minion minion in objAiMinions)
            {
                double distance = Vector3.Distance(pos, minion.Position);
                if (nearest == null || nearest > distance)
                {
                    nearest = distance;
                    sMinion = minion;
                }
            }
            return sMinion;
        }
    }
}
