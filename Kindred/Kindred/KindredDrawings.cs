using EloBuddy;
using EloBuddy.SDK.Rendering;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kindred
{
    class KindredDrawings
    {
       // private static KindredMenu mMenu= new KindredMenu();
        public static void actives(EventArgs args)
        {
            skills(KindredMenu.drawingsQ(), KindredMenu.drawingsW(), KindredMenu.drawingsE(), KindredMenu.drawingsR());
            others(KindredMenu.drawingsTarget());
        }
        public static void skills(bool Q,bool W,bool E,bool R)
        {
           if(Q)
           Circle.Draw(Color.Purple, KindredSpells.privQ.Range, ObjectManager.Player.Position);
           if(W)
           Circle.Draw(Color.Purple, KindredSpells.privW.Range, ObjectManager.Player.Position);
           if(E)
           Circle.Draw(Color.Purple, KindredSpells.privE.Range, ObjectManager.Player.Position);
           if(R)
           Circle.Draw(Color.Purple, KindredSpells.privR.Range, ObjectManager.Player.Position);
        }
        public static void others(bool target)
        {
            if (Kindred.gTarget != null && target)
                Circle.Draw(Color.Red, 70, Kindred.gTarget.Position);
        }
    }
}
